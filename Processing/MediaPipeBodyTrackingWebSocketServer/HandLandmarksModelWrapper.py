from concurrent.futures import ThreadPoolExecutor, as_completed, wait
import os
import time
from typing import List
import cv2
import mediapipe as mp
import numpy as np
from scipy.spatial.distance import euclidean
import DetectsHandLandmarksStructures as DetectsStructures
import LoadHandLandmarksModelStructures as LoadModelStructures
from MainStructures import HandState
import ModelInfo

Tasks = mp.tasks
Vision = mp.tasks.vision
BaseOptions = mp.tasks.BaseOptions
Delegate = mp.tasks.BaseOptions.Delegate
HandLandmarker = mp.tasks.vision.HandLandmarker
HandLandmarkerOptions = mp.tasks.vision.HandLandmarkerOptions
RunningMode = mp.tasks.vision.RunningMode

class HandLandmarksModelWrapper:
    def __init__(self):
        self.options = None
        self.model = None

    def is_model_loaded(self) -> bool:
        return self.model
    
    def load_model(self, request: LoadModelStructures.LoadHandLandmarksModelRequest) -> LoadModelStructures.LoadHandLandmarksModelResponse:
        if self.is_model_loaded():
            return LoadModelStructures.LoadHandLandmarksModelResponse(
                    status=LoadModelStructures.LoadHandLandmarksModelResponseStatus.ok,
                    message=''
            )
        
        if not request:
            return LoadModelStructures.LoadHandLandmarksModelResponse(
                    status=LoadModelStructures.LoadHandLandmarksModelResponseStatus.error,
                    message='Received request is null.'
            )
        
        model_path = ModelInfo.MODEL_PATHS[ModelInfo.ModelKind.hand_landmarker_task]

        if not os.path.exists(model_path):
            return LoadModelStructures.LoadHandLandmarksModelResponse(
                    status=LoadModelStructures.LoadHandLandmarksModelResponseStatus.error,
                    message=f'Not found model file: [{model_path}].'
            )

        self.options = HandLandmarkerOptions(
                base_options=BaseOptions(model_asset_path=model_path, delegate=Delegate.CPU),
                running_mode=RunningMode.IMAGE,
                num_hands=request.num_hands,
                min_hand_detection_confidence=request.min_hand_detection_confidence,
                min_hand_presence_confidence=request.min_hand_presence_confidence,
                min_tracking_confidence=request.min_tracking_confidence)
        
        self.model = HandLandmarker.create_from_options(self.options)

        return LoadModelStructures.LoadHandLandmarksModelResponse(
            status=LoadModelStructures.LoadHandLandmarksModelResponseStatus.ok,
            message=''
        )

    def detects(self, request: DetectsStructures.DetectHandLandmarksRequest) -> DetectsStructures.DetectHandLandmarksResponse:
        handedness = []
        landmarks = []
        world_landmarks = []
        
        if not self.is_model_loaded():
            return DetectsStructures.DetectHandLandmarksResponse(
                    status=DetectsStructures.DetectHandLandmarksResponseStatus.error,
                    message='Request rejected due to not loaded model.',
                    handedness=handedness,
                    landmarks=landmarks,
                    world_landmarks=world_landmarks,
                    bodies_count=0
            )
        
        image = request.image
        image_width = request.image_width
        image_height = request.image_height
        image_target_width = request.image_target_width
        image_target_height = request.image_target_height
        is_one_body_tracking_enabled = request.is_one_body_tracking_enabled

        # start = time.time()

        np_image = np.frombuffer(image, dtype=np.uint8).reshape((image_height, image_width, 3))
        mp_image = mp.Image(image_format=mp.ImageFormat.SRGB, data=np_image)
        # finish = time.time()
        # duration = finish - start
        # print(f"[image] {duration:.6f} seconds")

        # start = time.time()
        result = self.model.detect(mp_image)
        # finish = time.time()
        # duration = finish - start
        # print(f"[detect] {duration:.6f} seconds")

        # start = time.time()
        if not result:
            return DetectsStructures.DetectHandLandmarksResponse(
                status=DetectsStructures.DetectHandLandmarksResponseStatus.no_hand,
                message='',
                handedness=handedness,
                landmarks=landmarks,
                world_landmarks=world_landmarks,
                bodies_count=0
            )

        if not result.handedness:
            return DetectsStructures.DetectHandLandmarksResponse(
                status=DetectsStructures.DetectHandLandmarksResponseStatus.no_hand,
                message='Empty handedness structure in model response.',
                handedness=handedness,
                landmarks=landmarks,
                world_landmarks=world_landmarks,
                bodies_count=0
            )

        # This is not resistant if there are two users and each hides one hand.
        bodies_count = max(len(h) for h in result.handedness)
        if is_one_body_tracking_enabled:
            if bodies_count > 1:
                return DetectsStructures.DetectHandLandmarksResponse(
                    status=DetectsStructures.DetectHandLandmarksResponseStatus.too_much_users_for_one_body_tracking,
                    message='',
                    handedness=handedness,
                    landmarks=landmarks,
                    world_landmarks=world_landmarks,
                    bodies_count=bodies_count
                )

        if not result.hand_landmarks or not result.hand_world_landmarks:
            return DetectsStructures.DetectHandLandmarksResponse(
                status=DetectsStructures.DetectHandLandmarksResponseStatus.no_hand,
                message='Empty landmarks and world_landmarks structures in model response.',
                handedness=handedness,
                landmarks=landmarks,
                world_landmarks=world_landmarks,
                bodies_count=0
            )

        hands_count = len(result.hand_landmarks)

        if len(result.hand_world_landmarks) != hands_count:
            return DetectsStructures.DetectHandLandmarksResponse(
                status=DetectsStructures.DetectHandLandmarksResponseStatus.error,
                message='Invalid structure of model response.',
                handedness=handedness,
                landmarks=landmarks,
                world_landmarks=world_landmarks,
                bodies_count=0
            )

        for hands_landmarks in result.hand_landmarks:
            hand = [DetectsStructures.HandLandmark(idx, (lm.x * image_target_width), (lm.y * image_target_height), lm.z) for idx, lm in enumerate(hands_landmarks)]
            landmarks.append(hand)

        for world_hands_landmarks in result.hand_world_landmarks:
            world_hand = [DetectsStructures.HandLandmark(idx, lm.x, lm.y, lm.z) for idx, lm in enumerate(world_hands_landmarks)]
            world_landmarks.append(world_hand)

        # finish = time.time()
        # duration = finish - start
        # print(f"[prepare result] {duration:.6f} seconds")

        # start = time.time()
        flatten_hands_categories = [hand_category for hands_categories in result.handedness for hand_category in hands_categories]
        hands_data_with_idx = []
        with ThreadPoolExecutor() as executor:
            hands_futures = []
            for idx, hand_category in enumerate(flatten_hands_categories):
                hand_future = executor.submit(self.get_hand_lms_and_data, idx, landmarks[idx], 
                                              world_landmarks[idx], hand_category)
                hands_futures.append(hand_future)

            for hand_future in as_completed(hands_futures):
                hand_idx, hand_data, hand_rgb_lm, hand_world_lm = hand_future.result()
                hands_data_with_idx.append((hand_idx, hand_data))
                landmarks[hand_idx].append(hand_rgb_lm)
                world_landmarks[hand_idx].append(hand_world_lm)

        sorted_hands_data_with_idx = sorted(hands_data_with_idx, key=lambda h: h[0])
        handedness = [hand_data for idx, hand_data in sorted_hands_data_with_idx]
        # finish = time.time() 
        # duration = finish - start
        # print(f"[hand data] {duration:.6f} seconds")

        return DetectsStructures.DetectHandLandmarksResponse(
            status=DetectsStructures.DetectHandLandmarksResponseStatus.ok,
            message='',
            handedness=handedness,
            landmarks=landmarks,
            world_landmarks=world_landmarks,
            bodies_count=bodies_count
        )

    def get_hand_lms_and_data(self, hand_idx: int, lms: List[DetectsStructures.HandLandmark], 
                      world_lms: List[DetectsStructures.HandLandmark],
                      hand_category: mp.tasks.components.containers.Category) -> int | DetectsStructures.HandData | DetectsStructures.HandLandmark | DetectsStructures.HandLandmark:
        hand_rgb_lm = self.get_hand_rgb_lm(lms)
        hand_world_lm, hand_state = self.get_hand_world_lm_and_state(world_lms, hand_category.category_name)
        hand_data = self.get_hand_data(hand_category, hand_state)
        return hand_idx, hand_data, hand_rgb_lm, hand_world_lm

    def get_hand_rgb_lm(self, lms: List[DetectsStructures.HandLandmark]) -> DetectsStructures.HandLandmark:        
        wrist_pos = self.get_wrist_pos(lms)
        thumb_mcp_pos = self.get_thumb_mcp_pos(lms)
        middle_finger_mcp_pos = self.get_middle_finger_mcp_pos(lms)
        pinky_mcp_pos = self.get_pinky_mcp_pos(lms)

        hand_lm = self.get_hand_lm(wrist_pos, thumb_mcp_pos, middle_finger_mcp_pos, pinky_mcp_pos)
        return hand_lm
    
    def get_hand_world_lm_and_state(self, world_lms: List[DetectsStructures.HandLandmark],
                                    category_name: str) -> DetectsStructures.HandLandmark | DetectsStructures.HandState:
        wrist_pos = self.get_wrist_pos(world_lms)
        thumb_mcp_pos = self.get_thumb_mcp_pos(world_lms)
        thumb_tip_pos = self.get_thumb_tip_pos(world_lms)
        index_finger_mcp_pos = self.get_index_finger_mcp_pos(world_lms)
        index_finger_tip_pos = self.get_index_finger_tip_pos(world_lms)
        middle_finger_mcp_pos = self.get_middle_finger_mcp_pos(world_lms)
        middle_finger_tip_pos = self.get_middle_finger_tip_pos(world_lms)
        ring_finger_mcp_pos = self.get_ring_finger_mcp_pos(world_lms)
        ring_finger_tip_pos = self.get_ring_finger_tip_pos(world_lms)
        pinky_mcp_pos = self.get_pinky_mcp_pos(world_lms)
        pinky_dip_pos = self.get_pinky_dip_pos(world_lms)
        pinky_tip_pos = self.get_pinky_tip_pos(world_lms)

        hand_lm = self.get_hand_lm(wrist_pos, thumb_mcp_pos, middle_finger_mcp_pos, pinky_mcp_pos)
        
        hand_state = self.detect_hand_state(wrist_pos, thumb_mcp_pos, thumb_tip_pos, index_finger_mcp_pos, index_finger_tip_pos,
                          middle_finger_mcp_pos, middle_finger_tip_pos, ring_finger_mcp_pos, ring_finger_tip_pos,
                          pinky_mcp_pos, pinky_dip_pos, pinky_tip_pos, category_name)

        return hand_lm, hand_state
    
    def get_hand_data(self, hand_category: mp.tasks.components.containers.Category, hand_state: HandState) -> DetectsStructures.HandData:
        return DetectsStructures.HandData(score=hand_category.score,
                                          category_name=hand_category.category_name,
                                          hand_state=hand_state) 

    def get_wrist_pos(self, lms: List[DetectsStructures.HandLandmark]):
        return self.get_lm_pos(lms[0])
    
    def get_thumb_mcp_pos(self, lms: List[DetectsStructures.HandLandmark]):
        return self.get_lm_pos(lms[2])
    
    def get_thumb_tip_pos(self, lms: List[DetectsStructures.HandLandmark]):
        return self.get_lm_pos(lms[4])    
    
    def get_index_finger_mcp_pos(self, lms: List[DetectsStructures.HandLandmark]):
        return self.get_lm_pos(lms[5])
    
    def get_index_finger_tip_pos(self, lms: List[DetectsStructures.HandLandmark]):
        return self.get_lm_pos(lms[8])    

    def get_middle_finger_mcp_pos(self, lms: List[DetectsStructures.HandLandmark]):
        return self.get_lm_pos(lms[9])

    def get_middle_finger_tip_pos(self, lms: List[DetectsStructures.HandLandmark]):
        return self.get_lm_pos(lms[12])

    def get_ring_finger_mcp_pos(self, lms: List[DetectsStructures.HandLandmark]):
        return self.get_lm_pos(lms[13])

    def get_ring_finger_tip_pos(self, lms: List[DetectsStructures.HandLandmark]):
        return self.get_lm_pos(lms[16])

    def get_pinky_mcp_pos(self, lms: List[DetectsStructures.HandLandmark]):
        return self.get_lm_pos(lms[17])

    def get_pinky_dip_pos(self, lms: List[DetectsStructures.HandLandmark]):
        return self.get_lm_pos(lms[19])

    def get_pinky_tip_pos(self, lms: List[DetectsStructures.HandLandmark]):
        return self.get_lm_pos(lms[20])

    def get_lm_pos(self, lm: DetectsStructures.HandLandmark):
        return np.array([lm.x, lm.y, lm.z])

    def get_hand_lm(self, wrist_pos, thumb_mcp_pos, middle_finger_mcp_pos, pinky_mcp_pos):
        hand_pos = self.compute_hand_pos(wrist_pos, thumb_mcp_pos, middle_finger_mcp_pos, pinky_mcp_pos)
        return DetectsStructures.HandLandmark(21, hand_pos[0], hand_pos[1], hand_pos[2])

    def compute_hand_pos(self, wrist_pos, thumb_mcp_pos, middle_finger_mcp_pos, pinky_mcp_pos):
        pos = (wrist_pos + thumb_mcp_pos + middle_finger_mcp_pos + pinky_mcp_pos) / 4
        return pos

    def euclidean_norm(self, pos1, pos2, norm_dist):
        return euclidean(pos1, pos2) / norm_dist

    def detect_hand_state(self, wrist_pos, thumb_mcp_pos, thumb_tip_pos, index_finger_mcp_pos, index_finger_tip_pos,
                          middle_finger_mcp_pos, middle_finger_tip_pos, ring_finger_mcp_pos, ring_finger_tip_pos,
                          pinky_mcp_pos, pinky_dip_pos, pinky_tip_pos, category_name):
        thumb_open_threshold = 1.3
        index_finger_open_threshold = 1.7
        middle_finger_open_threshold = 1.8
        ring_finger_open_threshold = 1.65
        pinky_open_threshold = 1.5

        thumb_closed_threshold = 1.0
        index_finger_closed_threshold = 0.6
        middle_finger_closed_threshold = 0.6
        ring_finger_closed_threshold = 0.6
        pinky_closed_threshold = 0.6

        thumb_mcp_pinky_mcp_dist = euclidean(thumb_mcp_pos, pinky_mcp_pos)


        
        wrist_thumb_tip_dist = self.euclidean_norm(wrist_pos, thumb_tip_pos, thumb_mcp_pinky_mcp_dist)
        if wrist_thumb_tip_dist > thumb_open_threshold:
            wrist_index_finger_tip_dist = self.euclidean_norm(wrist_pos, index_finger_tip_pos, thumb_mcp_pinky_mcp_dist)
            if wrist_index_finger_tip_dist > index_finger_open_threshold:
                wrist_middle_finger_tip_dist = self.euclidean_norm(wrist_pos, middle_finger_tip_pos, thumb_mcp_pinky_mcp_dist)
                if wrist_middle_finger_tip_dist > middle_finger_open_threshold:
                    wrist_ring_finger_tip_dist = self.euclidean_norm(wrist_pos, ring_finger_tip_pos, thumb_mcp_pinky_mcp_dist)
                    if wrist_ring_finger_tip_dist > ring_finger_open_threshold:
                        wrist_pinky_tip_dist = self.euclidean_norm(wrist_pos, pinky_tip_pos, thumb_mcp_pinky_mcp_dist)
                        if wrist_pinky_tip_dist > pinky_open_threshold:
                            return HandState.Open

        thumb_tip_pinky_dip_dist = self.euclidean_norm(thumb_tip_pos, pinky_dip_pos, thumb_mcp_pinky_mcp_dist)
        if thumb_tip_pinky_dip_dist < thumb_closed_threshold:
            index_finger_tip_index_finger_mcp_dist = self.euclidean_norm(index_finger_tip_pos, index_finger_mcp_pos, thumb_mcp_pinky_mcp_dist)
            if index_finger_tip_index_finger_mcp_dist < index_finger_closed_threshold:
                middle_finger_tip_middle_finger_mcp_dist = self.euclidean_norm(middle_finger_tip_pos, middle_finger_mcp_pos, thumb_mcp_pinky_mcp_dist)
                if middle_finger_tip_middle_finger_mcp_dist < middle_finger_closed_threshold:
                    ring_finger_tip_ring_finger_mcp_dist = self.euclidean_norm(ring_finger_tip_pos, ring_finger_mcp_pos, thumb_mcp_pinky_mcp_dist)
                    if ring_finger_tip_ring_finger_mcp_dist < ring_finger_closed_threshold:
                        pinky_tip_pinky_mcp_dist = self.euclidean_norm(pinky_tip_pos, pinky_mcp_pos, thumb_mcp_pinky_mcp_dist)
                        if pinky_tip_pinky_mcp_dist < pinky_closed_threshold:
                            return HandState.Closed

        return HandState.Unknown
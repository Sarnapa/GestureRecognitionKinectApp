from concurrent.futures import ThreadPoolExecutor
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
                    status=DetectsStructures.DetectPoseLandmarksResponseStatus.error,
                    message='Request rejected due to not loaded model.',
                    handedness=handedness,
                    landmarks=landmarks,
                    world_landmarks=world_landmarks
            )
        
        image = request.image
        image_width = request.image_width
        image_height = request.image_height

        # start = time.time()
        np_image = np.frombuffer(image, dtype=np.uint8).reshape((image_height, image_width, 4))
        
        # TODO: Scaling factor as a parameter and minimum values
        # scale_factor = 0.
        # resized_image_width = int(image_width * scale_factor)
        # resized_image_height = int(image_height * scale_factor)
        
        # resized_image = cv2.resize(np_image, (resized_image_width, resized_image_height), interpolation=cv2.INTER_AREA)

        # TODO: image format as a request parameter
        rgb_image = cv2.cvtColor(np_image, cv2.COLOR_BGRA2RGB)
        mp_image = mp.Image(image_format=mp.ImageFormat.SRGB, data=rgb_image)
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
                status=DetectsStructures.DetectHandLandmarksResponseStatus.no_pose,
                message='',
                handedness=handedness,
                landmarks=landmarks,
                world_landmarks=world_landmarks
            )

        if not result.handedness:
            return DetectsStructures.DetectHandLandmarksResponse(
                status=DetectsStructures.DetectHandLandmarksResponseStatus.no_hand,
                message='Empty handedness structure in model response.',
                handedness=handedness,
                landmarks=landmarks,
                world_landmarks=world_landmarks
            )

        if not result.hand_landmarks or not result.hand_world_landmarks:
            return DetectsStructures.DetectHandLandmarksResponse(
                status=DetectsStructures.DetectHandLandmarksResponseStatus.no_hand,
                message='Empty landmarks and world_landmarks structures in model response.',
                handedness=handedness,
                landmarks=landmarks,
                world_landmarks=world_landmarks
            )

        hands_count = len(result.hand_landmarks)

        if len(result.hand_world_landmarks) != hands_count:
            return DetectsStructures.DetectHandLandmarksResponse(
                status=DetectsStructures.DetectHandLandmarksResponseStatus.error,
                message='Invalid structure of model response.',
                handedness=handedness,
                landmarks=landmarks,
                world_landmarks=world_landmarks
            )

        for hands_landmarks in result.hand_landmarks:
            hand = [DetectsStructures.HandLandmark(idx, (lm.x * image_width), (lm.y * image_height), lm.z) for idx, lm in enumerate(hands_landmarks)]
            landmarks.append(hand)

        for world_hands_landmarks in result.hand_world_landmarks:
            world_hand = [DetectsStructures.HandLandmark(idx, lm.x, lm.y, lm.z) for idx, lm in enumerate(world_hands_landmarks)]
            world_landmarks.append(world_hand)
        
        for hands_data_category in result.handedness:
            hands_data = [DetectsStructures.HandData(hand_data.index, hand_data.score, hand_data.category_name, HandState.Unknown) for hand_data in hands_data_category]
            handedness.append(hands_data)

        # finish = time.time()
        # duration = finish - start
        # print(f"[prepare result] {duration:.6f} seconds")

        # start = time.time()
        # for i in range(hands_count):
        #     # TODO: In parallel for each pose
        #     with ThreadPoolExecutor() as executor:
        #         left_hand_state = DetectsStructures.HandState.Unknown
        #         right_hand_state = DetectsStructures.HandState.Unknown

        #         get_left_hand_rgb_lm_future = executor.submit(self.get_hand_rgb_lm, landmarks[i], True)
        #         get_right_hand_rgb_lm_future = executor.submit(self.get_hand_rgb_lm, landmarks[i], False)
        #         get_left_hand_world_lm_and_state_future = executor.submit(self.get_hand_world_lm_and_state, world_landmarks[i], True)
        #         get_right_hand_world_lm_and_state_future = executor.submit(self.get_hand_world_lm_and_state, world_landmarks[i], False)

        #         left_hand_rgb_lm = get_left_hand_rgb_lm_future.result()
        #         right_hand_rgb_lm = get_right_hand_rgb_lm_future.result()
        #         left_hand_world_lm, left_hand_state = get_left_hand_world_lm_and_state_future.result()
        #         right_hand_world_lm, right_hand_state = get_right_hand_world_lm_and_state_future.result()

        #         landmarks[i].append(left_hand_rgb_lm)
        #         landmarks[i].append(right_hand_rgb_lm)
        #         world_landmarks[i].append(left_hand_world_lm)
        #         world_landmarks[i].append(right_hand_world_lm)

        # finish = time.time()
        # duration = finish - start
        # print(f"[hand data] {duration:.6f} seconds")

        return DetectsStructures.DetectHandLandmarksResponse(
            status=DetectsStructures.DetectHandLandmarksResponseStatus.ok,
            message='',
            handedness=handedness,
            landmarks=landmarks,
            world_landmarks=world_landmarks
        )

    # def get_hand_rgb_lm(self, lms: List[List[DetectsStructures.PoseLandmark]], is_left: bool) -> DetectsStructures.PoseLandmark:
    #     hand_idx = 33 if is_left else 34
        
    #     wrist_lm, wrist_pos = self.get_wrist_lm_pos(lms, is_left)
    #     pinky_lm, pinky_pos = self.get_pinky_lm_pos(lms, is_left)
    #     index_lm, index_pos = self.get_index_lm_pos(lms, is_left)
    #     thumb_lm, thumb_pos = self.get_thumb_lm_pos(lms, is_left)

    #     hand_lm = self.get_hand_lm(wrist_lm, wrist_pos, pinky_lm, pinky_pos, index_lm, index_pos,
    #                                thumb_lm, thumb_pos, hand_idx)
    #     return hand_lm
    
    # def get_hand_world_lm_and_state(self, world_lms: List[List[DetectsStructures.PoseLandmark]], is_left: bool) -> DetectsStructures.PoseLandmark | DetectsStructures.HandState:
    #     hand_idx = 33 if is_left else 34
        
    #     wrist_lm, wrist_pos = self.get_wrist_lm_pos(world_lms, is_left)
    #     pinky_lm, pinky_pos = self.get_pinky_lm_pos(world_lms, is_left)
    #     index_lm, index_pos = self.get_index_lm_pos(world_lms, is_left)
    #     thumb_lm, thumb_pos = self.get_thumb_lm_pos(world_lms, is_left)

    #     hand_lm = self.get_hand_lm(wrist_lm, wrist_pos, pinky_lm, pinky_pos, index_lm, index_pos,
    #                                thumb_lm, thumb_pos, hand_idx)
        
    #     # TODO: To be completed
    #     hand_state = HandState.Unknown
    #     # hand_state = self.detect_hand_state(wrist_pos, pinky_pos, index_pos, thumb_pos)

    #     return hand_lm, hand_state

    # def get_wrist_lm_pos(self, lms: List[List[DetectsStructures.PoseLandmark]], is_left: bool) -> DetectsStructures.PoseLandmark:
    #     lm = lms[15] if is_left else lms[16]
    #     return lm, self.get_lm_pos(lm)
    
    # def get_pinky_lm_pos(self, lms: List[List[DetectsStructures.PoseLandmark]], is_left: bool) -> DetectsStructures.PoseLandmark:
    #     lm = lms[17] if is_left else lms[18]
    #     return lm, self.get_lm_pos(lm)
    
    # def get_index_lm_pos(self, lms: List[List[DetectsStructures.PoseLandmark]], is_left: bool) -> DetectsStructures.PoseLandmark:
    #     lm = lms[19] if is_left else lms[20]
    #     return lm, self.get_lm_pos(lm)
    
    # def get_thumb_lm_pos(self, lms: List[List[DetectsStructures.PoseLandmark]], is_left: bool) -> DetectsStructures.PoseLandmark:
    #     lm = lms[21] if is_left else lms[22]
    #     return lm, self.get_lm_pos(lm)
    
    # def get_lm_pos(self, lm: DetectsStructures.PoseLandmark):
    #     return np.array([lm.x, lm.y, lm.z])

    # def get_hand_lm(self, wrist_lm, wrist_pos, pinky_lm, pinky_pos, index_lm, index_pos,
    #                 thumb_lm, thumb_pos, idx):
    #     hand_pos = self.compute_hand_pos(wrist_pos, pinky_pos, index_pos, thumb_pos)
    #     hand_presence, hand_visibility = self.compute_hand_presence_and_visibility(wrist_lm,
    #                                         pinky_lm, index_lm, thumb_lm)
    #     return DetectsStructures.PoseLandmark(idx, hand_pos[0], hand_pos[1], hand_pos[2],
    #                                           hand_visibility, hand_presence)

    # def compute_hand_pos(self, wrist_pos, pinky_pos, index_pos, thumb_pos):
    #     pos = (wrist_pos + pinky_pos + index_pos + thumb_pos) / 4
    #     return pos
    
    # def compute_hand_presence_and_visibility(self, wrist_lm: DetectsStructures.PoseLandmark,
    #     pinky_lm: DetectsStructures.PoseLandmark, index_lm: DetectsStructures.PoseLandmark,
    #     thumb_lm: DetectsStructures.PoseLandmark):

    #     wrist_presence = wrist_lm.visibility if wrist_lm.visibility is not None else 0
    #     pinky_presence = pinky_lm.visibility if pinky_lm.visibility is not None else 0
    #     index_presence = index_lm.visibility if index_lm.visibility is not None else 0
    #     thumb_presence = thumb_lm.visibility if thumb_lm.visibility is not None else 0

    #     wrist_visibility = wrist_lm.presence if wrist_lm.presence is not None else 0
    #     pinky_visibility = pinky_lm.presence if pinky_lm.presence is not None else 0
    #     index_visibility = index_lm.presence if index_lm.presence is not None else 0
    #     thumb_visibility = thumb_lm.presence if thumb_lm.presence is not None else 0

    #     presence = (wrist_presence * pinky_presence * index_presence * thumb_presence) ** 0.25
    #     visibility = (wrist_visibility * pinky_visibility * index_visibility * thumb_visibility) ** 0.25

    #     return presence, visibility

    # # TODO: To be completed - the study is incomplete, but this model had little chance of success due to poor finger tracking.                          
    # def detect_hand_state(self, wrist_pos, pinky_pos, index_pos, thumb_pos):
    #     pinky_open_threshold = 0.055
    #     index_open_threshold = 0.07
    #     thumb_open_threshold = 0.0125
    #     pinky_closed_threshold = 0.05
    #     index_closed_threshold = 0.05
    #     thumb_closed_threshold = 0.035
        
    #     hand_state = HandState.Unknown

    #     pinky_thumb_dist = euclidean(pinky_pos, thumb_pos)

    #     pinky_dist = euclidean(wrist_pos, pinky_pos) / pinky_thumb_dist
    #     index_dist = euclidean(wrist_pos, index_pos) / pinky_thumb_dist
    #     thumb_dist = euclidean(wrist_pos, thumb_pos) / pinky_thumb_dist

    #     # print(f"[detect_hand_state] {is_left} {str(pinky_thumb_dist).replace(".",",")};{str(pinky_dist).replace(".",",")};{str(index_dist).replace(".",",")};{str(thumb_dist).replace(".",",")}")

    #     if pinky_dist <= pinky_closed_threshold and index_dist <= index_closed_threshold and thumb_dist <= thumb_closed_threshold:
    #         hand_state = HandState.Closed
    #     elif pinky_dist >= pinky_open_threshold and index_dist >= index_open_threshold and thumb_dist >= thumb_open_threshold:
    #         hand_state =  HandState.Open

    #     return hand_state
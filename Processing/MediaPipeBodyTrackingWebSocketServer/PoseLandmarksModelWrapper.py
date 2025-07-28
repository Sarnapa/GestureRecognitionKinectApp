import base64
import cv2
import os
import mediapipe as mp
import numpy as np
import DetectsPoseLandmarksStructures as DetectsStructures
import LoadPoseLandmarksModelStructures as LoadModelStructures
import ModelInfo

Tasks = mp.tasks
Vision = mp.tasks.vision
BaseOptions = mp.tasks.BaseOptions
PoseLandmarker = mp.tasks.vision.PoseLandmarker
PoseLandmarkerOptions = mp.tasks.vision.PoseLandmarkerOptions
RunningMode = mp.tasks.vision.RunningMode

class PoseLandmarksModelWrapper:
    def __init__(self):
        self.options = None
        self.model = None

    def is_model_loaded(self) -> bool:
        return self.model
    
    def load_model(self, request: LoadModelStructures.LoadPoseLandmarksModelRequest) -> LoadModelStructures.LoadPoseLandmarksModelResponse:
        if self.is_model_loaded():
            return LoadModelStructures.LoadPoseLandmarksModelResponse(
                    status=LoadModelStructures.LoadPoseLandmarksModelResponseStatus.ok,
                    message=''
            )
        
        if not request:
            return LoadModelStructures.LoadPoseLandmarksModelResponse(
                    status=LoadModelStructures.LoadPoseLandmarksModelResponseStatus.error,
                    message='Received request is null.'
            )
        
        model_kind = ModelInfo.ModelKind(request.model_kind)

        if model_kind not in (ModelInfo.ModelKind.pose_landmarks_lite,
                            ModelInfo.ModelKind.pose_landmarks_full,
                            ModelInfo.ModelKind.pose_landmarks_heavy):
            return LoadModelStructures.LoadPoseLandmarksModelResponse(
                    status=LoadModelStructures.LoadPoseLandmarksModelResponseStatus.error,
                    message='Requested model kind is not supported.'
            )
        
        model_path = ModelInfo.MODEL_PATHS[model_kind]

        if not os.path.exists(model_path):
            return LoadModelStructures.LoadPoseLandmarksModelResponse(
                    status=LoadModelStructures.LoadPoseLandmarksModelResponseStatus.error,
                    message=f'Not found model file: [{model_path}].'
            )

        self.options = PoseLandmarkerOptions(
                base_options=BaseOptions(model_asset_path=model_path),
                running_mode=RunningMode.IMAGE,
                num_poses=request.num_poses,
                min_pose_detection_confidence=request.min_pose_detection_confidence,
                min_pose_presence_confidence=request.min_pose_presence_confidence,
                min_tracking_confidence=request.min_tracking_confidence)
        
        self.model = PoseLandmarker.create_from_options(self.options)

        return LoadModelStructures.LoadPoseLandmarksModelResponse(
            status=LoadModelStructures.LoadPoseLandmarksModelResponseStatus.ok,
            message=''
        )

    def detects(self, request: DetectsStructures.DetectPoseLandmarksRequest) -> DetectsStructures.DetectPoseLandmarksResponse:
        landmarks = []
        world_landmarks = []
        
        if not self.is_model_loaded():
            return DetectsStructures.DetectPoseLandmarksResponse(
                    status=DetectsStructures.DetectPoseLandmarksResponseStatus.error,
                    message='Request rejected due to not loaded model.',
                    landmarks=landmarks,
                    world_landmarks=world_landmarks,
            )
        
        image_width = request.image_width
        image_height = request.image_height

        image_data = base64.b64decode(request.image)
        np_image = np.frombuffer(image_data, dtype=np.uint8).reshape((image_height, image_width, 4))
        
        # TODO: Scaling factor as a parameter and minimum values
        # scale_factor = 0.75
        # resized_image_width = int(image_width * scale_factor)
        # resized_image_height = int(image_height * scale_factor)
        
        # resized_image = cv2.resize(np_image, (resized_image_width, resized_image_height), interpolation=cv2.INTER_AREA)

        # TODO: image format as a request parameter
        rgb_image = cv2.cvtColor(np_image, cv2.COLOR_BGRA2RGB)
        mp_image = mp.Image(image_format=mp.ImageFormat.SRGB, data=rgb_image)
        
        result = self.model.detect(mp_image)
        if not result:
            return DetectsStructures.DetectPoseLandmarksResponse(
                status=DetectsStructures.DetectPoseLandmarksResponseStatus.no_pose,
                message='',
                landmarks=landmarks,
                world_landmarks=world_landmarks,
            )

        if not result.pose_landmarks or not result.pose_world_landmarks:
            return DetectsStructures.DetectPoseLandmarksResponse(
                status=DetectsStructures.DetectPoseLandmarksResponseStatus.no_pose,
                message='',
                landmarks=landmarks,
                world_landmarks=world_landmarks,
            )

        for pose_landmarks in result.pose_landmarks:
            pose = [DetectsStructures.PoseLandmark(idx, (lm.x * image_width), (lm.y * image_height), lm.z, lm.visibility, lm.presence) for idx, lm in enumerate(pose_landmarks)]
            landmarks.append(pose)

        for world_pose_landmarks in result.pose_world_landmarks:
            world_pose = [DetectsStructures.PoseLandmark(idx, lm.x, lm.y, lm.z, lm.visibility, lm.presence) for idx, lm in enumerate(world_pose_landmarks)]
            world_landmarks.append(world_pose)

        return DetectsStructures.DetectPoseLandmarksResponse(
            status=DetectsStructures.DetectPoseLandmarksResponseStatus.ok,
            message='',
            landmarks=landmarks,
            world_landmarks=world_landmarks,
        )


        

from enum import Enum

class ModelKind(Enum):
    pose_landmarks_lite = 0
    pose_landmarks_full = 1
    pose_landmarks_heavy = 2

POSE_LANDMARKS_MODEL_MAIN_DIRECTORY_PATH = r'C:\Users\Michal\source\repos\GestureRecognitionKinectApp\Processing\MediaPipeBodyTrackingRESTService\Models\PoseLandmarksDetection'

MODEL_PATHS = {
    ModelKind.pose_landmarks_lite: f'{POSE_LANDMARKS_MODEL_MAIN_DIRECTORY_PATH}\pose_landmarker_lite.task',
    ModelKind.pose_landmarks_full: f'{POSE_LANDMARKS_MODEL_MAIN_DIRECTORY_PATH}\pose_landmarker_full.task',
    ModelKind.pose_landmarks_heavy: f'{POSE_LANDMARKS_MODEL_MAIN_DIRECTORY_PATH}\pose_landmarker_heavy.task',
}
from enum import Enum

class ModelKind(Enum):
    pose_landmarks_lite = 0x00
    pose_landmarks_full = 0x01
    pose_landmarks_heavy = 0x02
    hand_landmarker_task = 0x03

POSE_LANDMARKS_MODEL_MAIN_DIRECTORY_PATH = r'C:\Users\Michal\source\repos\GestureRecognitionKinectApp\Processing\MediaPipeBodyTrackingWebSocketServer\Models\PoseLandmarksDetection'

MODEL_PATHS = {
    ModelKind.pose_landmarks_lite: f'{POSE_LANDMARKS_MODEL_MAIN_DIRECTORY_PATH}\\pose_landmarker_lite.task',
    ModelKind.pose_landmarks_full: f'{POSE_LANDMARKS_MODEL_MAIN_DIRECTORY_PATH}\\pose_landmarker_full.task',
    ModelKind.pose_landmarks_heavy: f'{POSE_LANDMARKS_MODEL_MAIN_DIRECTORY_PATH}\\pose_landmarker_heavy.task',
    ModelKind.hand_landmarker_task: f'C:\\Users\\Michal\\source\\repos\\GestureRecognitionKinectApp\\Processing\\MediaPipeBodyTrackingWebSocketServer\\Models\\HandLandmarksDetection\\hand_landmarker.task',
}
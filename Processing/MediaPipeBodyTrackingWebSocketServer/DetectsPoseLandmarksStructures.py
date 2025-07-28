from enum import Enum
from typing import List

#region DetectPoseLandmarksRequest
class DetectPoseLandmarksRequest:
    def __init__(self, image: str, image_width: int, image_height: int):
        self.image = image
        self.image_width = image_width
        self.image_height = image_height

    def to_dict(self):
        return {
            "image": self.image,
            "image_width": self.image_width,
            "image_height": self.image_height
        }
#endregion

#region PoseLandmark
class PoseLandmark:
    def __init__(self,
                 idx: int, 
                 x: float,
                 y: float, 
                 z: float,
                 visibility: float, 
                 presence: float):
        self.idx = idx
        self.x = x
        self.y = y
        self.z = z
        self.visibility = visibility
        self.presence = presence

    def to_dict(self):
        return {
            "idx": self.idx,
            "x": self.x,
            "y": self.y,
            "z": self.z,
            "visibility": self.visibility,
            "presence": self.presence
        }
#endregion

#region DetectPoseLandmarksResponseStatus
class DetectPoseLandmarksResponseStatus(Enum):
    ok = "ok"
    no_pose = "no_pose"
    error = "error"
#endregion

#region DetectPoseLandmarksResponse
class DetectPoseLandmarksResponse:
    def __init__(self, 
                landmarks: List[List[PoseLandmark]], 
                world_landmarks: List[List[PoseLandmark]], 
                status: DetectPoseLandmarksResponseStatus, 
                message: str):
        self.landmarks = [] if landmarks is None else landmarks
        self.world_landmarks = [] if world_landmarks is None else world_landmarks
        self.status = status
        self.message = message

    def to_dict(self):
        return {
            "landmarks": [ [landmark.to_dict() for landmark in pose] for pose in self.landmarks ],
            "world_landmarks": [ [landmark.to_dict() for landmark in pose] for pose in self.world_landmarks ],
            "status": self.status.value,
            "message": self.message
    }
#endregion
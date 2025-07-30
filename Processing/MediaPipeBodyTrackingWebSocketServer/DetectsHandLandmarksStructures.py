from enum import Enum
import json
from typing import List
from MainStructures import HandState

#region DetectHandLandmarksRequest
class DetectHandLandmarksRequest:
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
    
    def __repr__(self):
        return json.dumps(self.to_dict())
#endregion

#region HandData
class HandData:
    def __init__(self,
                idx: int, 
                score: float,
                category_name: str,
                hand_state: HandState):
        self.idx = idx
        self.score = score
        self.category_name = category_name
        self.hand_state = hand_state

    def to_dict(self):
        return {
            "idx": self.idx,
            "score": self.score,
            "category_name": self.category_name,
            "hand_state": self.hand_state.value,
        }

    def __repr__(self):
        return json.dumps(self.to_dict())

#region HandLandmark
class HandLandmark:
    def __init__(self,
                 idx: int, 
                 x: float,
                 y: float, 
                 z: float,):
        self.idx = idx
        self.x = x
        self.y = y
        self.z = z

    def to_dict(self):
        return {
            "idx": self.idx,
            "x": self.x,
            "y": self.y,
            "z": self.z
        }
    
    def __repr__(self):
        return json.dumps(self.to_dict())
#endregion

#region DetectHandLandmarksResponseStatus
class DetectHandLandmarksResponseStatus(Enum):
    ok = 0x00
    no_hand = 0x01
    error = 0xFF
#endregion

#region DetectHandLandmarksResponse
class DetectHandLandmarksResponse:
    def __init__(self,
                handedness: List[List[HandData]],
                landmarks: List[List[HandLandmark]], 
                world_landmarks: List[List[HandLandmark]],
                status: DetectHandLandmarksResponseStatus, 
                message: str):
        self.handedness = handedness
        self.landmarks = [] if landmarks is None else landmarks
        self.world_landmarks = [] if world_landmarks is None else world_landmarks
        self.status = status
        self.message = message

    def to_dict(self):
        return {
            "handedness": [ [hand_data.to_dict() for hand_data in hands_data] for hands_data in self.handedness ],
            "landmarks": [ [landmark.to_dict() for landmark in hand] for hand in self.landmarks ],
            "world_landmarks": [ [landmark.to_dict() for landmark in hand] for hand in self.world_landmarks ],
            "status": self.status.value,
            "message": self.message
        }

    def __repr__(self):
        return json.dumps(self.to_dict())
#endregion
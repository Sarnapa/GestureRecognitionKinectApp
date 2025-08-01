from enum import Enum
import json
from typing import List
from MainStructures import HandState

#region DetectHandLandmarksRequest
class DetectHandLandmarksRequest:
    def __init__(self, image: str, image_width: int, image_height: int,
                 image_target_width: int, image_target_height: int, 
                 is_one_body_tracking_enabled: bool):
        self.image = image
        self.image_width = image_width
        self.image_height = image_height
        self.image_target_width = image_target_width
        self.image_target_height = image_target_height
        self.is_one_body_tracking_enabled = is_one_body_tracking_enabled

    def to_dict(self):
        return {
            "image": self.image,
            "image_width": self.image_width,
            "image_height": self.image_height,
            "image_target_width": self.image_target_width,
            "image_target_height": self.image_target_height,
            "is_one_body_tracking_enabled": self.is_one_body_tracking_enabled
        }
    
    def __repr__(self):
        return json.dumps(self.to_dict())
#endregion

#region HandData
class HandData:
    def __init__(self,
                score: float,
                category_name: str,
                hand_state: HandState):
        self.score = score
        self.category_name = category_name
        self.hand_state = hand_state

    def to_dict(self):
        return {
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
    too_much_users_for_one_body_tracking = 0x02
    error = 0xFF
#endregion

#region DetectHandLandmarksResponse
class DetectHandLandmarksResponse:
    def __init__(self,
                handedness: List[HandData],
                landmarks: List[List[HandLandmark]], 
                world_landmarks: List[List[HandLandmark]],
                bodies_count: int,
                status: DetectHandLandmarksResponseStatus, 
                message: str):
        self.handedness = [] if handedness is None else handedness
        self.landmarks = [] if landmarks is None else landmarks
        self.world_landmarks = [] if world_landmarks is None else world_landmarks
        self.bodies_count = bodies_count
        self.status = status
        self.message = message

    def to_dict(self):
        return {
            "handedness": [ hand_data.to_dict() for hand_data in self.handedness ],
            "landmarks": [ [landmark.to_dict() for landmark in hand] for hand in self.landmarks ],
            "world_landmarks": [ [landmark.to_dict() for landmark in hand] for hand in self.world_landmarks ],
            "bodies_count": self.bodies_count,
            "status": self.status.value,
            "message": self.message
        }

    def __repr__(self):
        return json.dumps(self.to_dict())
#endregion
from enum import Enum
import json
from typing import List
from MainStructures import HandState

#region DetectPoseLandmarksRequest
class DetectPoseLandmarksRequest:
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
    
    def __repr__(self):
        return json.dumps(self.to_dict())
#endregion

#region DetectPoseLandmarksResponseStatus
class DetectPoseLandmarksResponseStatus(Enum):
    ok = 0x00
    no_pose = 0x01
    too_much_users_for_one_body_tracking = 0x02
    error = 0xFF
#endregion

#region DetectPoseLandmarksResponse
class DetectPoseLandmarksResponse:
    def __init__(self, 
                landmarks: List[List[PoseLandmark]], 
                world_landmarks: List[List[PoseLandmark]],
                hand_left_states: List[HandState],
                hand_right_states: List[HandState],
                bodies_count: int,
                status: DetectPoseLandmarksResponseStatus, 
                message: str):
        self.landmarks = [] if landmarks is None else landmarks
        self.world_landmarks = [] if world_landmarks is None else world_landmarks
        self.hand_left_state = [] if hand_left_states is None else hand_left_states
        self.hand_right_state = [] if hand_right_states is None else hand_right_states
        self.bodies_count = bodies_count
        self.status = status
        self.message = message

    def to_dict(self):
        return {
            "landmarks": [ [landmark.to_dict() for landmark in pose] for pose in self.landmarks ],
            "world_landmarks": [ [landmark.to_dict() for landmark in pose] for pose in self.world_landmarks ],
            "hand_left_states": [state.value for state in self.hand_left_state],
            "hand_right_states": [state.value for state in self.hand_right_state],
            "bodies_count": self.bodies_count,
            "status": self.status.value,
            "message": self.message
        }

    def __repr__(self):
        return json.dumps(self.to_dict())
#endregion
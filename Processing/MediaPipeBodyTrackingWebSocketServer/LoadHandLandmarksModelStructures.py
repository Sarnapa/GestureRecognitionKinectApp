from enum import Enum
import json

#region LoadHandLandmarksModelRequest
class LoadHandLandmarksModelRequest:
    def __init__(self, 
                 num_hands: int, 
                 min_hand_detection_confidence: float, 
                 min_hand_presence_confidence: float, 
                 min_tracking_confidence: float):
        self.num_hands = num_hands
        self.min_hand_detection_confidence = min_hand_detection_confidence
        self.min_hand_presence_confidence = min_hand_presence_confidence
        self.min_tracking_confidence = min_tracking_confidence

    def to_dict(self):
        return {
            "num_hands": self.num_hands,
            "min_hand_detection_confidence": self.min_hand_detection_confidence,
            "min_hand_presence_confidence": self.min_hand_presence_confidence,
            "min_tracking_confidence": self.min_tracking_confidence
        }
    
    def __repr__(self):
        return json.dumps(self.to_dict())
#endregion
    
#region LoadHandLandmarksModelResponseStatus
class LoadHandLandmarksModelResponseStatus(Enum):
    ok = 0x00
    error = 0xFF
#endregion

#region LoadHandLandmarksModelResponse
class LoadHandLandmarksModelResponse:
    def __init__(self, 
                 status: LoadHandLandmarksModelResponseStatus, 
                 message: str = None):
        self.status = status
        self.message = message

    def to_dict(self):
        return {
            "status": self.status.value,
            "message": self.message
        }
    
    def __repr__(self):
        return json.dumps(self.to_dict())
#endregion
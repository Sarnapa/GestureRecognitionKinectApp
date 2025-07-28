from enum import Enum
import json
from ModelInfo import ModelKind

#region LoadPoseLandmarksModelRequest
class LoadPoseLandmarksModelRequest:
    def __init__(self, 
                 model_kind: ModelKind,
                 num_poses: int, 
                 min_pose_detection_confidence: float, 
                 min_pose_presence_confidence: float, 
                 min_tracking_confidence: float):
        self.model_kind = model_kind
        self.num_poses = num_poses
        self.min_pose_detection_confidence = min_pose_detection_confidence
        self.min_pose_presence_confidence = min_pose_presence_confidence
        self.min_tracking_confidence = min_tracking_confidence

    def to_dict(self):
        return {
            "model_kind": self.model_kind,
            "num_poses": self.num_poses,
            "min_pose_detection_confidence": self.min_pose_detection_confidence,
            "min_pose_presence_confidence": self.min_pose_presence_confidence,
            "min_tracking_confidence": self.min_tracking_confidence
        }
    
    def __repr__(self):
        return json.dumps(self.to_dict())
#endregion
    
#region LoadPoseLandmarksModelResponseStatus
class LoadPoseLandmarksModelResponseStatus(Enum):
    ok = 0x00
    error = 0xFF
#endregion

#region LoadPoseLandmarksModelResponse
class LoadPoseLandmarksModelResponse:
    def __init__(self, 
                 status: LoadPoseLandmarksModelResponseStatus, 
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
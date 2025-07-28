from enum import Enum

class ActionKind(Enum):
    load_pose_landmarks_model = "load_pose_landmarks_model"
    detect_pose_landmarks = "detect_pose_landmarks"

    @staticmethod
    def from_string(action_str: str):
        try:
            return ActionKind[action_str.lower()]
        except KeyError:
            return None 
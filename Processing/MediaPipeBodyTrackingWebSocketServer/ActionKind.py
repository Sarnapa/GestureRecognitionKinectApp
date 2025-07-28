from enum import Enum

class ActionKind(Enum):
    load_pose_landmarks_model = 0x00
    detect_pose_landmarks = 0x01

    @staticmethod
    def from_byte(action_byte):
        try:
            return ActionKind(action_byte)
        except KeyError:
            return None 
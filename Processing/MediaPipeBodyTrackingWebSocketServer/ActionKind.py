from enum import Enum

class ActionKind(Enum):
    load_pose_landmarks_model = 0x00
    detect_pose_landmarks = 0x01
    load_hand_landmarks_model = 0x02
    detect_hand_landmarks = 0x03

    @staticmethod
    def from_byte(action_byte):
        try:
            return ActionKind(action_byte)
        except KeyError:
            return None 
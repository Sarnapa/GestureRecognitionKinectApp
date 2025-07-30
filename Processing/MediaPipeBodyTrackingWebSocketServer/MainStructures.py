from enum import Enum
import json

#region InvalidRequestResponse
class InvalidRequestResponse:
    def __init__(self, message):
        self.message = message

    def to_dict(self):
        return {
            "status": 0xFF,
            "message": self.message
        }
    
    def __repr__(self):
        return json.dumps(self.to_dict())
#endregion

#region HandState
class HandState(Enum):
    Unknown = 0x00
    Open = 0x02
    Closed = 0x03 
#endregion
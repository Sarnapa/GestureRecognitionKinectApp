#region InvalidRequestResponse
class InvalidRequestResponse:
    def __init__(self, message):
        self.message = message

    def to_dict(self):
        return {
            "status": "error",
            "message": self.message
        }
#endregion
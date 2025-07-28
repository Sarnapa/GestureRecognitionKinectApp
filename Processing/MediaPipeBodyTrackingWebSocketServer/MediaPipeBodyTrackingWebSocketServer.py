import json
import asyncio
from websockets.asyncio.server import serve
from websockets.exceptions import ConnectionClosedOK
from ActionKind import ActionKind
from DetectsPoseLandmarksStructures import DetectPoseLandmarksRequest
from LoadPoseLandmarksModelStructures import LoadPoseLandmarksModelRequest
from MainStructures import InvalidRequestResponse
from PoseLandmarksModelWrapper import PoseLandmarksModelWrapper

#region Models wrappers
pose_landmarks_model_wrapper = PoseLandmarksModelWrapper()
#endregion

async def handle_request(websocket):
    while True:
        try:
            request_json = await websocket.recv()
            request_data = json.loads(request_json)
            
            response_json = ""

            action = request_data.get("action")
            if not action:
                print(f"Received request without Action parameter.")
                response_json = json.dumps(InvalidRequestResponse("Action is missing.").to_dict())
            else:
                action_kind = ActionKind.from_string(action)
                if action_kind is None:
                    print(f"Received request with invalid Action parameter: [{action}]")
                    response_json = json.dumps(InvalidRequestResponse(f"Invalid action: [{action}]").to_dict())
                else:
                    if action_kind == ActionKind.load_pose_landmarks_model:
                        print(f"[{action}] Received request.")
                        load_model_request = LoadPoseLandmarksModelRequest(**{k: v for k, v in request_data.items() if k != "action"})
                        load_model_response = pose_landmarks_model_wrapper.load_model(load_model_request)
                        response_json = json.dumps(load_model_response.to_dict())
                    elif action_kind == ActionKind.detect_pose_landmarks:
                        print(f"[{action}] Received request.")
                        detects_request = DetectPoseLandmarksRequest(**{k: v for k, v in request_data.items() if k != "action"})
                        detects_response = pose_landmarks_model_wrapper.detects(detects_request)
                        response_json = json.dumps(detects_response.to_dict())

            await websocket.send(response_json)
            print(f"[{action}] Sent response: [{response_json}]")
        except ConnectionClosedOK:
            print(f"Connection has been closed by client.")
            break
        except Exception as ex:
            error_message = {str(ex)}
            print(f"Unexpected error: [{error_message}]")
            response_json = json.dumps(InvalidRequestResponse(error_message).to_dict())
            await websocket.send(response_json)
            print(f"Sent response: [{response_json}]")
#endregion

async def main():
    # Message limit size - 50 MB (for images, problem with base64)
    async with serve(handle_request, "localhost", 5555, max_size=50*1024*1024) as server: 
        print("MediaPipeBodyTrackingWebSocketServer started on ws://localhost:5555")
        await server.serve_forever()

if __name__ == "__main__":
    asyncio.run(main())
#endregion
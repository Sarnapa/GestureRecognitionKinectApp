import asyncio
import msgpack
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
            message = await websocket.recv()
            request_data = msgpack.loads(message)
            
            response_data = None

            action = request_data.get("action")
            if action is None:
                print(f"Received request without Action parameter.")
                response_data = msgpack.dumps(InvalidRequestResponse("Action is missing.").to_dict())
            else:
                action_kind = ActionKind.from_byte(action)
                if action_kind is None:
                    print(f"Received request with invalid Action parameter: [{action}]")
                    response_data = msgpack.dumps(InvalidRequestResponse(f"Invalid action: [{action}]").to_dict())
                else:
                    if action_kind == ActionKind.load_pose_landmarks_model:
                        # Commented out for performance reasons.
                        # print(f"[{action}] Received request.")
                        load_model_request = LoadPoseLandmarksModelRequest(**{k: v for k, v in request_data.items() if k != "action"})
                        load_model_response = pose_landmarks_model_wrapper.load_model(load_model_request)
                        response_data = msgpack.dumps(load_model_response.to_dict())
                    elif action_kind == ActionKind.detect_pose_landmarks:
                        # Commented out for performance reasons.
                        # print(f"[{action}] Received request.")
                        detects_request = DetectPoseLandmarksRequest(**{k: v for k, v in request_data.items() if k != "action"})
                        detects_response = pose_landmarks_model_wrapper.detects(detects_request)
                        response_data = msgpack.dumps(detects_response.to_dict())

            await websocket.send(response_data)
            # Commented out for performance reasons.
            # print(f"[{action}] Sent response: [{response_json}]")
        except ConnectionClosedOK:
            print(f"Connection has been closed by client.")
            break
        except Exception as ex:
            error_message = {str(ex)}
            print(f"Unexpected error: [{error_message}]")
            response_data = msgpack.dumps(InvalidRequestResponse(error_message).to_dict())
            await websocket.send(response_data)
            print(f"Sent response: [{response_data}]")
#endregion

async def main():
    # Message limit size - 10 MB
    async with serve(handle_request, "localhost", 5555, max_size=10*1024*1024) as server: 
        print("MediaPipeBodyTrackingWebSocketServer started on ws://localhost:5555")
        await server.serve_forever()

if __name__ == "__main__":
    asyncio.run(main())
#endregion
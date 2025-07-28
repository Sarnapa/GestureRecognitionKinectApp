import os
import time
from flask import Flask, request, jsonify
from LoadPoseLandmarksModelStructures import LoadPoseLandmarksModelRequest, LoadPoseLandmarksModelResponse, LoadPoseLandmarksModelResponseStatus
from DetectsPoseLandmarksStructures import DetectPoseLandmarksRequest, DetectPoseLandmarksResponse, DetectPoseLandmarksResponseStatus
from PoseLandmarksModelWrapper import PoseLandmarksModelWrapper

app = Flask(__name__)

# Make the WSGI interface available at the top level so wfastcgi can get it.
# wsgi_app = app.wsgi_app

#region Models wrappers
pose_landmarks_model_wrapper = PoseLandmarksModelWrapper()
#endregion

#region load_pose_landmarks_model method
@app.route('/load_pose_landmarks_model', methods=['POST'])
def load_pose_landmarks_model():
    try:
        request_json = request.json
        load_model_request = LoadPoseLandmarksModelRequest(**request_json)
        load_model_response = pose_landmarks_model_wrapper.load_model(load_model_request)
        
        http_code = 200
        if load_model_response.status == LoadPoseLandmarksModelResponseStatus.error:
            http_code = 500

        return jsonify(load_model_response.to_dict()), http_code
    except Exception as e:
        return jsonify(LoadPoseLandmarksModelResponse(
            status=LoadPoseLandmarksModelResponseStatus.error, 
            message=str(e)).to_dict()
            ), 500
#endregion

#region detects_pose_landmarks method
@app.route('/detects_pose_landmarks', methods=['POST'])
def detects_pose():
    try:
        start_time = time.time()
        request_json = request.json
        detects_request = DetectPoseLandmarksRequest(**request_json)
        finish_time = time.time()
        duration = finish_time - start_time
        print(f'[Detects] Deserialization: {duration:.6f} seconds')

        start_time = time.time()
        detects_response = pose_landmarks_model_wrapper.detects(detects_request)
        finish_time = time.time()
        duration = finish_time - start_time
        print(f'[Detects] Duration: {duration:.6f} seconds')

        http_code = 200
        if detects_response.status == DetectPoseLandmarksResponseStatus.error:
            http_code = 500

        start_time = time.time()
        result = jsonify(detects_response.to_dict())
        finish_time = time.time()
        duration = finish_time - start_time
        print(f'[Detects] Serialization: {duration:.6f} seconds')

        return result, http_code
    except Exception as e:
        return jsonify(DetectPoseLandmarksResponse(
            status=DetectPoseLandmarksResponseStatus.error, 
            message=str(e),
            landmarks=[],
            world_landmarks=[]).to_dict()
            ), 500
#endregion

#region Main
if __name__ == '__main__':
    HOST = os.environ.get('SERVER_HOST', 'localhost')
    try:
        PORT = int(os.environ.get('SERVER_PORT', '5555'))
    except ValueError:
        PORT = 5555
    app.run(debug=False, host=HOST, port=PORT)
#endregion

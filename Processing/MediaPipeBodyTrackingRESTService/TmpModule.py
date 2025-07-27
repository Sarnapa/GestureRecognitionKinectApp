import cv2
import mediapipe as mp
from mediapipe import solutions
from mediapipe.framework.formats import landmark_pb2
import numpy as np


model_path = r'C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\BodyTrackingModels\Mediapipe\PoseLandmarkDetection\FromMediaPipe\pose_landmarker_full.task'
image_path = r'C:\Users\Michal\source\repos\GestureRecognitionKinectApp\Tests\Processing\MLNETProcUnit.UnitTests\Input\ColorFrame_34.png'

def draw_landmarks_on_image(rgb_image, detection_result):
  pose_landmarks_list = detection_result.pose_landmarks
  annotated_image = np.copy(rgb_image)

  # Loop through the detected poses to visualize.
  for idx in range(len(pose_landmarks_list)):
    pose_landmarks = pose_landmarks_list[idx]

    # Draw the pose landmarks.
    pose_landmarks_proto = landmark_pb2.NormalizedLandmarkList()
    pose_landmarks_proto.landmark.extend([
      landmark_pb2.NormalizedLandmark(x=landmark.x, y=landmark.y, z=landmark.z) for landmark in pose_landmarks
    ])
    solutions.drawing_utils.draw_landmarks(
      annotated_image,
      pose_landmarks_proto,
      solutions.pose.POSE_CONNECTIONS,
      solutions.drawing_styles.get_default_pose_landmarks_style())
  return annotated_image

if __name__ == '__main__':
    BaseOptions = mp.tasks.BaseOptions
    PoseLandmarker = mp.tasks.vision.PoseLandmarker
    PoseLandmarkerOptions = mp.tasks.vision.PoseLandmarkerOptions
    VisionRunningMode = mp.tasks.vision.RunningMode

    image_bgra = cv2.imread(image_path, cv2.IMREAD_UNCHANGED)
    image_rgb = cv2.cvtColor(image_bgra, cv2.COLOR_BGRA2RGB)
    image = mp.Image(image_format=mp.ImageFormat.SRGB, data=image_rgb)

    options = PoseLandmarkerOptions(
        base_options=BaseOptions(model_asset_path=model_path),
        running_mode=VisionRunningMode.IMAGE)

    with PoseLandmarker.create_from_options(options) as detector:
        detection_result = detector.detect(image)

        annotated_image = draw_landmarks_on_image(image.numpy_view(), detection_result)
        
        window_name = 'image'
        cv2.imshow(window_name, annotated_image)
        cv2.waitKey(0)
        cv2.destroyAllWindows()


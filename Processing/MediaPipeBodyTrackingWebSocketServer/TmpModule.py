import cv2
import mediapipe as mp
from mediapipe import solutions
from mediapipe.framework.formats import landmark_pb2
import numpy as np
import time

model_path = r'C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\BodyTrackingModels\Mediapipe\PoseLandmarkDetection\FromMediaPipe\pose_landmarker_full.task'
hand_model_path = r'C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\BodyTrackingModels\Mediapipe\HandLandmarkDetection\FromMediaPipe\hand_landmarker.task'
image_path = r'C:\Users\Michal\source\repos\GestureRecognitionKinectApp\Tests\Processing\MediaPipeBodyTrackingWebSocketServer.IntegrationTests\Input\ColorFrame_4.png'

# def draw_landmarks_on_image(rgb_image, detection_result):
#   pose_landmarks_list = detection_result.pose_landmarks
#   annotated_image = np.copy(rgb_image)

#   # Loop through the detected poses to visualize.
#   for idx in range(len(pose_landmarks_list)):
#     pose_landmarks = pose_landmarks_list[idx]

#     # Draw the pose landmarks.
#     pose_landmarks_proto = landmark_pb2.NormalizedLandmarkList()
#     pose_landmarks_proto.landmark.extend([
#       landmark_pb2.NormalizedLandmark(x=landmark.x, y=landmark.y, z=landmark.z) for landmark in pose_landmarks
#     ])
#     solutions.drawing_utils.draw_landmarks(
#       annotated_image,
#       pose_landmarks_proto,
#       solutions.pose.POSE_CONNECTIONS,
#       solutions.drawing_styles.geget_default_pose_landmarks_style())
#   return annotated_image

MARGIN = 10  # pixels
FONT_SIZE = 1
FONT_THICKNESS = 1
HANDEDNESS_TEXT_COLOR = (88, 205, 54) # vibrant green

def draw_landmarks_on_image(rgb_image, detection_result):
  hand_landmarks_list = detection_result.hand_landmarks
  handedness_list = detection_result.handedness
  annotated_image = np.copy(rgb_image)

  # Loop through the detected hands to visualize.
  for idx in range(len(hand_landmarks_list)):
    hand_landmarks = hand_landmarks_list[idx]
    handedness = handedness_list[idx]

    # Draw the hand landmarks.
    hand_landmarks_proto = landmark_pb2.NormalizedLandmarkList()
    hand_landmarks_proto.landmark.extend([
      landmark_pb2.NormalizedLandmark(x=landmark.x, y=landmark.y, z=landmark.z) for landmark in hand_landmarks
    ])
    solutions.drawing_utils.draw_landmarks(
      annotated_image,
      hand_landmarks_proto,
      solutions.hands.HAND_CONNECTIONS,
      solutions.drawing_styles.get_default_hand_landmarks_style(),
      solutions.drawing_styles.get_default_hand_connections_style())

    # Get the top left corner of the detected hand's bounding box.
    height, width, _ = annotated_image.shape
    x_coordinates = [landmark.x for landmark in hand_landmarks]
    y_coordinates = [landmark.y for landmark in hand_landmarks]
    text_x = int(min(x_coordinates) * width)
    text_y = int(min(y_coordinates) * height) - MARGIN

    # Draw handedness (left or right hand) on the image.
    cv2.putText(annotated_image, f"{handedness[0].category_name}",
                (text_x, text_y), cv2.FONT_HERSHEY_DUPLEX,
                FONT_SIZE, HANDEDNESS_TEXT_COLOR, FONT_THICKNESS, cv2.LINE_AA)

  return annotated_image

if __name__ == '__main__':
    # BaseOptions = mp.tasks.BaseOptions
    # PoseLandmarker = mp.tasks.vision.PoseLandmarker
    # PoseLandmarkerOptions = mp.tasks.vision.PoseLandmarkerOptions
    # VisionRunningMode = mp.tasks.vision.RunningMode

    # image_bgra = cv2.imread(image_path, cv2.IMREAD_UNCHANGED)
    # image_rgb = cv2.cvtColor(image_bgra, cv2.COLOR_BGRA2RGB)
    # image = mp.Image(image_format=mp.ImageFormat.SRGB, data=image_rgb)

    # options = PoseLandmarkerOptions(
    #     base_options=BaseOptions(model_asset_path=model_path),
    #     running_mode=VisionRunningMode.IMAGE)

    # with PoseLandmarker.create_from_options(options) as detector:
    #     detection_result = detector.detect(image)

    #     annotated_image = draw_landmarks_on_image(image.numpy_view(), detection_result)
        
    #     window_name = 'image'
    #     cv2.imshow(window_name, annotated_image)
    #     cv2.waitKey(0)
    #     cv2.destroyAllWindows()

    import mediapipe as mp
    from mediapipe.tasks import python
    from mediapipe.tasks.python import vision

    # STEP 2: Create an HandLandmarker object.
    base_options = python.BaseOptions(model_asset_path=hand_model_path)
    options = vision.HandLandmarkerOptions(base_options=base_options,
                                          num_hands=2,
                                          min_hand_detection_confidence=0.9,
                                          min_hand_presence_confidence=0.9,
                                          min_tracking_confidence=0.9)
    detector = vision.HandLandmarker.create_from_options(options)

    # STEP 3: Load the input image.
    image_bgra = cv2.imread(image_path, cv2.IMREAD_UNCHANGED)
    image_rgb = cv2.cvtColor(image_bgra, cv2.COLOR_BGRA2RGB)
    image = mp.Image(image_format=mp.ImageFormat.SRGB, data=image_rgb)

    # STEP 4: Detect hand landmarks from the input image.
    start = time.time()
    detection_result = detector.detect(image)
    finish = time.time()
    duration = finish - start
    print(f"[detect] {duration:.6f} seconds")

    # STEP 5: Process the classification result. In this case, visualize it.
    annotated_image = draw_landmarks_on_image(image.numpy_view(), detection_result)
    window_name = 'image'
    cv2.imshow(window_name, annotated_image)
    cv2.waitKey(0)
    cv2.destroyAllWindows()

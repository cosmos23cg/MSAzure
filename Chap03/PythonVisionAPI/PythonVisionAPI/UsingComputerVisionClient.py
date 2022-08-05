from azure.cognitiveservices.vision.computervision import ComputerVisionClient
from azure.cognitiveservices.vision.computervision.models import TextOperationStatusCodes
from azure.cognitiveservices.vision.computervision.models import TextRecognitionMode
from azure.cognitiveservices.vision.computervision.models import VisualFeatureTypes
from msrest.authentication import CognitiveServicesCredentials

from array import array
import os
from PIL import Image
import sys
import time

subscription_key = "f2c14565be7248769f4aa7af4455a08e"
endpoint = "https://msit12300visionapi.cognitiveservices.azure.com/"

remote_image_url = "https://raw.githubusercontent.com/Azure-Samples/cognitive-services-sample-data-files/master/ComputerVision/Images/landmark.jpg"
#remote_image_url = "https://images.chinatimes.com/newsphoto/2018-07-10/900/20180710003456.jpg"               #台北101
#remote_image_url = "https://upload.wikimedia.org/wikipedia/commons/e/eb/Mount_Rainier_from_west.jpg"         #Mountain Rainier

computervision_client = ComputerVisionClient(endpoint, CognitiveServicesCredentials(subscription_key))

#'''取得影像說明'''
#print("===== Describe an image - remote =====")
## Call API

#description_results = computervision_client.describe_image(remote_image_url)

## Get the captions (descriptions) from the response, with confidence level
#print("Description of remote image: ")
#if (len(description_results.captions) == 0):
#    print("No description detected.")
#else:
#    for caption in description_results.captions:
#        print("'{}' with confidence {:.2f}%".format(caption.text, caption.confidence * 100))

#'''
#取得影像類別
#'''
#print("===== Categorize an image - remote =====")
## Select the visual feature(s) you want.
#remote_image_features = ["categories"]
## Call API with URL and features
#categorize_results_remote = computervision_client.analyze_image(remote_image_url , remote_image_features)

## Print results with confidence score
#print("Categories from remote image: ")
#if (len(categorize_results_remote.categories) == 0):
#    print("No categories detected.")
#else:
#    for category in categorize_results_remote.categories:
#        print("'{}' with confidence {:.2f}%".format(category.name, category.score * 100))

#'''
#取得影像標籤
#'''
#print("===== Tag an image - remote =====")
## Call API with remote image
#tags_result_remote = computervision_client.tag_image(remote_image_url )

## Print results with confidence score
#print("Tags in the remote image: ")
#if (len(tags_result_remote.tags) == 0):
#    print("No tags detected.")
#else:
#    for tag in tags_result_remote.tags:
#        print("'{}' with confidence {:.2f}%".format(tag.name, tag.confidence * 100))

#'''
#偵測物件
#'''
#print("===== Detect Objects - remote =====")
## Get URL image with different objects
#remote_image_url_objects = "https://raw.githubusercontent.com/Azure-Samples/cognitive-services-sample-data-files/master/ComputerVision/Images/objects.jpg"
## Call API with URL
#detect_objects_results_remote = computervision_client.detect_objects(remote_image_url_objects)

## Print detected objects results with bounding boxes
#print("Detecting objects in remote image:")
#if len(detect_objects_results_remote.objects) == 0:
#    print("No objects detected.")
#else:
#    for object in detect_objects_results_remote.objects:
#        print("object at location {}, {}, {}, {}".format( \
#        object.rectangle.x, object.rectangle.x + object.rectangle.w, \
#        object.rectangle.y, object.rectangle.y + object.rectangle.h))

#'''
#偵測品牌
#'''
#print("===== Detect Brands - remote =====")
## Get a URL with a brand logo
#remote_image_url = "https://docs.microsoft.com/en-us/azure/cognitive-services/computer-vision/images/gray-shirt-logo.jpg"
## Select the visual feature(s) you want
#remote_image_features = ["brands"]
## Call API with URL and features
#detect_brands_results_remote = computervision_client.analyze_image(remote_image_url, remote_image_features)

#print("Detecting brands in remote image: ")
#if len(detect_brands_results_remote.brands) == 0:
#    print("No brands detected.")
#else:
#    for brand in detect_brands_results_remote.brands:
#        print("'{}' brand detected with confidence {:.1f}% at location {}, {}, {}, {}".format( \
#        brand.name, brand.confidence * 100, brand.rectangle.x, brand.rectangle.x + brand.rectangle.w, \
#        brand.rectangle.y, brand.rectangle.y + brand.rectangle.h))

#'''
#偵測臉部
#'''
#print("===== Detect Faces - remote =====")
## Get an image with faces
#remote_image_url_faces = "https://raw.githubusercontent.com/Azure-Samples/cognitive-services-sample-data-files/master/ComputerVision/Images/faces.jpg"
## Select the visual feature(s) you want.
#remote_image_features = ["faces"]
## Call the API with remote URL and features
#detect_faces_results_remote = computervision_client.analyze_image(remote_image_url_faces, remote_image_features)

## Print the results with gender, age, and bounding box
#print("Faces in the remote image: ")
#if (len(detect_faces_results_remote.faces) == 0):
#    print("No faces detected.")
#else:
#    for face in detect_faces_results_remote.faces:
#        print("'{}' of age {} at location {}, {}, {}, {}".format(face.gender, face.age, \
#        face.face_rectangle.left, face.face_rectangle.top, \
#        face.face_rectangle.left + face.face_rectangle.width, \
#        face.face_rectangle.top + face.face_rectangle.height))

'''
偵測成人、猥褻或暴力內容
'''
remote_image_url="http://images.google.com.tw/images?q=tbn:8WcLUpic1Qi0oM:http://www-etsi2.ugr.es/alumnos/mu01/img/bill-gates-tetas.jpg"
print("===== Categorize an image - remote =====")
# Select the visual feature(s) you want.
remote_image_features = ["categories"]
# Call API with URL and features
categorize_results_remote = computervision_client.analyze_image(remote_image_url , remote_image_features)

# Print results with confidence score
print("Categories from remote image: ")
if (len(categorize_results_remote.categories) == 0):
    print("No categories detected.")
else:
    for category in categorize_results_remote.categories:
        print("'{}' with confidence {:.2f}%".format(category.name, category.score * 100))

'''
Detect Adult or Racy Content - remote
This example detects adult or racy content in a remote image, then prints the adult/racy score.
The score is ranged 0.0 - 1.0 with smaller numbers indicating negative results.
'''
print("===== Detect Adult or Racy Content - remote =====")
# Select the visual feature(s) you want
remote_image_features = ["adult"]
# Call API with URL and features
detect_adult_results_remote = computervision_client.analyze_image(remote_image_url, remote_image_features)

# Print results with adult/racy score
print("Analyzing remote image for adult or racy content ... ")
print("Is adult content: {} with confidence {:.2f}".format(detect_adult_results_remote.adult.is_adult_content, detect_adult_results_remote.adult.adult_score * 100))
print("Has racy content: {} with confidence {:.2f}".format(detect_adult_results_remote.adult.is_racy_content, detect_adult_results_remote.adult.racy_score * 100))

#'''
#取得影像色彩配置
#'''
#print("===== Detect Color - remote =====")
## Select the feature(s) you want
#remote_image_features = ["color"]
## Call API with URL and features
#detect_color_results_remote = computervision_client.analyze_image(remote_image_url, remote_image_features)

## Print results of color scheme
#print("Getting color scheme of the remote image: ")
#print("Is black and white: {}".format(detect_color_results_remote.color.is_bw_img))
#print("Accent color: {}".format(detect_color_results_remote.color.accent_color))
#print("Dominant background color: {}".format(detect_color_results_remote.color.dominant_color_background))
#print("Dominant foreground color: {}".format(detect_color_results_remote.color.dominant_color_foreground))
#print("Dominant colors: {}".format(detect_color_results_remote.color.dominant_colors))

#'''
#取得特定領域內容
#'''
#print("===== Detect Domain-specific Content - remote =====")
## URL of one or more celebrities
#remote_image_url_celebs = "https://raw.githubusercontent.com/Azure-Samples/cognitive-services-sample-data-files/master/ComputerVision/Images/faces.jpg"
## Call API with content type (celebrities) and URL
#detect_domain_results_celebs_remote = computervision_client.analyze_image_by_domain("celebrities", remote_image_url_celebs)

## Print detection results with name
#print("Celebrities in the remote image:")
#if len(detect_domain_results_celebs_remote.result["celebrities"]) == 0:
#    print("No celebrities detected.")
#else:
#    for celeb in detect_domain_results_celebs_remote.result["celebrities"]:
#        print(celeb["name"])

#'''
#取得地標內容
#'''
#detect_domain_results_landmarks = computervision_client.analyze_image_by_domain("landmarks", remote_image_url)
#print()

#print("Landmarks in the remote image:")
#if len(detect_domain_results_landmarks.result["landmarks"]) == 0:
#    print("No landmarks detected.")
#else:
#    for landmark in detect_domain_results_landmarks.result["landmarks"]:
#        print(landmark["name"])

#'''
#取得影像類型
#'''
#print("===== Detect Image Types - remote =====")
## Get URL of an image with a type
#remote_image_url_type = "https://raw.githubusercontent.com/Azure-Samples/cognitive-services-sample-data-files/master/ComputerVision/Images/type-image.jpg"
## Select visual feature(s) you want
#remote_image_features = VisualFeatureTypes.image_type
## Call API with URL and features
#detect_type_results_remote = computervision_client.analyze_image(remote_image_url_type, remote_image_features)

## Prints type results with degree of accuracy
#print("Type of remote image:")
#if detect_type_results_remote.image_type.clip_art_type == 0:
#    print("Image is not clip art.")
#elif detect_type_results_remote.image_type.line_drawing_type == 1:
#    print("Image is ambiguously clip art.")
#elif detect_type_results_remote.image_type.line_drawing_type == 2:
#    print("Image is normal clip art.")
#else:
#    print("Image is good clip art.")

#if detect_type_results_remote.image_type.line_drawing_type == 0:
#    print("Image is not a line drawing.")
#else:
#    print("Image is a line drawing")

#'''
#讀取印刷, 手寫文字, 車牌
#'''
#print("===== Batch Read File - remote =====")
## Get an image with printed text
#remote_image_printed_text_url = "https://pic.pimg.tw/celsior/1387088795-214420646.jpg"

## Call API with URL and raw response (allows you to get the operation location)
#recognize_printed_results = computervision_client.batch_read_file(remote_image_printed_text_url,  raw=True)

## Get the operation location (URL with an ID at the end) from the response
#operation_location_remote = recognize_printed_results.headers["Operation-Location"]
## Grab the ID from the URL
#operation_id = operation_location_remote.split("/")[-1]

## Call the "GET" API and wait for it to retrieve the results 
#while True:
#    get_printed_text_results = computervision_client.get_read_operation_result(operation_id)
#    if get_printed_text_results.status not in ['NotStarted', 'Running']:
#        break
#    time.sleep(1)

## Print the detected text, line by line
#if get_printed_text_results.status == TextOperationStatusCodes.succeeded:
#    for text_result in get_printed_text_results.recognition_results:
#        for line in text_result.lines:
#            print(line.text)
#            print(line.bounding_box)
#print()
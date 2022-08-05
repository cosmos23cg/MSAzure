from audioop import lin2adpcm
from urllib import response
import requests
import matplotlib.pyplot as plt
from PIL import Image
from matplotlib import patches
from io import BytesIO
import operator
from pprint import pprint 

key = "a89b678b09f04424a4c8d40615896dd3"
endpoint = "https://aien1800faceservice.cognitiveservices.azure.com/face/v1.0/detect"
faceUrl= "https://images.chinatimes.com/newsphoto/2021-10-12/1024/20211012004667.jpg"


headers = {
    # Request headers
    'Content-Type': 'application/json',
    'Ocp-Apim-Subscription-Key': key,
}

params = {
    # Request parameters
    'returnFaceId': 'true',
    'returnFaceLandmarks': 'true',
    'returnFaceAttributes': 'age,gender,smile,emotion',
    'recognitionModel': 'recognition_04',
    'returnRecognitionModel': 'false',
    'detectionModel': 'detection_01',
    'faceIdTimeToLive': '86400', # 86400 is a day
}

data = {
    'url':faceUrl
}

response = requests.post(endpoint, headers=headers, params=params, json=data)
faces = response.json()
pprint(faces)

image = Image.open(BytesIO(requests.get(faceUrl).content))
plt.figure(figsize=(8,8))
ax = plt.imshow(image, alpha=0.6)


for face in faces:
    age = face["faceAttributes"]["age"]
    gender = face["faceAttributes"]["gender"]
    smile = face["faceAttributes"]["smile"]
    emotion = face["faceAttributes"]["emotion"]
    maxemotion = max(emotion.items(), key=operator.itemgetter(1))
    # print(f'Gender:{gender}, Age:{age}, Emotion:{maxemotion[0]}, Emotion Score:{maxemotion[1]*100:.2f}')
    result=(f'Gender:{gender}, Age:{age}, Emotion:{maxemotion[0]}, Emotion Score:{maxemotion[1]*100:.2f}')

    left = face["faceRectangle"]["left"]
    top = face["faceRectangle"]["top"]
    width = face["faceRectangle"]["width"]
    height = face["faceRectangle"]["height"]

    p = patches.Rectangle((left, top), width, height, fill=False, linewidth=2, color='r')
    ax.axes.add_patch(p)
    plt.text(left, top, "%s" % result, fontsize=10, va='bottom')

plt.axis('off')
plt.savefig('Face.jpg')
plt.show()
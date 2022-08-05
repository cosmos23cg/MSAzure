from audioop import lin2adpcm
from urllib import response
import requests
import matplotlib.pyplot as plt
from PIL import Image
from io import BytesIO
from pprint import pprint 

key = "cc9eaea07c9c41faab1aa7ee336f40cf"
endpoint = "https://aien1812customvision-prediction.cognitiveservices.azure.com/customvision/v3.0/Prediction/c0a8e5a8-a956-4c2e-9991-4d0df42c3fe2/classify/iterations/Iteration1/image"
imgPath = "images/fish.jpg"
imgData = open(imgPath, 'rb').read()


headers = {
    # Request headers
    'Content-Type': 'application/octet-stream', # 二進為格式
    'Prediction-Key': key,
}

params = {
    # Request parameters
    'visualFeatures': 'Tags',
    'details': 'Landmarks',
    'language': 'en',
    'model-version': 'latest',
}

response = requests.post(endpoint, headers=headers, params=params, data=imgData)
json = response.json()
pprint(json)

name = json['predictions'][0]['tagName']
probability = json['predictions'][0]['probability']

print(f'Contient:{name}, Confidence:{probability*100:.2f}%')

image = Image.open(BytesIO(imgData))
plt.figure(figsize=(8,8))
ax = plt.imshow(image)
plt.axis('off')
# plt.savefig(f'{name}.jpg')
plt.show()
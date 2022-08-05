from audioop import lin2adpcm
from urllib import response
import requests
import matplotlib.pyplot as plt
from PIL import Image
from io import BytesIO
from pprint import pprint 

key = "8dea9581759940a4b8dc02d57764c25d"
endpoint = "https://aien1812vision1.cognitiveservices.azure.com/vision/v3.2/analyze"
imgPath = "images/101.jpg"
imgData = open(imgPath, 'rb').read()


headers = {
    # Request headers
    'Content-Type': 'application/octet-stream', # 二進為格式
    'Ocp-Apim-Subscription-Key': key,
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
# pprint(json)

name = json['categories'][0]['detail']['landmarks'][0]['name']
confidence = json['categories'][0]['detail']['landmarks'][0]['confidence']

print(f'Contient:{name}, Confidence:{confidence*100:.2f}%')

image = Image.open(BytesIO(imgData))
plt.figure(figsize=(8,8))
ax = plt.imshow(image)
plt.axis('off')
# plt.savefig(f'{name}.jpg')
plt.show()
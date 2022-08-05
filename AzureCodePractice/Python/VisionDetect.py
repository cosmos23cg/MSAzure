from audioop import lin2adpcm
from urllib import response
import requests
import matplotlib.pyplot as plt
from PIL import Image
from io import BytesIO
from pprint import pprint 

key = "8dea9581759940a4b8dc02d57764c25d"
endpoint = "https://aien1812vision1.cognitiveservices.azure.com/vision/v3.2/analyze"
imgUrl= "https://content.skyscnr.com/m/1f3c2fee41869f06/original/GettyImages-536011445.jpg?resize=800px:600px&quality=100"


headers = {
    # Request headers
    'Content-Type': 'application/json',
    'Ocp-Apim-Subscription-Key': key,
}

params = {
    # Request parameters
    'visualFeatures': 'Tags',
    'details': 'Landmarks',
    'language': 'en',
    'model-version': 'latest',
}

data = {
    'url':imgUrl
}

response = requests.post(endpoint, headers=headers, params=params, json=data)
json = response.json()
pprint(json)

name = json['categories'][0]['detail']['landmarks'][0]['name']
confidence = json['categories'][0]['detail']['landmarks'][0]['confidence']

print(f'Contient:{name}, Confidence:{confidence*100:.2f}%')

image = Image.open(BytesIO(requests.get(imgUrl).content))
plt.figure(figsize=(8,8))
ax = plt.imshow(image, alpha=0.6)
plt.axis('off')
plt.savefig(f'{name}.jpg')
plt.show()
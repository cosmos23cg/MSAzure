import requests
import matplotlib as plt
from io import BytesIO
from PIL import Image
from pprint import pprint


endpoint = 'https://aien1812contentmoderator.cognitiveservices.azure.com'
key = 'a83994a5f42e4a1cba536249e5af7c3e'
imgUrl= 'https://img.ltn.com.tw/Upload/news/600/2018/05/23/2435395_4.jpg'

headers = {
    'Content-Type': 'application/json',
    'Ocp-Apim-Subscription-Key': key,
}

params = {'CacheImage':'True'}

data = {
    'DataRepresentation': 'Url',
    'Value': imgUrl,
}

response = requests.post(f'{endpoint}/contentmoderator/moderate/v1.0/ProcessImage/Evaluate', headers=headers, params=params, json=data)
result = response.json()
pprint(result)

# IsImageAdultClassified = result['IsImageAdultClassified']
# IsImageRacyClassified = result['IsImageRacyClassified']
# AdultClassificationScore = result['AdultClassificationScore']
# RacyClassificationScore = result['RacyClassificationScore']

# Adult = '成人' if IsImageAdultClassified else '非成人'
# Racy = '種族' if IsImageRacyClassified else '非種族'

# print(f'{Adult}:{AdultClassificationScore}, {Racy}:{RacyClassificationScore}')

# image = Image.open(BytesIO(requests.get(imgUrl).content))
# plt.figure(figsize=(8,8))
# ax = plt.imshow(image)
# plt.axis('off')
# plt.show

import matplotlib.pyplot as plt
import requests
from pprint import pprint
from io import BytesIO
from PIL import Image

headers = {
    # Request headers
    'Content-Type': 'application/json',
    'Prediction-Key': 'da6341161165476782dd6ff9b89accf4',
}

customvision_predict_uri="https://aien10customvision.cognitiveservices.azure.com/customvision/v3.0/Prediction/6534e9a7-374b-4a4f-9d65-5c56b1c1cdef/classify/iterations/Iteration1/url"
image_url="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSyHd2Hz7b-bVUWag1uY8MqwvzJzAJyiWKYYBXkkgeDQxdHqjGl122RRjyyJ3n1DwT7WYJzkaBULPT3BYow9HguGVAGBdblgBz9Xg&usqp=CAU&ec=45732304"

data={
    'url':image_url
    }

try:
    response=requests.post(customvision_predict_uri, headers=headers, json=data)    
    #pprint(response.json())
    predict=response["predictions"][0]["tagName"]
    confidence=response["predictions"][0]["tagName"]
    print(f"預測:{predict}, 信心指數:{confidence}")
    image=Image.open(BytesIO(requests.get(image_url).content))
    plt.figure(figsize=(8,8))
    plt.axis('off')
    plt.imshow(image)
    plt.show()

except Exception as e:
    print(e)


import requests
from pprint import pprint
import operator

import matplotlib.pyplot as plt
from PIL import Image
from matplotlib import patches
from io import BytesIO

image_url = 'https://storage.googleapis.com/www-cw-com-tw/article/202011/article-5fa78e6d8da7c.jpg'
#image_url = 'https://img-s-msn-com.akamaized.net/tenant/amp/entityid/AAG8HIc.img?h=630&w=1119&m=6&q=60&o=f&l=f&x=472&y=328'	#阿翔記者會
#image_url = 'https://www.nownews.com/wp-content/uploads/2019/08/1566376044-b9fe88e5bfaea24f2aaabc93b71a9bfd.jpg'		        #謝忻記者會

headers = {
    # Request headers
    'Content-Type': 'application/json',
    'Ocp-Apim-Subscription-Key': '28cee3eb5d654a04b9b3d76f35d1e9e2',
}

params = {
    # Request parameters
    'returnFaceId': 'true',
    'returnFaceLandmarks': 'false',
    'returnFaceAttributes': 'age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise',
    'recognitionModel': 'recognition_01',
    'returnRecognitionModel': 'false',
    'detectionModel': 'detection_01',
}

data={'url':image_url}

try:
    response = requests.post("https://aien1600face.cognitiveservices.azure.com/face/v1.0/detect", params=params, json=data, headers=headers)
    faces=response.json()
    pprint(faces)

    image = Image.open(BytesIO(requests.get(image_url).content))
    plt.figure(figsize=(8, 8))
    ax = plt.imshow(image, alpha=0.6)

    for face in faces:
        age=face["faceAttributes"]["age"]
        gender=face["faceAttributes"]["gender"]
        emotion=face["faceAttributes"]["emotion"]
        maxemotion=max(emotion.items(), key=operator.itemgetter(1))
        print(f"性別:{gender}, 年齡:{age:.0f}, 情緒:{maxemotion[0]}, 信心指數:{maxemotion[1]*100:.2f}%")

        fr = face["faceRectangle"]    
        origin = (fr["left"], fr["top"])
        p = patches.Rectangle(origin, fr["width"], fr["height"], fill=False, linewidth=2, color='b')
        ax.axes.add_patch(p)
        plt.text(origin[0], origin[1], f"{gender.capitalize()}, {age:.0f}", fontsize=20, weight="bold", va="bottom")

except Exception as e:
    print(e)
    
plt.axis("off")
plt.savefig("FaceRectangle.jpg")
plt.show()							

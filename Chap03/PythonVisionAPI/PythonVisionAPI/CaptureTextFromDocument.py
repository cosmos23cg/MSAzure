#Optical Character Recognition (https://docs.microsoft.com/zh-tw/azure/cognitive-services/computer-vision/concept-recognizing-text)
#Quickstart: Extract printed text (OCR) using the Computer Vision REST API and Python(https://github.com/Azure-Samples/cognitive-services-quickstart-code/blob/master/python/ComputerVision/REST/python-print-text.md)

import requests
# If you are using a Jupyter Notebook, uncomment the following line.
# %matplotlib inline
import matplotlib.pyplot as plt
from matplotlib.patches import Rectangle
from PIL import Image
from io import BytesIO
from pprint import pprint

subscription_key = "faa246290bb04bb1bb67006184280b26"

endpoint="https://aien1600vision.cognitiveservices.azure.com/"
endpointUrl = f'{endpoint}vision/v3.2/ocr'  

# Set image_url to the URL of an image that you want to analyze.
image_url = """https://www.fedex.com/content/dam/fedex/us-united-states/FedEx-Office/images/2018/Q4/myonlinedocuments_597267519.jpg"""

headers = {'Ocp-Apim-Subscription-Key': subscription_key}
params = {
    'language': 'unk', 
    'detectOrientation': 'true',
    'model-version': 'latest'
}
data = {'url': image_url}
response = requests.post(endpointUrl, headers=headers, params=params, json=data)
response.raise_for_status()

analysis = response.json()
pprint(analysis)

# Extract the word bounding boxes and text.
line_infos = [region["lines"] for region in analysis["regions"]]
word_infos = []
for line in line_infos:
    for word_metadata in line:
        for word_info in word_metadata["words"]:
            word_infos.append(word_info)
#print(word_infos)  
#word_infos[0]["text"]      #第1行文字

# Display the image and overlay it with the extracted text.
plt.figure(figsize=(5, 5))
image = Image.open(BytesIO(requests.get(image_url).content))
ax = plt.imshow(image, alpha=0.5)
for word in word_infos:
    bbox = [int(num) for num in word["boundingBox"].split(",")]
    text = word["text"]
    origin = (bbox[0], bbox[1])
    patch = Rectangle(origin, bbox[2], bbox[3],
                      fill=False, linewidth=2, color='y')
    ax.axes.add_patch(patch)
    plt.text(origin[0], origin[1], text, fontsize=20, weight="bold", va="top")
plt.show()
plt.axis("off")
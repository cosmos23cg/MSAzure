#Optical Character Recognition (https://docs.microsoft.com/zh-tw/azure/cognitive-services/computer-vision/concept-recognizing-text)
#Handwriting OCR API Example(https://notebooks.gesis.org/binder/jupyter/user/microsoft-cogni-e-vision-python-jieasv4e/notebooks/Jupyter%20Notebook/Handwriting%20OCR%20API%20Example.ipynb)

import json
import requests
# If you are using a Jupyter Notebook, uncomment the following line.
# %matplotlib inline
import matplotlib.pyplot as plt
from matplotlib.patches import Polygon
from PIL import Image
from io import BytesIO
from pprint import pprint

subscription_key = "bde6511880a742c192db05933c52d9c1"

endpoint="https://msit130visionservice.cognitiveservices.azure.com/"
endpointUrl = f'{endpoint}vision/v3.2/read/analyze'  

# Set image_url to the URL of an image that you want to recognize.
image_url = "https://raw.githubusercontent.com/MicrosoftDocs/azure-docs/master/articles/cognitive-services/Computer-vision/Images/readsample.jpg"
#image_url = "http://i.imgur.com/W2fF6uC.jpg"

headers = {'Ocp-Apim-Subscription-Key': subscription_key}
data = {'url': image_url}

response = requests.post(endpointUrl, headers=headers, json=data)
response.raise_for_status()

# Extracting text requires two API calls: One call to submit the
# image for processing, the other to retrieve the text found in the image.

## Holds the URI used to retrieve the recognized text.
#operation_url = response.headers["Operation-Location"]

# The recognized text isn't immediately available, so poll to wait for completion.
analysis = {}
poll = True
while (poll):
    response_final = requests.get(response.headers["Operation-Location"], headers=headers)
    analysis = response_final.json()
    
    pprint(analysis)

    if ("analyzeResult" in analysis):
        poll = False
    if ("status" in analysis and analysis['status'] == 'failed'):
        poll = False

polygons = []
if ("analyzeResult" in analysis):
    # Extract the recognized text, with bounding boxes.
    polygons = [(line["boundingBox"], line["text"])
               for line in analysis["analyzeResult"]["readResults"][0]["lines"]]

# Display the image and overlay it with the extracted text.
image = Image.open(BytesIO(requests.get(image_url).content))
ax = plt.imshow(image)
for polygon in polygons:
    vertices = [(polygon[0][i], polygon[0][i+1])
                for i in range(0, len(polygon[0]), 2)]
    text = polygon[1]
    patch = Polygon(vertices, closed=True, fill=False, linewidth=2, color='y')
    ax.axes.add_patch(patch)
    plt.text(vertices[0][0], vertices[0][1], text, fontsize=20, va="top")
plt.show()
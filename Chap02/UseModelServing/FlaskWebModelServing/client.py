from PIL import Image
import urllib.request
import sys
import requests
import io

# initialize the Keras REST API endpoint URL along with the input
# image path
REST_API_URL = "http://localhost:5555/predict"
#IMAGE_PATH = r"images\dog.jpg"

ImageFile=sys.argv[1]
payload=None

if (ImageFile.startswith("http")):                  #read url image
    image = Image.open(urllib.request.urlopen(ImageFile))     	
    buf = io.BytesIO()
    image.save(buf, format='JPEG')
    image = buf.getvalue()
    payload = {"image": image}
else:                                               #read local image
    #image = open(IMAGE_PATH, "rb").read()
    image = open(sys.argv[1], "rb").read() 	                
    payload = {"image": image}

# submit the request
r = requests.post(REST_API_URL, files=payload).json()

# ensure the request was successful
if r["success"]:
    # loop over the predictions and display them
    for (i, result) in enumerate(r["predictions"]):
        print("{}. {}: {:.4f}".format(i + 1, result["label"],
            result["probability"]))

# otherwise, the request failed
else:
    print("Request failed")
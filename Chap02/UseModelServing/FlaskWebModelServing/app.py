#Building a simple Keras + deep learning REST API
#https://blog.keras.io/building-a-simple-keras-deep-learning-rest-api.html

#from keras.applications import ResNet50
#from keras.preprocessing.image import img_to_array
#from keras.applications import imagenet_utils
from tensorflow.keras.applications import ResNet50
from tensorflow.keras.preprocessing.image import img_to_array
from tensorflow.keras.applications import imagenet_utils
from tensorflow import keras
from PIL import Image
import numpy as np
import flask
from flask_cors import CORS
import io
import os

app = flask.Flask(__name__)
CORS(app)
model = None

def prepare_image(image, target):
    # if the image mode is not RGB, convert it
    if image.mode != "RGB":
        image = image.convert("RGB")

    # resize the input image and preprocess it
    image = image.resize(target)
    image = img_to_array(image)
    image = np.expand_dims(image, axis=0)
    image = imagenet_utils.preprocess_input(image, mode="caffe")

    # return the processed image
    return image

@app.route('/test', methods=['GET'])
def test():
    return "Hello Flask"

@app.route('/predict', methods=['POST'])
def predict():
    # initialize the data dictionary that will be returned from the
    # view
    data = {"success": False}

    # ensure an image was properly uploaded to our endpoint
    if flask.request.method == "POST":
        if flask.request.files.get("image"):
            # read the image in PIL format
            image = flask.request.files["image"].read()
            image = Image.open(io.BytesIO(image))

            # preprocess the image and prepare it for classification
            image = prepare_image(image, target=(224, 224))

            # classify the input image and then initialize the list
            # of predictions to return to the client
            preds = model.predict(image)
            results = imagenet_utils.decode_predictions(preds)
            data["predictions"] = []

            # loop over the results and add them to the list of
            # returned predictions
            for (imagenetID, label, prob) in results[0]:
                r = {"label": label, "probability": float(prob)}
                data["predictions"].append(r)

            # indicate that the request was a success
            data["success"] = True

    # return the data dictionary as a JSON response
    return flask.jsonify(data)

if __name__ == '__main__':
    #model = keras.models.load_model(os.path.join(r"..\UseTensorflow", "model.h5"))
    model = ResNet50(weights="imagenet")
    app.run(port=5555)

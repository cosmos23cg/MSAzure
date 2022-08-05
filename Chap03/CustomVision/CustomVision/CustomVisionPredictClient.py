from azure.cognitiveservices.vision.customvision.training import CustomVisionTrainingClient
from azure.cognitiveservices.vision.customvision.prediction import CustomVisionPredictionClient
from azure.cognitiveservices.vision.customvision.training.models import ImageFileCreateBatch, ImageFileCreateEntry, Region
from msrest.authentication import ApiKeyCredentials

import os

# Replace with valid values
Training_ENDPOINT = "https://aien1400customvision.cognitiveservices.azure.com/"
Prediction_ENDPOINT = "https://aien1400customvision-prediction.cognitiveservices.azure.com/"
training_key = "a75f3745901e4c8981aa579eb147d52a"
prediction_key = "3c30d61f87f34065b77e8d84e21c0a64"
#Prediction_Resource_id要用[CustomVision名稱-Prediction]資源的[屬性]連結記載的resource id
prediction_resource_id = "/subscriptions/e74b39ca-f5a0-4568-8fcc-38830c6adee8/resourceGroups/AIEN1400ResourceGroup/providers/Microsoft.CognitiveServices/accounts/AIEN1400CustomVision-Prediction"
publish_iteration_name = "classifyModel"

# Now there is a trained endpoint that can be used to make a prediction
prediction_credentials = ApiKeyCredentials(in_headers={"Prediction-key": prediction_key})
predictor = CustomVisionPredictionClient(Prediction_ENDPOINT, prediction_credentials)

IMAGES_FOLDER = os.path.join(os.path.dirname(os.path.realpath(__file__)), "images")

credentials = ApiKeyCredentials(in_headers={"Training-key": training_key})
trainer = CustomVisionTrainingClient(Training_ENDPOINT, credentials)

project=""
for proj in trainer.get_projects():
        if (proj.name == "AnimalClassifierByCode"):
            project= proj

with open(IMAGES_FOLDER + "/Predict/BlackBear.jpg", "rb") as image_contents:
    results = predictor.classify_image(project.id, publish_iteration_name, image_contents.read())

# Display the results.
for prediction in results.predictions:
    print("\t" + prediction.tag_name +
            ": {0:.2f}%".format(prediction.probability * 100))

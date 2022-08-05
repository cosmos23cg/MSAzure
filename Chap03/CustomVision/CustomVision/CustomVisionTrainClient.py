from azure.cognitiveservices.vision.customvision.training import CustomVisionTrainingClient
from azure.cognitiveservices.vision.customvision.prediction import CustomVisionPredictionClient
from azure.cognitiveservices.vision.customvision.training.models import ImageFileCreateBatch, ImageFileCreateEntry, Region
from msrest.authentication import ApiKeyCredentials

import time
import os

# Replace with valid values
ENDPOINT = "https://aien10customvision.cognitiveservices.azure.com/"
training_key = "5e35ffb1c0694eb7b3ada6b02713ff73"
#Prediction_Resource_id要用[CustomVision名稱-Prediction]資源的[屬性]連結記載的resource id
prediction_resource_id = "/subscriptions/4b371d79-d24c-42b0-a6fd-8563e9491150/resourceGroups/AIEN10/providers/Microsoft.CognitiveServices/accounts/AIEN10CustomVision-Prediction"

credentials = ApiKeyCredentials(in_headers={"Training-key": training_key})
trainer = CustomVisionTrainingClient(ENDPOINT, credentials)

publish_iteration_name = "classifyModel"

trainer = CustomVisionTrainingClient(ENDPOINT, credentials)

# Create a new project
print ("Creating project...")
project = trainer.create_project("AnimalClassifierByCode")

# Make two tags in the new project
dinosaur_tag = trainer.create_tag(project.id, "恐龍")
crocodile_tag = trainer.create_tag(project.id, "鱷魚")
工讀生_tag = trainer.create_tag(project.id, "工讀生")

IMAGES_FOLDER = os.path.join(os.path.dirname(os.path.realpath(__file__)), "images")

print("Adding images...")
dinosaur_dir = os.path.join(IMAGES_FOLDER, "Dinosaur")
for image in os.listdir(dinosaur_dir):
    with open(os.path.join(dinosaur_dir, image), mode="rb") as img_data:
        trainer.create_images_from_data(
            project.id, img_data.read(), [dinosaur_tag.id])

crocodile_dir = os.path.join(IMAGES_FOLDER, "Crocodile")
for image in os.listdir(crocodile_dir):
    with open(os.path.join(crocodile_dir, image), mode="rb") as img_data:
        trainer.create_images_from_data(
            project.id, img_data.read(), [crocodile_tag.id])

工讀生_dir = os.path.join(IMAGES_FOLDER, "工讀生")
for image in os.listdir(工讀生_dir):
    with open(os.path.join(工讀生_dir, image), mode="rb") as img_data:
        trainer.create_images_from_data(
            project.id, img_data.read(), [工讀生_tag.id])

print ("Training...")
iteration = trainer.train_project(project.id)
while (iteration.status != "Completed"):
    iteration = trainer.get_iteration(project.id, iteration.id)
    print ("Training status: " + iteration.status)
    time.sleep(1)

# The iteration is now trained. Publish it to the project endpoint
trainer.publish_iteration(project.id, iteration.id, publish_iteration_name, prediction_resource_id)
print ("Done!")
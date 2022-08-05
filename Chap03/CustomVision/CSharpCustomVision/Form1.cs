using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Models;
using System.IO;
using System.Threading;

namespace CSharpCustomVision
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // You can obtain these values from the Keys and Endpoint page for your Custom Vision resource in the Azure Portal.
        private string trainingEndpoint = "https://mymlcustomvision.cognitiveservices.azure.com/";
        private string trainingKey = "6802e98854f940448cf89a9471f76f8b";
        // You can obtain these values from the Keys and Endpoint page for your Custom Vision Prediction resource in the Azure Portal.
        private string predictionEndpoint = "https://mymlcustomvision-prediction.cognitiveservices.azure.com/";
        private string predictionKey = "0ec97bada5db46b1b81e05f8d720bfea";
        // You can obtain this value from the Properties page for your Custom Vision Prediction resource in the Azure Portal. See the "Resource ID" field. This typically has a value such as:
        // #Prediction_Resource_id要用[CustomVision名稱-Prediction]資源的[屬性]連結記載的resource id
        private string predictionResourceId = "Prediction資源的resource id";

        private IEnumerable<string> CrocodileImages;
        private IEnumerable<string> DinosaurImages;
        private IEnumerable<string> WorkStudentImages;
        private Tag CrocodileTag;
        private Tag DinosaurTag;
        private Tag WorkStudentTag;
        private Iteration iteration;
        private string publishedModelName = "classifyModel";
        private MemoryStream testImage;

        private void btnCustomVisionClient_Click(object sender, EventArgs e)
        {
            frmCustomVisionClient f = new frmCustomVisionClient();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            CustomVisionTrainingClient trainingApi = AuthenticateTraining(trainingEndpoint, trainingKey);

            Project project = CreateProject(trainingApi);
            AddTags(trainingApi, project);
            UploadImages(trainingApi, project);
            TrainProject(trainingApi, project);
            PublishIteration(trainingApi, project);            
        }

        private CustomVisionTrainingClient AuthenticateTraining(string endpoint, string trainingKey)
        {
            // Create the Api, passing in the training key
            CustomVisionTrainingClient trainingApi = new CustomVisionTrainingClient(new Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.ApiKeyServiceClientCredentials(trainingKey))
            {
                Endpoint = endpoint
            };
            return trainingApi;
        }

        private Project CreateProject(CustomVisionTrainingClient trainingApi)
        {
            // Create a new project
            Console.WriteLine("Creating new project:");
            return trainingApi.CreateProject("AnimalClassifierByCode");
        }

        private void AddTags(CustomVisionTrainingClient trainingApi, Project project)
        {
            // Make two tags in the new project
            CrocodileTag = trainingApi.CreateTag(project.Id, "Crocodile");
            DinosaurTag = trainingApi.CreateTag(project.Id, "Dinosaur");
            WorkStudentTag = trainingApi.CreateTag(project.Id, "WorkStudent");
        }

        private void LoadImagesFromDisk()
        {
            // this loads the images to be uploaded from disk into memory
            CrocodileImages = Directory.EnumerateFiles(Path.Combine("images", "Crocodile"));
            DinosaurImages = Directory.EnumerateFiles(Path.Combine("images", "Dinosaur"));
            WorkStudentImages = Directory.EnumerateFiles(Path.Combine("images", "工讀生"));
        }

        private void UploadImages(CustomVisionTrainingClient trainingApi, Project project)
        {
            // Add some images to the tags
            Console.WriteLine("\tUploading images");
            LoadImagesFromDisk();

            // Images can be uploaded one at a time
            foreach (var image in CrocodileImages)
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(image)))
                {
                    trainingApi.CreateImagesFromData(project.Id, stream, new List<Guid>() { CrocodileTag.Id });
                }
            }
            foreach (var image in DinosaurImages)
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(image)))
                {
                    trainingApi.CreateImagesFromData(project.Id, stream, new List<Guid>() { DinosaurTag.Id });
                }
            }
            foreach (var image in WorkStudentImages)
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(image)))
                {
                    trainingApi.CreateImagesFromData(project.Id, stream, new List<Guid>() { WorkStudentTag.Id });
                }
            }
        }

        private void TrainProject(CustomVisionTrainingClient trainingApi, Project project)
        {
            // Now there are images with tags start training the project
            Console.WriteLine("\tTraining");
            iteration = trainingApi.TrainProject(project.Id);

            // The returned iteration will be in progress, and can be queried periodically to see when it has completed
            while (iteration.Status == "Training")
            {
                Console.WriteLine("Waiting 10 seconds for training to complete...");
                Thread.Sleep(10000);

                // Re-query the iteration to get it's updated status
                iteration = trainingApi.GetIteration(project.Id, iteration.Id);
            }
        }

        private void PublishIteration(CustomVisionTrainingClient trainingApi, Project project)
        {
            trainingApi.PublishIteration(project.Id, iteration.Id, publishedModelName, predictionResourceId);
            Console.WriteLine("Done!\n");
        }

        private CustomVisionPredictionClient AuthenticatePrediction(string endpoint, string predictionKey)
        {
            // Create a prediction endpoint, passing in the obtained prediction key
            CustomVisionPredictionClient predictionApi = new CustomVisionPredictionClient(new Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.ApiKeyServiceClientCredentials(predictionKey))
            {
                Endpoint = endpoint
            };
            return predictionApi;
        }

        private void TestIteration(CustomVisionPredictionClient predictionApi, Project project)
        {
            // Make a prediction against the new project
            Console.WriteLine("Making a prediction:");
            var result = predictionApi.ClassifyImage(project.Id, publishedModelName, testImage);

            // Loop over each prediction and write out the results
            foreach (var c in result.Predictions)
            {
                Console.WriteLine($"\t{c.TagName}: {c.Probability:P1}");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            CustomVisionTrainingClient trainingApi = AuthenticateTraining(trainingEndpoint, trainingKey);
            CustomVisionPredictionClient predictionApi = AuthenticatePrediction(predictionEndpoint, predictionKey);
            Project project = null;
            foreach (Project proj in trainingApi.GetProjects())
            {
                if (proj.Name == "AnimalClassifierByCode")
                {
                    project = proj;
                }
            }
            testImage = new MemoryStream(File.ReadAllBytes(Path.Combine("images", "Predict", "Crocodile1Q.jpg")));
            TestIteration(predictionApi, project);
            //DeleteProject(trainingApi, project);
        }

        private void btnCustomVisionClient_Click_1(object sender, EventArgs e)
        {
            frmCustomVisionClient f = new frmCustomVisionClient();
            f.ShowDialog();
            f.Dispose();
        }


        //private void DeleteProject(CustomVisionTrainingClient trainingApi, Project project)
        //{
        //    trainingApi.DeleteProjectAsync(project.Id);
        //}
    }
}

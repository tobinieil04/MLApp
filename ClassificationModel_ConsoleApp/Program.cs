
// This file was auto-generated by ML.NET Model Builder. 

using ClassificationModel_ConsoleApp;
using System.IO;

// Create single instance of sample data from first line of dataset for model input
var imageBytes = File.ReadAllBytes(@"C:\Users\tobin\Downloads\archive (2)\dataset\training_set\cats\cat.1.jpg");
ClassificationModel.ModelInput sampleData = new ClassificationModel.ModelInput()
{
    ImageSource = imageBytes
};

// Make a single prediction on the sample data and print results.
var predictionResult = ClassificationModel.Predict(sampleData);
Console.WriteLine($"\n\nPredicted Label value: {predictionResult.PredictedLabel} \nPredicted Label scores: [{String.Join(",", predictionResult.Score)}]\n\n");

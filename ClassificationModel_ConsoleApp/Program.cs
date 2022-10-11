﻿using ClassificationModel_ConsoleApp;
using Microsoft.VisualBasic;
using System.IO;

while (true)
{
    try
    {
        Console.Clear();
        Console.WriteLine("Please drag file: ");
        string path = Console.ReadLine();
        byte[] file = File.ReadAllBytes(path);
        ClassificationModel.ModelInput sampleData = new ClassificationModel.ModelInput()
        {
            ImageSource = file
        };
            var predictionResult = ClassificationModel.Predict(sampleData);
        Console.Clear();
        Console.WriteLine($"\n\nPredicted Label value: {predictionResult.PredictedLabel} \nPredicted score Dog: {Convert.ToDecimal(predictionResult.Score[0] * 100).ToString("0.00")}%\nPredicted score Cat: {Convert.ToDecimal(predictionResult.Score[1] * 100).ToString("0.00")}%\n\n");
        Console.ReadKey();
    }
    catch (Exception)
    {
        Console.Clear();
        Console.WriteLine("Please input something");
        Thread.Sleep(2000);
    }
}





// Create single instance of sample data from first line of dataset for model input


// Make a single prediction on the sample data and print results.

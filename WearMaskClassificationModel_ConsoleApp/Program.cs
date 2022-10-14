
using WearMaskClassificationModel_ConsoleApp;

while (true)
{
    try
    {
        Console.Clear();
        Console.Write("Please drag file: ");
        string path = Console.ReadLine();
        byte[] file = File.ReadAllBytes(path);
        ClassificationModel.ModelInput sampleData = new ClassificationModel.ModelInput()
        {
            ImageSource = file
        };
        var predictionResult = ClassificationModel.Predict(sampleData);
        Console.Clear();
        Console.WriteLine($"\n\nPredicted Label value: {predictionResult.PredictedLabel}\nWears mask incorrectly: {Math.Round(predictionResult.Score[0] * 100, 2)}%\nWears mask: {Math.Round(predictionResult.Score[2] * 100, 2)}%\nDoes not wear mask: {Math.Round(predictionResult.Score[1] * 100, 2)}%\n\n");
        Console.ReadKey();
    }
    catch (Exception)
    {
        Console.Clear();
        Console.WriteLine("Please input something");
        Thread.Sleep(2000);
    }
}
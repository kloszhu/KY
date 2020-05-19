using Microsoft.ML;
using Microsoft.ML.Data;
using System;

namespace KY.ML
{
    public class MLTest
    {
        public MLContext Test()
        {
            var dataPath = "sentiment.csv";
            var mlContext = new MLContext();
            var loader = mlContext.Data.CreateTextLoader(new[]
                {
        new TextLoader.Column("SentimentText", DataKind.String, 1),
        new TextLoader.Column("Label", DataKind.Boolean, 0),
    },
                hasHeader: true,
                separatorChar: ',');
            var data = loader.Load(dataPath);
            var learningPipeline = mlContext.Transforms.Text.FeaturizeText("Features", "SentimentText")
                    .Append(mlContext.BinaryClassification.Trainers.FastTree());
            var model = learningPipeline.Fit(data);
            return mlContext;
        }

        //public void Test2()
        //{
        //    var mlContext = Test();
        //    var predictionEngine = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
        //    var prediction = predictionEngine.Predict(new SentimentData
        //    {
        //        SentimentText = "Today is a great day!"
        //    });
        //    Console.WriteLine("prediction: " + prediction.Prediction);
        //}
    }
}

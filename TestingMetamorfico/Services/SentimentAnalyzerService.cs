using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using TestingMetamorfico.Constants;
using TestingMetamorfico.Models;
using static Microsoft.ML.DataOperationsCatalog;

namespace TestingMetamorfico.Services
{
    public class SentimentAnalyzerService
    {
        public TrainTestData LoadData(MLContext mlContext, string dataPath)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentData>(dataPath, hasHeader: false);

            TrainTestData splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);

            return splitDataView;
        }

        public ITransformer BuildAndTrainModel(MLContext mlContext, IDataView splitTrainSet)
        {
            var estimator = mlContext.Transforms.Text
                .FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

            Console.WriteLine("=============== Create and Train the Model ===============");
            var model = estimator.Fit(splitTrainSet);
            Console.WriteLine("=============== End of training ===============");
            Console.WriteLine();

            return model;
        }

        public void Evaluate(MLContext mlContext, ITransformer model, IDataView splitTestSet)
        {
            Console.WriteLine("=============== Evaluating Model accuracy with Test data===============");
            IDataView predictions = model.Transform(splitTestSet);

            CalibratedBinaryClassificationMetrics metrics = mlContext.BinaryClassification.Evaluate(predictions, "Label");

            Console.WriteLine();
            Console.WriteLine("Model quality metrics evaluation");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"Auc: {metrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
            Console.WriteLine("=============== End of model evaluation ===============");
        }

        public PredictionResult UseModelWithSingleItem(MLContext mlContext, ITransformer model, string text)
        {
            PredictionEngine<SentimentData, SentimentPrediction> predictionFunction = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);

            SentimentData sampleStatement = new SentimentData
            {
                SentimentText = text
            };

            var resultPrediction = predictionFunction.Predict(sampleStatement);

            return new PredictionResult()
            {
                Prediction = Convert.ToBoolean(resultPrediction.Prediction) ? Result.Positive : Result.Negative,
                Probability = resultPrediction.Probability
            };
        }
    }
}

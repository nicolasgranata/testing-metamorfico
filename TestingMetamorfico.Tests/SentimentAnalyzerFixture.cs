using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestingMetamorfico.Services;
using static Microsoft.ML.DataOperationsCatalog;

namespace TestingMetamorfico.Tests
{
    public class SentimentAnalyzerFixture
    {
        private readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "yelp_labelled.txt");
       
        public MLContext MlContext { get; }
        public ITransformer Model { get; }
        public SentimentAnalyzerService SentimentAnalyzerService { get; }

        public SentimentAnalyzerFixture()
        {
            MlContext = new MLContext();

            SentimentAnalyzerService = new SentimentAnalyzerService();

            TrainTestData splitDataView = SentimentAnalyzerService.LoadData(MlContext, _dataPath);

            Model = SentimentAnalyzerService.BuildAndTrainModel(MlContext, splitDataView.TrainSet);

            SentimentAnalyzerService.Evaluate(MlContext, Model, splitDataView.TestSet);
        }
    }
}

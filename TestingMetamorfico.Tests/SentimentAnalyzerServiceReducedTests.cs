using TestingMetamorfico.Constants;
using Xunit;

namespace TestingMetamorfico.Tests
{
    public class SentimentAnalyzerServiceReducedTests : IClassFixture<SentimentAnalyzerFixture>
    {
        private readonly SentimentAnalyzerFixture _fixture;

        public SentimentAnalyzerServiceReducedTests(SentimentAnalyzerFixture fixture)
        {
            _fixture = fixture;
        }

        #region MR1
        [Fact]
        public void MR1Iteration1Test()
        {
            // Arrange
            var input1 = @"El “chocomensaje” es buenísimo!!";
            var input2 = @"El “chocomensaje” es estupendo!!";

            // Act Source test case
            var resultIteration1 = _fixture.SentimentAnalyzerService
                .UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input1);
            // Act Follow-up test case
            var resultIteration2 = _fixture.SentimentAnalyzerService
                .UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input2);

            // Metamorphic relation #1 assertion
            Assert.Equal(Result.Positive, resultIteration1.Prediction);
            Assert.Equal(Result.Positive, resultIteration2.Prediction);
        }

        [Fact]
        public void MR1Iteration2Test()
        {
            // Arrange
            var input1 = @"Nooo no podes seguir privándote de esas delicias. Los churros son todos ricos, dulces o salados. La sensación que te da cuando los mordes, es algo inexplicable. ¡Tenes que probarlos!";
            var input2 = @"Nooo no podes seguir privándote de esas delicias. Los churros son todos sabrosos, dulces o salados. La sensación que te da cuando los mordes, es algo indescriptible¡Tenes que probarlos!";

            // Act Source test case
            var resultIteration1 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input1);
            // Act Follow-up test case
            var resultIteration2 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input2);

            // Metamorphic relation #1 assertion
            Assert.Equal(Result.Positive, resultIteration1.Prediction);
            Assert.Equal(Result.Positive, resultIteration2.Prediction);
        }
        #endregion

        #region MR2
        [Fact]
        public void MR2Iteration1Test()
        {
            // Arrange
            var input1 = "El “chocomensaje” es buenísimo!!";
            var input2 = "Es buenísimo el “chocomensaje”!!";


            // Act Source test case
            var resultIteration1 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input1);
            // Act Follow-up test case
            var resultIteration2 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input2);

            // Metamorphic relation #1 assertion
            Assert.Equal(Result.Positive, resultIteration1.Prediction);
            Assert.Equal(Result.Positive, resultIteration2.Prediction);
        }

        [Fact]
        public void MR2Iteration2Test()
        {
            // Arrange
            var input1 = @"Claro, es una verguenza el servicio que tienen. 0 barras de señal. Y encima me subis a 1300 pesos el abono. Una solución?";
            var input2 = @"Claro, 0 barras de señal. Una solución? Y encima me subis a 1300 pesos el abono, es una verguenza el servicio que tienen.";

            // Act Source test case
            var resultIteration1 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input1);
            // Act Follow-up test case
            var resultIteration2 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input2);

            // Metamorphic relation #1 assertion
            Assert.Equal(Result.Negative, resultIteration1.Prediction);
            Assert.Equal(Result.Negative, resultIteration2.Prediction);
        }
        #endregion

        #region MR3
        [Fact]
        public void MR3Iteration1Test()
        {
            // Arrange
            var input1 = "me pedí unas pastitas, excelente servicio, vinieron con pancito casero y queso rallado viva l'italia";
            var input2 = "me pedí unas pastitas, mal servicio, vinieron con pancito casero y queso rallado viva l'italia";


            // Act Source test case
            var resultIteration1 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input1);
            // Act Follow-up test case
            var resultIteration2 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input2);

            // Metamorphic relation #1 assertion
            Assert.Equal(Result.Positive, resultIteration1.Prediction);
            Assert.Equal(Result.Negative, resultIteration2.Prediction);
        }

        [Fact]
        public void MR3Iteration2Test()
        {
            // Arrange
            var input1 = "horrible atención al cliente. Nunca mas.";
            var input2 = "buena atención al cliente. Siempre mas.";

            // Act Source test case
            var resultIteration1 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input1);
            // Act Follow-up test case
            var resultIteration2 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input2);

            // Metamorphic relation #1 assertion
            Assert.Equal(Result.Negative, resultIteration1.Prediction);
            Assert.Equal(Result.Positive, resultIteration2.Prediction);
        }
        #endregion
    }
}

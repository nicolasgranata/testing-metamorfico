using TestingMetamorfico.Constants;
using Xunit;

namespace TestingMetamorfico.Tests
{
    public class SentimentAnalyzerServiceTest : IClassFixture<SentimentAnalyzerFixture>
    {
        private readonly SentimentAnalyzerFixture _fixture;

        public SentimentAnalyzerServiceTest(SentimentAnalyzerFixture fixture)
        {
            _fixture = fixture;
        }

        #region MR1
        [Fact]
        public void MR1Iteration1Test()
        {
            // Arrange
            var input1 = @"@MovistarArg son un desastre, nunca tengan un problema con 
                            estos tipos porque no te lo solucionan";
            var input2 = @"@MovistarArg son una calamidad, nunca tengan un problema con 
                            estos tipos porque no te lo solucionan";

            // Act Source test case
            var resultIteration1 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input1);
            // Act Follow-up test case
            var resultIteration2 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input2);

            // Metamorphic relation #1 assertion
            Assert.Equal(Result.Negative, resultIteration1.Prediction);
            Assert.Equal(Result.Negative, resultIteration2.Prediction);
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
            var input1 = @"@ClaroArgentina Claro, es una verguenza el servicio que tienen. 0 barras de señal. Y encima me subis a 1300 pesos el abono. Una solución?";
            var input2 = @"@ClaroArgentina Claro, 0 barras de señal. Una solución? Y encima me subis a 1300 pesos el abono, es una verguenza el servicio que tienen.";

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
            var input1 = "me pedí unas pastitas por rappi, excelente servicio, vinieron con pancito casero y queso rallado viva l'italia";
            var input2 = "me pedí unas pastitas por rappi, mal servicio, vinieron con pancito casero y queso rallado viva l'italia";


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
            var input1 = "@pedidosya horrible atención al cliente. Nunca mas.";
            var input2 = "@pedidosya buena atención al cliente. Siempre mas.";

            // Act Source test case
            var resultIteration1 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input1);
            // Act Follow-up test case
            var resultIteration2 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input2);

            // Metamorphic relation #1 assertion
            Assert.Equal(Result.Negative, resultIteration1.Prediction);
            Assert.Equal(Result.Positive, resultIteration2.Prediction);
        }
        #endregion

        #region MR4
        [Fact]
        public void MR4Iteration1Test()
        {
            // Arrange
            var input1 = "El “chocomensaje” es buenísimo!!";
            var input2 = "El “chocomensaje” no es buenísimo!!";


            // Act Source test case
            var resultIteration1 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input1);
            // Act Follow-up test case
            var resultIteration2 = _fixture.SentimentAnalyzerService.UseModelWithSingleItem(_fixture.MlContext, _fixture.Model, input2);

            // Metamorphic relation #1 assertion
            Assert.Equal(Result.Positive, resultIteration1.Prediction);
            Assert.Equal(Result.Negative, resultIteration2.Prediction);
        }

        [Fact]
        public void MR4Iteration2Test()
        {
            // Arrange
            var input1 = "@CorreoOficialSA va a ser un mes que envié un paquete a Catamarca y aún no llega , no me responden por redes , ni por mail ni por teléfono , estan dando un servicio malísimo , y sigo esperando una respuesta !";
            var input2 = "@CorreoOficialSA va a ser un mes que envié un paquete a Catamarca y ya llegó , me responden por redes , por mail y por teléfono , estan dando un servicio que no es malísimo , y no sigo esperando una respuesta !";

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

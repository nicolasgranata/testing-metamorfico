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
            var input1 = @"Nooo no podes seguir priv�ndote de esas delicias. Los churros son todos ricos, dulces o salados. La sensaci�n que te da cuando los mordes, es algo inexplicable. �Tenes que probarlos!";
            var input2 = @"Nooo no podes seguir priv�ndote de esas delicias. Los churros son todos sabrosos, dulces o salados. La sensaci�n que te da cuando los mordes, es algo indescriptible�Tenes que probarlos!";

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
            var input1 = "El �chocomensaje� es buen�simo!!";
            var input2 = "Es buen�simo el �chocomensaje�!!";


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
            var input1 = @"@ClaroArgentina Claro, es una verguenza el servicio que tienen. 0 barras de se�al. Y encima me subis a 1300 pesos el abono. Una soluci�n?";
            var input2 = @"@ClaroArgentina Claro, 0 barras de se�al. Una soluci�n? Y encima me subis a 1300 pesos el abono, es una verguenza el servicio que tienen.";

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
            var input1 = "me ped� unas pastitas por rappi, excelente servicio, vinieron con pancito casero y queso rallado viva l'italia";
            var input2 = "me ped� unas pastitas por rappi, mal servicio, vinieron con pancito casero y queso rallado viva l'italia";


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
            var input1 = "@pedidosya horrible atenci�n al cliente. Nunca mas.";
            var input2 = "@pedidosya buena atenci�n al cliente. Siempre mas.";

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
            var input1 = "El �chocomensaje� es buen�simo!!";
            var input2 = "El �chocomensaje� no es buen�simo!!";


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
            var input1 = "@CorreoOficialSA va a ser un mes que envi� un paquete a Catamarca y a�n no llega , no me responden por redes , ni por mail ni por tel�fono , estan dando un servicio mal�simo , y sigo esperando una respuesta !";
            var input2 = "@CorreoOficialSA va a ser un mes que envi� un paquete a Catamarca y ya lleg� , me responden por redes , por mail y por tel�fono , estan dando un servicio que no es mal�simo , y no sigo esperando una respuesta !";

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

using TestingMetamorfico.Services;
using Xunit;

namespace TestingMetamorfico.Tests
{
    public class SearchServiceTest
    {
        [Fact]
        public void MR1Iteration1Test()
        {
            // Arrange
            var searchService = new SearchService();
            var input1 = "big data aplicado al marketing digital";
            var input2 = "“big data aplicado al marketing digital”";

            // Act Source test case
            var resultIteration1 = searchService.CountSearchResults(input1);
            // Act Follow-up test case
            var resultIteration2 = searchService.CountSearchResults(input2);

            // Metamorphic relation #1 assertion
            Assert.True(resultIteration1 > resultIteration2);
        }
    }
}



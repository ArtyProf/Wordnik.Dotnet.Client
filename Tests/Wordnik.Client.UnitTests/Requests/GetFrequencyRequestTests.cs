using Wordnik.Client.Requests;

namespace Wordnik.Client.UnitTests.Requests;

public class GetFrequencyRequestTests
{
    [Theory]
    [InlineData(
            // Case 1: All default values
            "test", false, 0, 0,
            "word=test"
        )]
    [InlineData(
            // Case 2: Include canonical form only
            "example", true, 0, 0,
            "word=example&useCanonical=True"
        )]
    [InlineData(
            // Case 3: Skip and limit set
            "sample", false, 5, 10,
            "word=sample&skip=5&limit=10"
        )]
    [InlineData(
            // Case 4: Only skip set
            "word", false, 7, 0,
            "word=word&skip=7"
        )]
    [InlineData(
            // Case 5: Only limit set
            "data", false, 0, 15,
            "word=data&limit=15"
        )]
    public void ToString_ShouldGenerateCorrectQueryString(
            string word,
            bool useCanonical,
            int skip,
            int limit,
            string expectedQueryString)
    {
        // Arrange
        var request = new GetFrequencyRequest
        {
            Word = word,
            UseCanonical = useCanonical,
            Skip = skip,
            Limit = limit,
        };

        // Act
        var queryString = request.ToString();

        // Assert
        Assert.Equal(expectedQueryString, queryString);
    }
}

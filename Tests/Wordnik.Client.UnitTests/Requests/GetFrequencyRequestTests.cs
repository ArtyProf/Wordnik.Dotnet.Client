using Wordnik.Client.Requests;

namespace Wordnik.Client.UnitTests.Requests;

public class GetFrequencyRequestTests
{
    [Theory]
    [InlineData(
            "apple", false, 1900, 2000,
            "word=apple&useCanonical=false&startYear=1900&endYear=2000"
        )]
    [InlineData(
            "ball", true, null, null,
            "word=ball&useCanonical=true"
        )]
    [InlineData(
            "car", null, null, null,
            "word=car"
        )]
    [InlineData(
            "data", null, null, 2015,
            "word=data&endYear=2015"
        )]
    [InlineData(
            "example", true, 1800, null,
            "word=example&useCanonical=true&startYear=1800"
        )]
    public void ToString_ShouldGenerateCorrectQueryString(
        string word,
        bool? useCanonical,
        int? startYear,
        int? endYear,
        string expectedQueryString)
    {
        // Arrange
        var request = new GetFrequencyRequest
        {
            Word = word,
            UseCanonical = useCanonical,
            StartYear = startYear,
            EndYear = endYear
        };

        // Act
        var queryString = request.ToString();

        // Assert
        Assert.Equal(expectedQueryString, queryString);
    }
}

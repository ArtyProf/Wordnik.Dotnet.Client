using Wordnik.Client.Requests;

namespace Wordnik.Client.UnitTests.Requests;

public class GetExamplesRequestTests
{
    [Theory]
    [InlineData(
            // Case 1: All default values
            "test", null, null, null, null,
            "word=test"
        )]
    [InlineData(
            // Case 2: Include duplicates with canonical
            "example", true, true, null, null,
            "word=example&includeDuplicates=True&useCanonical=True"
        )]
    [InlineData(
            // Case 3: Skip and limit set
            "word", false, false, 5, 10,
            "word=word&includeDuplicates=False&useCanonical=False&skip=5&limit=10"
        )]
    [InlineData(
            // Case 4: Include limit only
            "sample", null, null, null, 7,
            "word=sample&limit=7"
        )]
    [InlineData(
            // Case 5: Only canonical form
            "example", null, true, null, null,
            "word=example&useCanonical=True"
        )]
    public void ToString_ShouldGenerateCorrectQueryString(
            string word,
            bool? includeDuplicates,
            bool? useCanonical,
            int? skip,
            int? limit,
            string expectedQueryString)
    {
        // Arrange
        var request = new GetExamplesRequest
        {
            Word = word,
            IncludeDuplicates = includeDuplicates,
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

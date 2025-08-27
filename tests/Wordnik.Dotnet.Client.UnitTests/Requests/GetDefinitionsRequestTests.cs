using Wordnik.Dotnet.Client.Enums;
using Wordnik.Dotnet.Client.Requests;

namespace Wordnik.Dotnet.Client.UnitTests.Requests
{
    public class GetDefinitionsRequestTests
    {
        [Theory]
        [InlineData(
            // Case 1: Default values
            "example", 10, "false", "false", "false",
            new PartOfSpeechType[] { PartOfSpeechType.Noun, PartOfSpeechType.Adverb },
            new SourceDictionariesType[] { SourceDictionariesType.Wordnet, SourceDictionariesType.Wiktionary },
            "limit=10&partOfSpeech=noun,adverb&includeRelated=false&sourceDictionaries=wordnet,wiktionary&useCanonical=false&includeTags=false"
        )]
        [InlineData(
            // Case 2: Empty parts of speech and dictionaries
            "example2", 5, "false", "false", "false",
            new PartOfSpeechType[] { },
            new SourceDictionariesType[] { },
            "limit=5&includeRelated=false&useCanonical=false&includeTags=false"
        )]
        [InlineData(
            // Case 3: Single source dictionary and part of speech
            "word", 1, "true", "false", "true",
            new PartOfSpeechType[] { PartOfSpeechType.Adjective },
            new SourceDictionariesType[] { SourceDictionariesType.Wiktionary },
            "limit=1&partOfSpeech=adjective&includeRelated=true&sourceDictionaries=wiktionary&useCanonical=false&includeTags=true"
        )]
        [InlineData(
            // Case 4: No limit set
            "test", 0, "false", "true", "false",
            new PartOfSpeechType[] { PartOfSpeechType.Verb },
            new SourceDictionariesType[] { SourceDictionariesType.Wordnet },
            "partOfSpeech=verb&includeRelated=false&sourceDictionaries=wordnet&useCanonical=true&includeTags=false"
        )]
        public void ToString_ShouldGenerateCorrectQueryString(
            string word,
            int limit,
            string includeRelated,
            string useCanonical,
            string includeTags,
            PartOfSpeechType[] partOfSpeechTypes,
            SourceDictionariesType[] sourceDictionaries,
            string expectedQueryString)
        {
            // Arrange
            var request = new GetDefinitionsRequest
            {
                Word = word,
                Limit = limit,
                PartOfSpeech = [.. partOfSpeechTypes],
                SourceDictionaries = [.. sourceDictionaries],
                UseCanonical = bool.Parse(useCanonical),
                IncludeRelated = bool.Parse(includeRelated),
                IncludeTags = bool.Parse(includeTags)
            };

            // Act
            var queryString = request.ToString();

            // Assert
            Assert.Equal(expectedQueryString, queryString);
        }
    }
}
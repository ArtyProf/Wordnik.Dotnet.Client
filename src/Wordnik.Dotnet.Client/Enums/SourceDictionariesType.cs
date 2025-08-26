using System.ComponentModel.DataAnnotations;

namespace Wordnik.Dotnet.Client.Enums
{
    /// <summary>
    /// Enum representing valid source dictionaries for definitions.
    /// </summary>
    public enum SourceDictionariesType
    {
        [Display(Name = "all")] All,
        [Display(Name = "ahd-5")] Ahd5,
        [Display(Name = "century")] Century,
        [Display(Name = "wiktionary")] Wiktionary,
        [Display(Name = "webster")] Webster,
        [Display(Name = "wordnet")] Wordnet
    }
}
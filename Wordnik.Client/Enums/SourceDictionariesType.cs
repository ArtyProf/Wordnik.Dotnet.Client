using System.ComponentModel.DataAnnotations;

namespace Wordnik.Client.Enums
{
    /// <summary>
    /// Enum representing valid source dictionaries for definitions.
    /// </summary>
    public enum SourceDictionariesType
    {
        /// <summary>
        /// Represents all available source dictionaries.
        /// </summary>
        [Display(Name = "all")]
        All,

        /// <summary>
        /// Represents the American Heritage Dictionary of the English Language, 5th edition (ahd-5).
        /// </summary>
        [Display(Name = "ahd-5")]
        Ahd5,

        /// <summary>
        /// Represents The Century Dictionary and Cyclopedia (century).
        /// </summary>
        [Display(Name = "century")]
        Century,

        /// <summary>
        /// Represents Wiktionary, the free dictionary that anyone can edit (wiktionary).
        /// </summary>
        [Display(Name = "wiktionary")]
        Wiktionary,

        /// <summary>
        /// Represents Webster's Dictionary (webster).
        /// </summary>
        [Display(Name = "webster")]
        Webster,

        /// <summary>
        /// Represents WordNet, a lexical database for the English language (wordnet).
        /// </summary>
        [Display(Name = "wordnet")]
        Wordnet
    }
}
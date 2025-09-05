using System.ComponentModel.DataAnnotations;

namespace Wordnik.Client.Enums
{
    /// <summary>
    /// Enum representing valid parts of speech for Wordnik definitions.
    /// </summary>
    public enum PartOfSpeechType
    {
        /// <summary>
        /// Represents a noun (e.g., "cat", "tree").
        /// </summary>
        [Display(Name = "noun")]
        Noun,

        /// <summary>
        /// Represents an adjective (e.g., "beautiful", "happy").
        /// </summary>
        [Display(Name = "adjective")]
        Adjective,

        /// <summary>
        /// Represents a verb (e.g., "run", "think").
        /// </summary>
        [Display(Name = "verb")]
        Verb,

        /// <summary>
        /// Represents an adverb (e.g., "quickly", "slowly").
        /// </summary>
        [Display(Name = "adverb")]
        Adverb,

        /// <summary>
        /// Represents an interjection (e.g., "wow!", "oops!").
        /// </summary>
        [Display(Name = "interjection")]
        Interjection,

        /// <summary>
        /// Represents a pronoun (e.g., "he", "they").
        /// </summary>
        [Display(Name = "pronoun")]
        Pronoun,

        /// <summary>
        /// Represents a preposition (e.g., "on", "in").
        /// </summary>
        [Display(Name = "preposition")]
        Preposition,

        /// <summary>
        /// Represents an abbreviation (e.g., "Dr.", "etc.").
        /// </summary>
        [Display(Name = "abbreviation")]
        Abbreviation,

        /// <summary>
        /// Represents an affix used to modify or create a derivative (e.g., "un-", "-ment").
        /// </summary>
        [Display(Name = "affix")]
        Affix,

        /// <summary>
        /// Represents an article (e.g., "the", "a").
        /// </summary>
        [Display(Name = "article")]
        Article,

        /// <summary>
        /// Represents an auxiliary verb (e.g., "is", "have").
        /// </summary>
        [Display(Name = "auxiliary-verb")]
        AuxiliaryVerb,

        /// <summary>
        /// Represents a conjunction (e.g., "and", "but").
        /// </summary>
        [Display(Name = "conjunction")]
        Conjunction,

        /// <summary>
        /// Represents a definite article (e.g., "the").
        /// </summary>
        [Display(Name = "definite-article")]
        DefiniteArticle,

        /// <summary>
        /// Represents a family name (e.g., "Smith", "Garcia").
        /// </summary>
        [Display(Name = "family-name")]
        FamilyName,

        /// <summary>
        /// Represents a given name (e.g., "John", "Maria").
        /// </summary>
        [Display(Name = "given-name")]
        GivenName,

        /// <summary>
        /// Represents an idiom (e.g., "kick the bucket").
        /// </summary>
        [Display(Name = "idiom")]
        Idiom,

        /// <summary>
        /// Represents the imperative mood of a verb (e.g., "Go!").
        /// </summary>
        [Display(Name = "imperative")]
        Imperative,

        /// <summary>
        /// Represents plural forms of a noun (e.g., "cats", "trees").
        /// </summary>
        [Display(Name = "noun-plural")]
        NounPlural,

        /// <summary>
        /// Represents the possessive form of a noun (e.g., "cat's").
        /// </summary>
        [Display(Name = "noun-possessive")]
        NounPossessive,

        /// <summary>
        /// Represents the past participle form of a verb (e.g., "eaten", "spoken").
        /// </summary>
        [Display(Name = "past-participle")]
        PastParticiple,

        /// <summary>
        /// Represents phrasal prefixes used in compound words (e.g., "over-", "under-").
        /// </summary>
        [Display(Name = "phrasal-prefix")]
        PhrasalPrefix,

        /// <summary>
        /// Represents a proper noun (e.g., "Paris", "Amazon").
        /// </summary>
        [Display(Name = "proper-noun")]
        ProperNoun,

        /// <summary>
        /// Represents the plural form of a proper noun (e.g., "Smiths").
        /// </summary>
        [Display(Name = "proper-noun-plural")]
        ProperNounPlural,

        /// <summary>
        /// Represents the possessive form of a proper noun (e.g., "Smith's").
        /// </summary>
        [Display(Name = "proper-noun-possessive")]
        ProperNounPossessive,

        /// <summary>
        /// Represents a suffix used to modify or create a derivative (e.g., "-ly", "-ness").
        /// </summary>
        [Display(Name = "suffix")]
        Suffix,

        /// <summary>
        /// Represents an intransitive verb that does not take a direct object (e.g., "arrive").
        /// </summary>
        [Display(Name = "verb-intransitive")]
        VerbIntransitive,

        /// <summary>
        /// Represents a transitive verb that requires a direct object (e.g., "throw").
        /// </summary>
        [Display(Name = "verb-transitive")]
        VerbTransitive
    }
}
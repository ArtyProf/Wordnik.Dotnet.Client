using System.ComponentModel.DataAnnotations;

namespace Wordnik.Dotnet.Client.Enums
{
    /// <summary>
    /// Enum representing valid parts of speech for Wordnik definitions.
    /// </summary>
    public enum PartOfSpeechType
    {
        [Display(Name = "noun")] Noun,
        [Display(Name = "adjective")] Adjective,
        [Display(Name = "verb")] Verb,
        [Display(Name = "adverb")] Adverb,
        [Display(Name = "interjection")] Interjection,
        [Display(Name = "pronoun")] Pronoun,
        [Display(Name = "preposition")] Preposition,
        [Display(Name = "abbreviation")] Abbreviation,
        [Display(Name = "affix")] Affix,
        [Display(Name = "article")] Article,
        [Display(Name = "auxiliary-verb")] AuxiliaryVerb,
        [Display(Name = "conjunction")] Conjunction,
        [Display(Name = "definite-article")] DefiniteArticle,
        [Display(Name = "family-name")] FamilyName,
        [Display(Name = "given-name")] GivenName,
        [Display(Name = "idiom")] Idiom,
        [Display(Name = "imperative")] Imperative,
        [Display(Name = "noun-plural")] NounPlural,
        [Display(Name = "noun-possessive")] NounPossessive,
        [Display(Name = "past-participle")] PastParticiple,
        [Display(Name = "phrasal-prefix")] PhrasalPrefix,
        [Display(Name = "proper-noun")] ProperNoun,
        [Display(Name = "proper-noun-plural")] ProperNounPlural,
        [Display(Name = "proper-noun-possessive")] ProperNounPossessive,
        [Display(Name = "suffix")] Suffix,
        [Display(Name = "verb-intransitive")] VerbIntransitive,
        [Display(Name = "verb-transitive")] VerbTransitive
    }
}
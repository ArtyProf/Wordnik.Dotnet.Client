namespace Wordnik.Client.Requests
{
    /// <summary>
    /// Defines a request containing a `Word` property required for Wordnik operations.
    /// </summary>
    public interface IWord
    {
        /// <summary>
        /// Gets or sets the word to perform the API operation on.
        /// </summary>
        string Word { get; set; }
    }
}

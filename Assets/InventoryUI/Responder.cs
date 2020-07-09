namespace Sakura.Interactions
{
    /// <summary>
    /// Responds to UI events.
    /// </summary>
    public interface Responder<T>
    {
        /// <summary>
        /// Respond to an event involving the given parameter.
        /// </summary>
        /// <param name="t">The event parameter.</param>
        void RespondTo(T t);
    }
}

using System;

namespace Sakura.Identifiers.Client
{
    /// <summary>
    ///     The exception that is thrown when an entity ID has already been
    ///     claimed by a game object.
    /// </summary>
    public sealed class EntityIdAlreadyClaimed : Exception
    {
        private const string defaultMessage =
            "The given entity ID is already claimed.";

        /// <summary>
        ///     Create a new entity ID already claimed exception with the
        ///     default message.
        /// </summary>
        public EntityIdAlreadyClaimed()
            : base (defaultMessage)
        {
        }

        /// <summary>
        ///     Create a new entity ID already claimed exception with a custom
        ///     message.
        /// </summary>
        /// <param name="message">
        ///     The custom message.
        /// </param>
        public EntityIdAlreadyClaimed(string message)
            : base(String.Format("{0} - {1}", message, defaultMessage))
        {
        }

        /// <summary>
        ///     Create a new entity ID already claimed exception with a custom
        ///     message and an inner exception.
        /// </summary>
        /// <param name="message">
        ///     The custom message.
        /// </param>
        /// <param name="inner">
        ///     The inner exception.
        /// </param>
        public EntityIdAlreadyClaimed(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

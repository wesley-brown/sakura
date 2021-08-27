using System;

namespace Sakura.Core
{
    /// <summary>
    ///     A displacement of a body through world space.
    /// </summary>
    public sealed class MovementTemp
    {
        /// <summary>
        ///     Create a movement for a given body.
        /// </summary>
        /// <param name="body">
        ///     The body.
        /// </param>
        /// <returns>
        ///     A movement for the given body.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given body is null.
        /// </exception>
        public static MovementTemp For(BodyTemp body)
        {
            if (body == null)
            {
                throw new ArgumentNullException(
                    nameof(body),
                    "The given body must not be null.");
            }
            throw new NotImplementedException();
        }
    }
}

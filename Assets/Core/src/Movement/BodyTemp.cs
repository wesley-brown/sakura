using System;
using UnityEngine;

namespace Sakura.Core
{
    /// <summary>
    ///     A physical representation of an entity.
    /// </summary>
    public sealed class BodyTemp
    {
        /// <summary>
        ///     Create a body for an entity at a given location.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <param name="location">
        ///     The location.
        /// </param>
        /// <returns>
        ///     A body for the given entity at the given location.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the given entity is the nil entity.
        /// </exception>
        public static BodyTemp ForEntityLocatedAt(
            Guid entity,
            Vector3 location)
        {
            if (entity == Guid.Empty)
                throw new ArgumentException(
                    "The nil entity cannot have a body.",
                    nameof(entity));
            return null;
        }
    }
}

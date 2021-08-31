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
            return new BodyTemp(
                entity,
                location);
        }

        private BodyTemp(
            Guid entity,
            Vector3 location)
        {
            Debug.Assert(entity != Guid.Empty);
            this.entity = entity;
            this.location = location;
        }

        private readonly Guid entity;
        private readonly Vector3 location;

        /// <summary>
        ///     Teleport this body to a given location.
        /// </summary>
        /// <param name="location">
        ///     The location to teleport to.
        /// </param>
        /// <returns>
        ///     A body at the given location.
        /// </returns>
        public BodyTemp TeleportTo(Vector3 location)
        {
            return new BodyTemp(
                entity,
                location);
        }

        public override string ToString()
        {
            return "{"
                + "Entity="
                + Entity
                + ", Location="
                + Location
                + "}";
        }

        /// <summary>
        ///     The entity this body is a physical representation of.
        /// </summary>
        public Guid Entity
        {
            get
            {
                return entity;
            }
        }

        /// <summary>
        ///     The world space location of this body.
        /// </summary>
        public Vector3 Location
        {
            get
            {
                return new Vector3(
                    location.x,
                    location.y,
                    location.z);
            }
        }
    }
}

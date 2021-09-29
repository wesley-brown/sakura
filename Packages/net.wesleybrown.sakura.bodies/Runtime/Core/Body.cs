using System;
using UnityEngine;

namespace Sakura.Bodies.Core
{
    /// <summary>
    ///     A physical representation of an entity.
    /// </summary>
    sealed class Body
    {
        /// <summary>
        ///     Create a <see cref="Body"/> for an entity at a given location.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <param name="location">
        ///     The location.
        /// </param>
        /// <returns>
        ///     A <see cref="Body"/> for the given entity at the given
        ///     location.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the given entity is the nil entity.
        /// </exception>
        internal static Body ForEntityLocatedAt(
            Guid entity,
            Vector3 location)
        {
            if (entity == Guid.Empty)
                throw new ArgumentException(
                    "The nil entity cannot have a body.",
                    nameof(entity));
            return new Body(
                entity,
                location);
        }

        private Body(
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
        ///     Teleport this <see cref="Body"/> to a given location.
        /// </summary>
        /// <param name="location">
        ///     The location to teleport to.
        /// </param>
        /// <returns>
        ///     A <see cref="Body"/> at the given location.
        /// </returns>
        internal Body TeleportTo(Vector3 location)
        {
            return new Body(
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
        ///     The entity this <see cref="Body"/> is a physical representation
        ///     of.
        /// </summary>
        public Guid Entity
        {
            get
            {
                return entity;
            }
        }

        /// <summary>
        ///     The world space location of this <see cref="Body"/>.
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

using System;
using UnityEngine;

namespace Sakura.Core
{
    /// <summary>
    ///     A physical representation of an entity.
    /// </summary>
    public sealed class Body
    {
        private readonly Guid entityID;
        private readonly Vector3 location;
        private readonly string test;

        /// <summary>
        ///     Create a new body with a given entity ID and a given location.
        /// </summary>
        /// <param name="entityID">
        ///     The entity ID.
        /// </param>
        /// <param name="location">
        ///     The location.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Thrown when the given entity ID is the nil UUID.
        /// </exception>
        public Body(
            Guid entityID,
            Vector3 location)
        {
            if (entityID == Guid.Empty)
                throw new ArgumentException(
                    "A body must not be created with the nil UUID",
                    nameof(entityID));
            this.entityID = entityID;
            this.location = location;
        }

        public Guid EntityID()
        {
            return entityID;
        }

        public Vector3 Location()
        {
            return location;
        }

        /// <summary>
        ///     Create a new <see cref="Body"/> representing the same entity as
        ///     this instance that moves to a given location.
        /// </summary>
        /// <param name="location">
        ///     The location of the new <see cref="Body"/>.
        /// </param>
        /// <returns>
        ///     A new <see cref="Body"/> representing the same entity as this
        ///     instance that has been moved to the given location.
        /// </returns>
        public Body MoveTo(Vector3 location)
        {
            return new Body(
                EntityID(),
                location);
        }

        public override string ToString()
        {
            return "{"
                + "EntityID="
                + EntityID()
                + ", Location="
                + Location()
                + "}";
        }

        public override int GetHashCode()
        {
            // Joshua Bloch's hash code recipe from Effective Java, 3rd
            // Edition, page 53.
            var hashCode = entityID.GetHashCode();
            hashCode = 31 * hashCode + location.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var otherBody = (Body)obj;
                return (entityID == otherBody.entityID)
                    && (location == otherBody.location);
            }
        }
    }
}

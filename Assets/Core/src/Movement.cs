using UnityEngine;

namespace Sakura.Core
{
    /// <summary>
    ///     An act of moving a body to a location.
    /// </summary>
    public sealed class Movement
    {
        /// <summary>
        ///     Create a new movement for moving a given body to a given
        ///     location.
        /// </summary>
        /// <param name="body">
        ///     The body to move.
        /// </param>
        /// <param name="location">
        ///     The location to move the body to.
        /// </param>
        /// <returns>
        ///     A new movement that represents the act of moving the given body
        ///     to the given location.
        /// </returns>
        public static Movement For(
            Body body,
            Vector3 location)
        {
            return new Movement(body, location);
        }

        private readonly Body body;
        private readonly Vector3 location;

        private Movement(
            Body body,
            Vector3 location)
        {
            this.body = body;
            this.location = location;
        }

        public Body Body()
        {
            return body;
        }

        public Vector3 Location()
        {
            return location;
        }

        public override int GetHashCode()
        {
            // Joshua Bloch's hash code recipe from Effective Java, 3rd
            // Edition, page 53.
            var hashCode = body.GetHashCode();
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
                var otherMovement = (Movement)obj;
                return (body.Equals(otherMovement.Body()))
                    && (location.Equals(otherMovement.Location()));
            }
        }

        public override string ToString()
        {
            return "{"
                + "Body="
                + Body()
                + ", Location="
                + Location()
                + "}";
        }
    }
}

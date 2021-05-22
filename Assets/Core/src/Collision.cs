using System;
using Sakura.Movements;

namespace Sakura.Collisions
{
    public sealed class Collision
    {
        private readonly Movement movement;
        private readonly Body body;

        public Collision(
            Movement movement,
            Body body)
        {
            if (movement == null)
                throw new ArgumentNullException(
                    nameof(movement),
                    "The given movement must not be null");
            this.movement = movement;
            if (body == null)
                throw new ArgumentNullException(
                    nameof(body),
                    "The given body must not be null");
            this.body = body;
        }

        public Movement Movement()
        {
            return movement;
        }

        public Body Body()
        {
            return body;
        }

        public override string ToString()
        {
            return "{"
                + "Movement="
                + Movement()
                + ", Body="
                + Body()
                + "}";
        }

        public override int GetHashCode()
        {
            // Joshua Bloch's hash code recipe from Effective Java, 3rd
            // Edition, page 53.
            var hashCode = movement.GetHashCode();
            hashCode = 31 * hashCode + body.GetHashCode();
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
                var otherCollision = (Collision)obj;
                return (movement.Equals(otherCollision.movement))
                    && (body.Equals(otherCollision.body));
            }
        }
    }
}

using System;

namespace Sakura.Core
{
    public sealed class NewCollision
    {
        private readonly Movement movement;
        private readonly Body body;

        public NewCollision(
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
    }
}

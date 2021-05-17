using System;

namespace Sakura.Core
{
    public sealed class NewCollision
    {
        public NewCollision(
            Movement movement,
            Body body)
        {
            if (movement == null)
                throw new ArgumentNullException(
                    nameof(movement),
                    "The given movement must not be null");
        }
    }
}

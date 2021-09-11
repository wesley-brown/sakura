using System;
using Sakura.Core;

namespace Sakura.Movements
{
    /// <summary>
    ///     A collection of movements that always has no movements for any
    ///     query.
    /// </summary>
    public sealed class NeverMoving : AllMovements
    {
        public bool HasMovement(Guid entityID)
        {
            return false;
        }

        public Movement For(Guid entityID)
        {
            throw new InvalidOperationException(
                "The entity with ID '"
                + entityID
                + "' has no movement.");
        }
    }
}

using System;

namespace Sakura.Core.Bodies
{
    /// <summary>
    ///     A physical representation of an entity.
    /// </summary>
    public sealed class Body
    {
        /// <summary>
        ///     Create a new body with a given entity ID.
        /// </summary>
        /// <param name="entityID">
        ///     The entity ID.
        /// </param>
        public Body(Guid entityID)
        {
            if (entityID == Guid.Empty)
                throw new ArgumentException(
                    "A body must not be created with the nil UUID",
                    nameof(entityID));
        }
    }
}

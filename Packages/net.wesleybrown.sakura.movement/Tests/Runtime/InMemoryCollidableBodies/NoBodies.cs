using System;
using Sakura.Core;
using Sakura.Data;

namespace In_Memory_Collidable_Bodies_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="Bodies"/> that will never have
    ///     any <see cref="Body"/>s in it.
    /// </summary>
    sealed class NoBodies : Bodies
    {
        /// <summary>
        ///     Add a given <see cref="Body"/> to this <see cref="Bodies"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/> to add.
        /// </param>
        public void AddBody(Body body)
        {
            // No-op
        }

        /// <summary>
        ///     The <see cref="Body"/> for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     Always returns null.
        /// </returns>
        public Body BodyForEntity(Guid entity)
        {
            return null;
        }
    }
}

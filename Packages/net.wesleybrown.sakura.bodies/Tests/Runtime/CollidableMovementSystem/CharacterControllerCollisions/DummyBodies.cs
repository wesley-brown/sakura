using System;
using Sakura.Core;
using Sakura.Bodies.CollidableMovement.Data;

namespace Character_Controller_Collisions_Spec
{
    /// <summary>
    ///     A dummy test double for a <see cref="Bodies"/>.
    /// </summary>
    sealed class DummyBodies : Bodies
    {
        /// <summary>
        ///     Add a given <see cref="Body"/> to this <see cref="Bodies"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/> to add.
        /// </param>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public void AddBody(Body body)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     The <see cref="Body"/> for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     Never returns.
        /// </returns>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public Body BodyForEntity(Guid entity)
        {
            throw new NotImplementedException();
        }
    }
}

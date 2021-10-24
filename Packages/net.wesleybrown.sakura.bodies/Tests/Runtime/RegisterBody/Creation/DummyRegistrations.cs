using System;
using Sakura.Bodies.Core;
using Sakura.Bodies.RegisterBody;

namespace Register_Body_System_Spec
{
    /// <summary>
    ///     A dummy test double for a <see cref="Registrations"/>.
    /// </summary>
    internal sealed class DummyRegistrations : Registrations
    {
        /// <summary>
        ///     Whether or not there is already a <see cref="Body"/>
        ///     registered for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity to check for a registred <see cref="Body"/>.
        /// </param>
        /// <returns>
        ///     Never returns.
        /// </returns>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public bool HasBodyFor(Guid entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Add a <see cref="Body"/> that represents a given entity.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/>.
        /// </param>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public void Add(
            Body body,
            Guid entity)
        {
            throw new NotImplementedException();
        }
    }
}

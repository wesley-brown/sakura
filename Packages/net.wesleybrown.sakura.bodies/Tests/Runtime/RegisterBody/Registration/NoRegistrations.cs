using System;
using Sakura.Bodies.Core;
using Sakura.Bodies.RegisterBody;

namespace Register_Body_System_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="Registrations"/> that never
    ///     has any registrations.
    /// </summary>
    internal sealed class NoRegistrations : Registrations
    {
        /// <summary>
        ///     Whether or not there is already a <see cref="Body"/>
        ///     registered for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity to check for a registred <see cref="Body"/>.
        /// </param>
        /// <returns>
        ///     Always returns false.
        /// </returns>
        public bool HasBodyFor(Guid entity)
        {
            return false;
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
        public void Add(
            Body body,
            Guid entity)
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
        ///     The <see cref="Body"/> for the given entity if there is one;
        ///     null otherwise.
        /// </returns>
        public Body BodyFor(Guid entity)
        {
            throw new NotImplementedException();
        }
    }
}

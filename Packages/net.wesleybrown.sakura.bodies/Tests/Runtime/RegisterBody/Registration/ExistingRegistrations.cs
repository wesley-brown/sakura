using System;
using Sakura.Bodies.Core;
using Sakura.Bodies.RegisterBody;

namespace Register_Body_System_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="Registrations"/> that has
    ///     existing registrations.
    /// </summary>
    sealed class ExistingRegistrations : Registrations
    {
        /// <summary>
        ///     Whether or not there is already a <see cref="Body"/>
        ///     registered for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity to check for a registred <see cref="Body"/>.
        /// </param>
        /// <returns>
        ///     Always returns true.
        /// </returns>
        public bool HasBodyFor(Guid entity)
        {
            return true;
        }

        /// <inheritdoc/>
        public void Add(
            Body body,
            Guid entity)
        {
            throw new InvalidOperationException();
        }
    }
}

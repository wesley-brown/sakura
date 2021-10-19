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
    }
}

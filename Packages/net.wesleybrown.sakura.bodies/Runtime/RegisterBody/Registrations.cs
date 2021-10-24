using System;
using Sakura.Bodies.Core;

namespace Sakura.Bodies.RegisterBody
{
    /// <summary>
    ///     A collection of <see cref="Body"/>s and which entities they
    ///     represent.
    /// </summary>
    internal interface Registrations
    {
        /// <summary>
        ///     Whether or not there is already a <see cref="Body"/>
        ///     registered for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity to check for a registred <see cref="Body"/>.
        /// </param>
        /// <returns>
        ///     True if the given entity has a registred <see cref="Body"/>;
        ///     false otherwise.
        /// </returns>
        bool HasBodyFor(Guid entity);

        /// <summary>
        ///     Add a <see cref="Body"/> that represents a given entity.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/>.
        /// </param>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the given entity already has a <see cref="Body"/>
        ///     registered for it.
        /// </exception>
        void Add(
            Body body,
            Guid entity);
    }
}

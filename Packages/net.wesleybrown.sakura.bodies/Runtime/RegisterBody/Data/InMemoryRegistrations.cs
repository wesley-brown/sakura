using System;
using System.Collections.Generic;
using Sakura.Bodies.Core;

namespace Sakura.Bodies.RegisterBody.Data
{
    /// <summary>
    ///     A <see cref="Registrations"/> that stores all its data in memory.
    /// </summary>
    sealed class InMemoryRegistrations : Registrations
    {
        /// <summary>
        ///     Create a <see cref="InMemoryRegistrations"/> made of a given
        ///     dictionary.
        /// </summary>
        /// <param name="dictionary">
        ///     The dictionary.
        /// </param>
        /// <returns>
        ///     A <see cref="InMemoryRegistrations"/> made of the given
        ///     dictionary.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given dictionary is null.
        /// </exception>
        internal static InMemoryRegistrations Of(
            Dictionary<Guid, Body> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            throw new ArgumentNullException();
        }

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
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the given entity already has a <see cref="Body"/>
        ///     registered for it.
        /// </exception>
        public void Add(
            Body body,
            Guid entity)
        {
            throw new NotImplementedException();
        }
    }
}

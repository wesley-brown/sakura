using System;
using System.Collections.Generic;
using Sakura.Bodies.Core;
using UnityEngine;

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
            Dictionary<Guid, Vector3> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            return new InMemoryRegistrations(dictionary);
        }

        private InMemoryRegistrations(Dictionary<Guid, Vector3> bodies)
        {
            Debug.Assert(bodies != null);
            this.bodies = bodies;
        }

        private readonly Dictionary<Guid, Vector3> bodies;

        /// <inheritdoc/>
        public bool HasBodyFor(Guid entity)
        {
            return bodies.ContainsKey(entity);
        }

        /// <inheritdoc/>
        public void Add(
            Body body,
            Guid entity)
        {
            if (HasBodyFor(entity))
                throw new InvalidOperationException(
                    $"The entity '{entity}' already has a registered body.");
            bodies.Add(
                entity,
                body.Location);
        }

        /// <inheritdoc/>
        public Body BodyFor(Guid entity)
        {
            if (!HasBodyFor(entity))
                throw new InvalidOperationException(
                    $"The entity '{entity}' does not have a registered body.");
            var body = Body.ForEntityLocatedAt(
                entity,
                bodies[entity]);
            return body;
        }
    }
}

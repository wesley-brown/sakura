using System;
using System.Collections.Generic;
using Sakura.Core;
using UnityEngine;

namespace Sakura.Bodies.CollidableMovement.Data
{
    /// <summary>
	///     A <see cref="Bodies"/> that stores all <see cref="Body"/>s in
    ///     memory.
	/// </summary>
    sealed class InMemoryBodies : Bodies
    {
        /// <summary>
        ///     Create a <see cref="InMemoryBodies"/> that has no bodies in it.
        /// </summary>
        /// <returns>
        ///     An empty <see cref="InMemoryBodies"/>.
        /// </returns>
        internal static InMemoryBodies Empty()
        {
            return From(new Dictionary<Guid, Vector3>());
        }

        /// <summary>
        ///     Create a <see cref="InMemoryBodies"/> from a given
        ///     dictionary.
        /// </summary>
        /// <param name="dictionary">
        ///     The dictionary.
        /// </param>
        /// <returns>
        ///     A <see cref="InMemoryBodies"/> created from the given
        ///     dictionary.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given dictionary is null.
        /// </exception>
        internal static InMemoryBodies From(
            Dictionary<Guid, Vector3> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            return new InMemoryBodies(dictionary);
        }

        private InMemoryBodies(Dictionary<Guid, Vector3> dictionary)
        {
            Debug.Assert(dictionary != null);
            bodies = new Dictionary<Guid, Body>();
            foreach (var entry in dictionary)
            {
                var body = Body.ForEntityLocatedAt(
                    entry.Key,
                    entry.Value);
                bodies.Add(entry.Key, body);
            }
        }

        private readonly Dictionary<Guid, Body> bodies;

        /// <summary>
		///     Add a given <see cref="Body"/> to this
        ///     <see cref="InMemoryBodies"/>.
		/// </summary>
		/// <param name="body">
        ///     The <see cref="Body"/> to add.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="Body"/> is null.
        /// </exception>
        public void AddBody(Body body)
        {
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            var entity = body.Entity;
            if (HaveBodyForEntity(entity))
                bodies.Remove(entity);
            bodies.Add(body.Entity, body);
        }

        private bool HaveBodyForEntity(Guid entity)
        {
            return bodies.ContainsKey(entity);
        }

        /// <summary>
        ///     The <see cref="Body"/> for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     The <see cref="Body"/> for the given entity, if it exists;
        ///     null otherwise.
        /// </returns>
        public Body BodyForEntity(Guid entity)
        {
            if (!HaveBodyForEntity(entity))
                return null;
            return bodies[entity];
        }
    }
}

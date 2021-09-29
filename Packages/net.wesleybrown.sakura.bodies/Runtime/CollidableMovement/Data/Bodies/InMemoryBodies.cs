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
            return From(new Dictionary<Guid, Body>());
        }

        /// <summary>
        ///     Create a <see cref="InMemoryBodies"/> from a given
        ///     <see cref="Dictionary{TKey, TValue}"/> with keys of type
        ///     <typeparamref name="Guid"/> and values of type
        ///     <typeparamref name="Body"/>.
        /// </summary>
        /// <param name="dictionary">
        ///     The <see cref="Dictionary{TKey, TValue}"/> with keys of type
        ///     <typeparamref name="Guid"/> and values of type
        ///     <typeparamref name="Body"/>.
        /// </param>
        /// <returns>
        ///     A <see cref="InMemoryBodies"/> from the given
        ///     <see cref="Dictionary{TKey, TValue}"/> with keys of type
        ///     <typeparamref name="Guid"/> and values of type
        ///     <typeparamref name="Body"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="Dictionary{TKey, TValue}"/>
        ///     with keys of type <typeparamref name="Guid"/> and values of
        ///     type <typeparamref name="Body"/> is null.
        /// </exception>
        internal static InMemoryBodies From(Dictionary<Guid, Body> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            return new InMemoryBodies(dictionary);
        }

        private InMemoryBodies(Dictionary<Guid, Body> bodies)
        {
            Debug.Assert(bodies != null);
            this.bodies = new Dictionary<Guid, Body>(bodies);
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

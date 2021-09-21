using System;
using System.Collections.Generic;
using Sakura.Core;

namespace Sakura.Data
{
    /// <summary>
	///     A <see cref="Bodies"/> that stores all <see cref="Body"/>s in
    ///     memory.
	/// </summary>
    sealed class InMemoryBodies : Bodies
    {
        /// <summary>
		///     Create a new <see cref="InMemoryBodies"/>.
		/// </summary>
        internal InMemoryBodies()
        {
            bodies = new Dictionary<Guid, Body>();
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

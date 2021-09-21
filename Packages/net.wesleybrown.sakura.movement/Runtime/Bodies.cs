using System;
using System.Collections.Generic;
using Sakura.Core;

namespace Sakura.Data
{
    /// <summary>
	///     A collection of <see cref="Body"/>s.
	/// </summary>
    sealed class Bodies
    {
        /// <summary>
		///     Create a new <see cref="Bodies"/>.
		/// </summary>
        internal Bodies()
        {
            bodies = new Dictionary<Guid, Body>();
        }

        private readonly Dictionary<Guid, Body> bodies;

        /// <summary>
		///     Add a given <see cref="Body"/> to this <see cref="Bodies"/>.
		/// </summary>
		/// <param name="body"></param>
        internal void AddBody(Body body)
        {
            try
            {
                bodies.Add(body.Entity, body);
            }
            catch (ArgumentNullException)
            {
                throw new NotImplementedException();
            }
            catch (ArgumentException)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///     The <see cref="Body"/> for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     The <see cref="Body"/> for the given entity.
        /// </returns>
        internal Body BodyForEntity(Guid entity)
        {
            try
            {
                return bodies[entity];
            }
            catch (ArgumentNullException)
            {
                throw new NotImplementedException();
            }
            catch (ArgumentException)
            {
                throw new NotImplementedException();
            }
        }
    }
}

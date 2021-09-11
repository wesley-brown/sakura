using System;
using System.Collections.Generic;
using Sakura.Core;

namespace Sakura.Movements
{
    /// <summary>
    ///     A collection of bodies that uses a dictionary internally.
    /// </summary>
    /// <remarks>
    ///     A dictionary body collection only stores its dictionary in-memory
    ///     and does not write it out to persistent storage.
    /// </remarks>
    public sealed class DictionaryBodyCollection : AllBodies
    {
        private readonly Dictionary<Guid, Body> bodies;

        /// <summary>
        ///     Create a new empty dictionary body collection.
        /// </summary>
        /// <returns>
        ///     An emtpy dictionary body collection.
        /// </returns>
        public static DictionaryBodyCollection Empty()
        {
            return new DictionaryBodyCollection(new Dictionary<Guid, Body>());
        }

        private DictionaryBodyCollection(Dictionary<Guid, Body> bodies)
        {
            this.bodies = bodies;
        }

        public bool HasBodyFor(Guid entityID)
        {
            return bodies.ContainsKey(entityID);
        }

        public void Add(Body body)
        {
            bodies.Add(body.Entity, body);
        }

        public Body For(Guid entityID)
        {
            return bodies[entityID];
        }
    }
}

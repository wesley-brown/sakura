using System;
using UnityEngine;

namespace Sakura.Bodies.RegisterBody
{
    /// <summary>
    ///     A system that registers bodies to entities.
    /// </summary>
    public interface System
    {
        /// <summary>
        ///     Register a body at a given location for a given entity.
        /// <param name="bodyLocation">
        ///     The location of the body to register.
        /// </param>
        /// <param name="entity">
        ///     The entity to register for.
        /// </param>
        void Register(
            Vector3 bodyLocation,
            Guid entity);
    }
}

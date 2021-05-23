using System;
using UnityEngine;

namespace Sakura.Movements
{
    /// <summary>
    ///     A collection of movements that always returns a movement for any
    ///     query.
    /// </summary>
    public sealed class AlwaysMoving : AllMovements
    {
        private readonly Guid entityID;

        public AlwaysMoving()
        {
            entityID = new Guid("510830c3-0b88-47e6-b5cf-420043779f84");
        }

        public Guid EntityID
        {
            get
            {
                return entityID;
            }
        }

        public bool HasMovement(Guid entityID)
        {
            return true;
        }

        public Movement For(Guid entityID)
        {
            var location = new Vector3(10.0f, 10.0f, 10.0f);
            var body = new Body(
                this.entityID,
                location);
            var destination = new Vector3(11.0f, 10.0f, 10.0f);
            return Movement.For(
                body,
                destination);
        }
    }
}

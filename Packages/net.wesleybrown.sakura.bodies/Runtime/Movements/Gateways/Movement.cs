using UnityEngine;

namespace Sakura.Bodies.Movements.Gateways
{
    /// <summary>
    /// A serialized movement.
    /// </summary>
    public struct Movement
    {
        /// <summary>
        /// The destination of this movement.
        /// </summary>
        public Vector3 Destination { get; set; }

        /// <summary>
        /// The speed of this movement.
        /// </summary>
        public float MovementSpeed { get; set; }
    }
}

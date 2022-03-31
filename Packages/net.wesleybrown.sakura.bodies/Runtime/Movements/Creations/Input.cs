using UnityEngine;

namespace Sakura.Bodies.Movements.Creations
{
    /// <summary>
    ///     The data passed to the input port of a movement creation system.
    ///     Data describing how to move a given entity.
    /// </summary>
    public sealed class Input
    {
        /// <summary>
        ///     The ID of the entity to move.
        /// </summary>
        public string Entity { get; set; }

        /// <summary>
        ///     The destination to move the entity towards.
        /// </summary>
        public Vector3 Destination { get; set; }

        /// <summary>
        ///     How many meters per second to move the given entity towards the
        ///     given destination in a single tick.
        /// </summary>
        public float SpeedMetersPerSecond { get; set; }

        /// <summary>
        ///     The time the move was made.
        /// </summary>
        public float Timestamp { get; set; }
    }
}

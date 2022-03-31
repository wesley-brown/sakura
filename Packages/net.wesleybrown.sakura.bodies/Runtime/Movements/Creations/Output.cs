using UnityEngine;

namespace Sakura.Bodies.Movements.Creations
{
    /// <summary>
    ///     The data passed to the output port of a movement creation system.
    /// </summary>
    public sealed class Output
    {
        /// <summary>
        ///     The ID of the entity the movement was created for.
        /// </summary>
        public string Entity { get; set; }

        /// <summary>
        ///     The destination that the entity was moved towards.
        /// </summary>
        public Vector3 Destination { get; set; }

        /// <summary>
        ///     The speed at which the movement was made in meters per second.
        /// </summary>
        public float SpeedMetersPerSecond { get; set; }
    }
}

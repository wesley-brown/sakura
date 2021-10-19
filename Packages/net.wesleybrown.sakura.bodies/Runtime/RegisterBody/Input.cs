using System;

namespace Sakura.Bodies.RegisterBody
{
    /// <summary>
    ///     The input boundary data structure for a <see cref="System"/>.
    /// </summary>
    public sealed class Input
    {
        /// <summary>
        ///     The entity to register a body for.
        /// </summary>
        public Guid Entity { get; set; }

        /// <summary>
        ///     The location of the body to register for the body.
        /// </summary>
        public UnityEngine.Vector3 BodyLocation { get; set; }
    }
}

using System;

namespace Sakura.Bodies.RegisterBody
{
    /// <summary>
    ///     The output boundary data structure for a <see cref="System"/>.
    /// </summary>
    public sealed class Output
    {
        /// <summary>
        ///     The entity, if any, that a body was registered for.
        /// </summary>
        public Guid Entity { get; set; }

        /// <summary>
        ///     The location of the body, if any, that was registered for a
        ///     body.
        /// </summary>
        public UnityEngine.Vector3 BodyLocation { get; set; }
    }
}

using System;
using System.Collections.Generic;

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
        public Guid? Entity { get; set; }

        /// <summary>
        ///     The location of the body, if any, that was registered for a
        ///     body.
        /// </summary>
        public UnityEngine.Vector3? BodyLocation { get; set; }

        /// <summary>
        ///     The errors that occured while validating the given
        ///     <see cref="Input"/>.
        /// </summary>
        public List<string> InputErrors { get; set; } = new List<string>();

        /// <summary>
        ///     The errors that occured while processing the given
        ///     <see cref="Input"/>.
        /// </summary>
        public List<string> OutputErrors { get; set; } = new List<string>();
    }
}

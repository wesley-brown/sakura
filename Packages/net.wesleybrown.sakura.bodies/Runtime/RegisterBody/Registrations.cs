using System;
using Sakura.Bodies.Core;

namespace Sakura.Bodies.RegisterBody
{
    /// <summary>
    ///     A collection of <see cref="Body"/>s and which entities they
    ///     represent.
    /// </summary>
    internal interface Registrations
    {
        /// <summary>
        ///     Add a <see cref="Body"/> that represents a given entity.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/>.
        /// </param>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        void Add(
            Body body,
            Guid entity);
    }
}

using System;
using Sakura.Bodies.Core;

namespace Sakura.Bodies.CollidableMovement.Data
{
    /// <summary>
	///     A collection of <see cref="Body"/>s.
	/// </summary>
    internal interface Bodies
    {
        /// <summary>
		///     Add a given <see cref="Body"/> to this <see cref="Bodies"/>.
		/// </summary>
		/// <param name="body">
        ///     The <see cref="Body"/> to add.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="Body"/> is null.
        /// </exception>
        void AddBody(Body body);

        /// <summary>
        ///     The <see cref="Body"/> for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     The <see cref="Body"/> for the given entity, if it exists;
        ///     null otherwise.
        /// </returns>
        Body BodyForEntity(Guid entity);
    }
}

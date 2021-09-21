using System;
using UnityEngine;

namespace Sakura.Data
{
    /// <summary>
    ///     A <see cref="Collisions"/> that uses a
    ///     <see cref="CharacterController"/>.
    /// </summary>
    sealed class CharacterControllerCollisions : Collisions
    {
        /// <summary>
        ///     Create a <see cref="CharacterControllerCollisions"/> with a
        ///     given <see cref="CharacterController"/> and
        ///     <see cref="Bodies"/>.
        /// </summary>
        /// <param name="controller">
        ///     The <see cref="CharacterController"/>.
        /// </param>
        /// <param name="bodies">
        ///     The <see cref="Bodies"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="CharacterController"/> is
        ///     null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given <see cref="Bodies"/> is null.
        /// </exception>
        internal static CharacterControllerCollisions WithControllerAndBodies(
            CharacterController controller,
            Bodies bodies)
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));
            if (bodies == null)
                throw new ArgumentNullException(nameof(bodies));
            throw new NotImplementedException();
        }
    }
}

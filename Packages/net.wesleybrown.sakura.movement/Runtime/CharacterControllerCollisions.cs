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
        ///     given <see cref="CharacterController"/>, <see cref="Bodies"/>,
        ///     and <see cref="GameObjects"/>.
        /// </summary>
        /// <param name="controller">
        ///     The <see cref="CharacterController"/>.
        /// </param>
        /// <param name="bodies">
        ///     The <see cref="Bodies"/>.
        /// </param>
        /// <param name="gameObjects">
        ///     The <see cref="GameObjects"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="CharacterController"/> is
        ///     null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given <see cref="Bodies"/> is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given <see cref="GameObjects"/> is null.
        /// </exception>
        internal static CharacterControllerCollisions
            WithControllerAndBodiesAndGameObjects(
                CharacterController controller,
                Bodies bodies,
                GameObjects gameObjects)
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));
            if (bodies == null)
                throw new ArgumentNullException(nameof(bodies));
            if (gameObjects == null)
                throw new ArgumentNullException(nameof(gameObjects));
            throw new NotImplementedException();
        }
    }
}

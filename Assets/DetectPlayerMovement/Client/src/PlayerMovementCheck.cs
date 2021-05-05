using System;
using UnityEngine;

namespace Sakura.DetectPlayerMovement.Client
{
    /// <summary>
    ///     A check to see that the player moved last frame.
    /// </summary>
    public interface PlayerMovementCheck
    {
        /// <summary>
        ///     Whether or not the player moved last frame.
        /// </summary>
        /// <returns>
        ///     True if the player moved last frame; false otherwise.
        /// </returns>
        bool PlayerMovedLastFrame();

        /// <summary>
        ///     The player's desired destination last frame.
        /// </summary>
        /// <returns>
        ///     The player's desired destination last frame.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when there is no desired destination for the last
        ///     frame.
        /// </exception>
        Vector3 DesiredDestination();
    }
}

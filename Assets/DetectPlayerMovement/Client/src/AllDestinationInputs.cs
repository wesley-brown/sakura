using System;
using UnityEngine;

namespace Sakura.DetectPlayerMovement.Client
{
    /// <summary>
    ///     All the destination inputs from the player.
    /// </summary>
    public interface AllDestinationInputs
    {
        /// <summary>
        ///     Whether or not player input was captured during the previous
        ///     frame.
        /// </summary>
        /// <returns>
        ///     True if player input was captured during the previous frame;
        ///     false otherwise.
        /// </returns>
        bool CapturedInputPreviousFrame();

        /// <summary>
        ///     The world space destination the player wanted to go towards
        ///     during the previous frame.
        /// </summary>
        /// <returns>
        ///     The world space destination the player wanted to go towards
        ///     during the previous frame.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when there was no input captured during the previous
        ///     frame.
        /// </exception>
        Vector3 PreviousFrameDestination();
    }
}

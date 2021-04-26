using System;
using UnityEngine;

namespace Sakura.DetectPlayerMovement.Client
{
    /// <summary>
    ///     A check to see that the player moved last frame.
    /// </summary>
    public sealed class PlayerMovementCheck
    {
        /// <summary>
        ///     Create a new player movement check against a colleciton of all
        ///     destination inputs.
        /// </summary>
        /// <param name="allDestinationInputs">
        ///     The collection of all destination inputs.
        /// </param>
        /// <returns>
        ///     A new player movement check against the given collection of all
        ///     destination inputs.
        /// </returns>
        public static PlayerMovementCheck Against(
            AllDestinationInputs allDestinationInputs)
        {
            return new PlayerMovementCheck(allDestinationInputs);
        }

        private readonly AllDestinationInputs allDestinationInputs;

        private PlayerMovementCheck(AllDestinationInputs allDestinationInputs)
        {
            this.allDestinationInputs = allDestinationInputs;
        }

        /// <summary>
        ///     Whether or not the player moved last frame.
        /// </summary>
        /// <returns>
        ///     True if the player moved last frame; false otherwise.
        /// </returns>
        public bool PlayerMovedLastFrame()
        {
            return allDestinationInputs.CapturedInputPreviousFrame();
        }

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
        public Vector3 DesiredDestination()
        {
            if (!PlayerMovedLastFrame())
                throw new InvalidOperationException();
            return allDestinationInputs.PreviousFrameDestination();
        }
    }
}

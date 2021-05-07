using System;
using UnityEngine;

namespace Sakura.DetectPlayerMovement.Client
{
    /// <summary>
    ///     A check to see if the player had an intended destination to move
    ///     towards last frame.
    /// </summary>
    public sealed class DestinationCheck : PlayerMovementCheck
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the collection of all destination inputs is null.
        /// </exception>
        public static DestinationCheck Against(
            AllDestinationInputs allDestinationInputs)
        {
            if (allDestinationInputs == null)
                throw new ArgumentNullException(nameof(allDestinationInputs));
            return new DestinationCheck(allDestinationInputs);
        }

        private readonly AllDestinationInputs allDestinationInputs;

        private DestinationCheck(AllDestinationInputs allDestinationInputs)
        {
            this.allDestinationInputs = allDestinationInputs;
        }

        public bool PlayerMovedLastFrame()
        {
            return allDestinationInputs.CapturedInputPreviousFrame();
        }

        public Vector3 DesiredDestination()
        {
            if (!PlayerMovedLastFrame())
                throw new InvalidOperationException();
            return allDestinationInputs.PreviousFrameDestination();
        }

        public override string ToString()
        {
            return "{"
                + "PlayerMovedLastFrame="
                + PlayerMovedLastFrame()
                + ", DesiredDestination="
                + DesiredDestination()
                + "}";
        }
    }
}

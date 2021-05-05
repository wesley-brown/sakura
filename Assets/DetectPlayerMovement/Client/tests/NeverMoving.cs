using System;
using UnityEngine;

namespace Sakura.DetectPlayerMovement.Client.Tests
{
    /// <summary>
    ///     A collection of all destination inputs where input is never
    ///     captured for any frame and therefore there is never a destination.
    /// </summary>
    sealed class NeverMoving : AllDestinationInputs
    {
        public bool CapturedInputPreviousFrame()
        {
            return false;
        }

        public Vector3 PreviousFrameDestination()
        {
            throw new InvalidOperationException();
        }
    }
}

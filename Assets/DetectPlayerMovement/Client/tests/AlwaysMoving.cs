using UnityEngine;

namespace Sakura.DetectPlayerMovement.Client.Tests
{
    /// <summary>
    ///     A collection of all destination inputs for which the player is
    ///     always moving and therefore always has a destination every frame.
    /// </summary>
    sealed class AlwaysMoving : AllDestinationInputs
    {
        private static readonly Vector3 destination =
            new Vector3(1.0f, 0.0f, 1.0f);

        public Vector3 Destination
        {
            get
            {
                return destination;
            }
        }

        public bool CapturedInputPreviousFrame()
        {
            return true;
        }

        public Vector3 PreviousFrameDestination()
        {
            return destination;
        }
    }
}

using UnityEngine;
using Sakura.Movement;

namespace Sakura.Input
{
    /// <summary>
    /// Detects touch input.
    /// </summary>
    public sealed class TouchInputDetector : MonoBehaviour
    {
        [SerializeField]
        private Camera camera;
        private DestinationMover destinationMover;

        private void Awake()
        {
            destinationMover = GetComponent<DestinationMover>();
        }

        private void Update()
        {
            if (UnityEngine.Input.touchCount > 0)
            {
                Touch touch = UnityEngine.Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    var touchedScreenPosition = touch.position;
                    var touchedScreenPositionWithDepth =
                        AddDepthToTouchedScreenPosition(touchedScreenPosition);
                    var destination = camera
                        .ScreenToWorldPoint(touchedScreenPositionWithDepth);
                    destinationMover.MoveTowardsDestination(destination);
                }
            }
        }

        private Vector3 AddDepthToTouchedScreenPosition(
            Vector2 touchedScreenPosition)
        {
            var cameraDistanceFromPlayer =
                (camera.transform.position - transform.position).magnitude;
            return new Vector3(
                touchedScreenPosition.x,
                touchedScreenPosition.y,
                cameraDistanceFromPlayer
            );
        }
    }
}

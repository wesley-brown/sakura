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
        private int layerMask = 1;

        private static bool ScreenWasTouched()
        {
            return (UnityEngine.Input.touchCount > 0);
        }

        private void Awake()
        {
            destinationMover = GetComponent<DestinationMover>();
            layerMask = layerMask <<
                LayerMask.NameToLayer("TouchInputRaycastable");
        }

        private void Update()
        {
            if (ScreenWasTouched())
            {
                ReactToTouch();
            }
        }

        private void ReactToTouch()
        {
            Touch touch = UnityEngine.Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                MovePlayerTowardsTouchedPosition(touch.position);
            }
        }

        private void MovePlayerTowardsTouchedPosition(Vector2 touchedPosition)
        {
            var ray = camera.ScreenPointToRay(touchedPosition);
            RaycastHit hit;
            bool didHit = Physics
                .Raycast(ray, out hit, float.PositiveInfinity, layerMask);
            if (didHit)
            {
                destinationMover.MoveTowardsDestination(hit.point);
            }
        }
    }
}

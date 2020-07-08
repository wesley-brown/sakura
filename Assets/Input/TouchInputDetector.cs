using UnityEngine;
using Sakura.Movement;

namespace Sakura.Input
{
    /// <summary>
    /// Detects touch input.
    /// </summary>
    [RequireComponent(typeof(DestinationMoverParameter))]
    [RequireComponent(typeof(CameraParameter))]
    public sealed class TouchInputDetector : MonoBehaviour
    {
        private DestinationMoverParameter destinationMoverParameter = null;
        private CameraParameter cameraParameter = null;
        private int layerMask = 1;

        private static bool ScreenWasTouched()
        {
            return (UnityEngine.Input.touchCount > 0);
        }

        private void Awake()
        {
            destinationMoverParameter =
                GetComponent<DestinationMoverParameter>();
            cameraParameter = GetComponent<CameraParameter>();
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
            var ray = cameraParameter.Value.ScreenPointToRay(touchedPosition);
            RaycastHit hit;
            bool didHit = Physics
                .Raycast(ray, out hit, float.PositiveInfinity, layerMask);
            if (didHit)
            {
                destinationMoverParameter
                    .Value
                    .MoveTowardsDestination(hit.point);
            }
        }
    }
}

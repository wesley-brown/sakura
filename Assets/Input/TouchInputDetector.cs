using UnityEngine;
using Sakura.Movement;

namespace Sakura.Input
{
    /// <summary>
    /// Detects touch input.
    /// </summary>
    [RequireComponent(typeof(DestinationMoverParameter))]
    public sealed class TouchInputDetector : MonoBehaviour
    {
        [SerializeField]
        private new Camera camera = null;
        private DestinationMoverParameter destinationMoverParameter = null;
        private int layerMask = 1;

        private static bool ScreenWasTouched()
        {
            return (UnityEngine.Input.touchCount > 0);
        }

        private void Awake()
        {
            destinationMoverParameter =
                GetComponent<DestinationMoverParameter>();
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
                destinationMoverParameter
                    .Value
                    .MoveTowardsDestination(hit.point);
            }
        }
    }
}

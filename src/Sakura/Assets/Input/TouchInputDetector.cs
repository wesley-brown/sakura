using UnityEngine;
using Sakura.Crop;
using Sakura.Movement;

namespace Sakura.Input
{
    /// <summary>
    /// Detects touch input.
    /// </summary>
    public sealed class TouchInputDetector : MonoBehaviour
    {
        [SerializeField]
        private new Camera camera = null;
        private DestinationMover destinationMover;
        private InteractableRaycaster interactableRaycaster;
        private int layerMask = 1;

        private static bool ScreenWasTouched()
        {
            return (UnityEngine.Input.touchCount > 0);
        }

        private void Awake()
        {
            destinationMover = GetComponent<DestinationMover>();
            interactableRaycaster = GetComponent<InteractableRaycaster>();
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
                var ray = camera.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (interactableRaycaster.DidHitInteractable(ray, out hit))
                {
                    var emptyTilledSoil = hit.collider.gameObject.
                        GetComponentInParent<InteractableEmptyTilledSoil>();
                    emptyTilledSoil.PlantPotato();
                }
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

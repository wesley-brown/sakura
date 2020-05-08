using UnityEngine;
using Sakura.Input;

namespace Sakura.Runtime
{
    /// <summary>
    /// Allows a game object to detect when it is interacted with.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(InteractableRaycaster))]
    public sealed class InteractionDetector : MonoBehaviour
    {
        private new Collider collider = null;
        private Interactable interactable = null;
        private InteractableRaycaster interactableRaycaster = null;

        private void Awake()
        {
            collider = GetComponent<Collider>();
            interactable = GetComponent<Interactable>();
            interactableRaycaster = GetComponent<InteractableRaycaster>();
        }

        private void Update()
        {
            if (ScreenWasTouched)
            {
                var touch = UnityEngine.Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended)
                {
                    var ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (interactableRaycaster.DidHitInteractable(ray, out hit))
                    {
                        ReactToHit(hit);
                    }
                }
            }
        }

        private bool ScreenWasTouched
        {
            get
            {
                return (UnityEngine.Input.touchCount > 0);
            }
        }

        private void ReactToHit(RaycastHit hit)
        {
            if (hit.collider == collider)
            {
                interactable.React();
            }
        }
    }
}

using UnityEngine;
using Sakura.Input;
using Sakura.Interactions;
using System.Collections.Generic;
using UnityEngine.EventSystems;

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
        private InteractableRaycaster interactableRaycaster = null;
        private IEnumerable<Reactor> reactors = null;

        private void Awake()
        {
            collider = GetComponent<Collider>();
            interactableRaycaster = GetComponent<InteractableRaycaster>();
            reactors = GetComponents<Reactor>();
        }

        private void Update()
        {
            if (ScreenWasTouched)
            {
                var touch = UnityEngine.Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began &&
                    !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
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
                foreach (var reactor in reactors)
                {
                    reactor.React();
                }
            }
        }
    }
}

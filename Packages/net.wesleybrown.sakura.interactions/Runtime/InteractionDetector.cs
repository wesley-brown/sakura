using UnityEngine;
using UnityEngine.EventSystems;

namespace Sakura.Interactions
{
    /// <summary>
    /// Allows a game object to detect when it is interacted with.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public sealed class InteractionDetector : MonoBehaviour
    {
        private new Collider collider = null;
        private Interaction[] interactions = null;

        private void Awake()
        {
            collider = GetComponent<Collider>();
            interactions = GetComponentsInChildren<Interaction>();
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
                    var raycast = Raycast.WithRayAndCollider(ray, collider);
                    if (raycast.Hit)
                    {
                        React();
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

        private void React()
        {
            foreach (var interaction in interactions)
            {
                interaction.Interact();
            }
        }
    }
}

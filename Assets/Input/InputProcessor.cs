using Sakura.Components;
using Sakura.Config;
using Sakura.UnityComponents.Rendering;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sakura.Input
{
    public sealed class InputProcessor
    {
        private readonly Main main;
        private readonly Camera camera;
        private int layerMask;
        private Entity player;
        private MoveToDestination previousMove;
        private List<Interactable> interactables;
        private readonly EntityConfig entityConfig;

        public InputProcessor(
            Main main,
            Camera camera,
            Entity player,
            List<Interactable> interactables,
            EntityConfig entityConfig)
        {
            this.main = main;
            this.camera = camera;
            layerMask = 1 << LayerMask.NameToLayer("TouchInputRaycastable");
            this.player = player;
            previousMove = new MoveToDestination(player, player.Location);
            this.interactables = interactables;
            this.entityConfig = entityConfig;
        }

        public void ProcessInput()
        {
            if (ScreenWasTouched())
            {
                ReactToTouch();
            }
        }

        private void ReactToTouch()
        {
            Touch touch = UnityEngine.Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId)
                && touch.phase == TouchPhase.Moved)
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

            // Adjust for y level of player
            var destination = new Vector3(hit.point.x, player.Location.y, hit.point.z);

            if (didHit)
            {
                player.Remove(previousMove);
                player.Add(new MoveToDestination(player, destination));
            }

            if (TouchedInteractable(hit))
            {
                var model = hit.collider.GetComponent<Model>();
                if (model != null)
                {
                    model.Entity.Add(new SpawnEntity(model.Entity, main, entityConfig));
                }
            }
        }

        private static bool ScreenWasTouched()
        {
            return (UnityEngine.Input.touchCount > 0);
        }

        private bool TouchedInteractable(RaycastHit hit)
        {            
            var hitInteractable = hit.collider.CompareTag("Interactable");
            if (hitInteractable)
            {
                Debug.Log("Touched interactable");
            }
            return hitInteractable;
        }
    }
}

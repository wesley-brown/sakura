using Sakura.Components;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sakura.Input
{
    public sealed class InputProcessor
    {
        private readonly Camera camera;
        private int layerMask;
        private Entity player;
        private MoveToDestination previousMove;

        public InputProcessor(Camera camera, Entity player)
        {
            this.camera = camera;
            layerMask = 1 << LayerMask.NameToLayer("TouchInputRaycastable");
            this.player = player;
            previousMove = new MoveToDestination(player, player.Location);
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
        }

        private static bool ScreenWasTouched()
        {
            return (UnityEngine.Input.touchCount > 0);
        }
    }
}

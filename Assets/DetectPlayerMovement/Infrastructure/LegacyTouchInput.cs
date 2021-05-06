using System;
using Sakura.DetectPlayerMovement.Client;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sakura.DetectPlayerMovement.Infrastructure
{
    /// <summary>
    ///     A touch-based destination input using Unity's legacy input system.
    /// </summary>
    public sealed class LegacyTouchInput : AllDestinationInputs
    {
        private readonly Camera camera;
        private readonly string layerName;

        private RaycastHit hit;
        private bool didHit;
        private bool didCacheHit;

        public LegacyTouchInput(Camera camera, string layerName)
        {
            this.camera = camera;
            this.layerName = layerName;
            hit = new RaycastHit();
            didHit = false;
            didCacheHit = false;
        }

        public bool CapturedInputPreviousFrame()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId)
                    && touch.phase == TouchPhase.Moved)
                {
                    var ray = camera.ScreenPointToRay(touch.position);
                    var layerMask = 1 << LayerMask.NameToLayer(layerName);
                    didHit = Physics.Raycast(ray, out hit, float.PositiveInfinity, layerMask);
                    didCacheHit = true;
                    return didHit;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Vector3 PreviousFrameDestination()
        {
            if (!didCacheHit)
                CapturedInputPreviousFrame();
            if (!didHit)
                throw new InvalidOperationException();
            return hit.point;
        }
    }
}

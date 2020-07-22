using UnityEngine;
using UnityEngine.EventSystems;

namespace Sakura.Input
{
    public sealed class InputProcessor
    {
        private readonly Camera camera;

        public InputProcessor(Camera camera)
        {
            this.camera = camera;
        }

        public void ProcessInput()
        {

        }
    }
}

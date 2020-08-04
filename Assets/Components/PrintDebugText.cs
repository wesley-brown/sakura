using UnityEngine;

namespace Sakura.Components
{
    public sealed class PrintDebugText : Component
    {
        private readonly Entity entity;
        private readonly string text;

        public PrintDebugText(Entity entity, string text)
        {
            this.entity = entity;
            this.text = text;
        }

        public void Update()
        {
            Debug.Log(text);
            entity.Remove(this);
        }
    }
}

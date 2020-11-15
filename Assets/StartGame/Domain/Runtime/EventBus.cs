using UnityEngine;

namespace Sakura.StartGame.Domain
{
    public sealed class EventBus : ScriptableObject
    {
        [SerializeField] private Simulation simulation = null;

        public bool Register(Entity entity)
        {
            return true;
        }
    }
}

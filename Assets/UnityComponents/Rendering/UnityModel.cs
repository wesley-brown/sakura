using UnityEngine;

namespace Sakura.UnityComponents.Rendering
{
    public abstract class UnityModel : MonoBehaviour, Model
    {
        public abstract Entity Entity { get; set; }
        public abstract GameObject GameObject { get; }
    }
}

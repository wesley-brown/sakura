using UnityEngine;

namespace Sakura.UnityComponents.Rendering
{
    [RequireComponent(typeof(MainHook))]
    public sealed class UnityModel : MonoBehaviour, Model
    {
        private MainHook mainHook = null;
        private Entity entity = null;

        public Entity Entity
        {
            get
            {
                return entity;
            }

            set
            {
                entity = value;
            }
        }

        private void Awake()
        {
            mainHook = GetComponent<MainHook>();
        }

        private void Start()
        {
            if (WasPlacedInEditor)
            {
                entity = mainHook.BindToNewEntity(this);
            }
        }

        private bool WasPlacedInEditor
        {
            get
            {
                return entity == null;
            }
        }

        private void OnDestroy()
        {
            mainHook.UnbindFromEntity(this);
        }
    }
}

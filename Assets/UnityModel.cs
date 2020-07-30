using UnityEngine;

namespace Sakura
{
    /// <summary>
    /// A 3D representation of an entity rendered in Unity.
    /// </summary>
    [RequireComponent(typeof(MainHook))]
    public sealed class UnityModel : MonoBehaviour
    {
        public Entity Entity = null;

        private MainHook mainHook = null;

        private void Awake()
        {
            mainHook = GetComponent<MainHook>();
        }

        private void Start()
        {
            if (WasPlacedInEditor)
            {
                mainHook.Main.BindToNewEntity(this);
            }
        }

        private void Update()
        {
            var interpolatedPosition = Vector3.Lerp(transform.position, Entity.Location, Time.deltaTime);
            transform.position = interpolatedPosition;
        }

        private void OnDestroy()
        {
            Destroy(gameObject);
            mainHook.Main.UnbindFromEntity(this);
        }

        private bool WasPlacedInEditor
        {
            get
            {
                return Entity == null;
            }
        }
    }
}

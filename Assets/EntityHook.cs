using UnityEngine;

namespace Sakura
{
    [RequireComponent(typeof(MainHook))]
    public sealed class EntityHook : MonoBehaviour
    {
        public Entity entity = null;
        private Main main = null;

        private void Start()
        {
            var mainHook = GetComponent<MainHook>();
            main = mainHook.Main;
            main.RegisterEntity(gameObject);
        }

        private void OnDestroy()
        {
            Destroy(gameObject);
            main.UnregisterEntity(entity);
        }
    }
}

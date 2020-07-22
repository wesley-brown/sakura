using UnityEngine;

namespace Sakura
{
    [RequireComponent(typeof(MainHook))]
    public sealed class EntityHook : MonoBehaviour
    {
        private void Start()
        {
            var main = GetComponent<MainHook>().Main;
            main.RegisterEntity(gameObject);
        }
    }
}

using UnityEngine;

namespace Sakura
{
    /// <summary>
    /// Stores a reference to main.
    /// </summary>
    public sealed class MainHook : MonoBehaviour
    {
        [SerializeField] private GameObject mainPrefab = null;
        private Main main = null;

        public Main Main
        {
            get
            {
                return main;
            }
        }

        private void Awake()
        {
            main = mainPrefab.GetComponent<Main>();
        }
    }
}

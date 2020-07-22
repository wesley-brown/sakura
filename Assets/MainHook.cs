using UnityEngine;

namespace Sakura
{
    /// <summary>
    /// Stores a reference to main.
    /// </summary>
    public sealed class MainHook : MonoBehaviour
    {
        private Main main = null;

        private void Awake()
        {
            var mainGameObject = GameObject.FindGameObjectWithTag(
                "GameController");
            main = mainGameObject.GetComponent<Main>();
        }

        public Main Main
        {
            get
            {
                return main;
            }
        }
    }
}

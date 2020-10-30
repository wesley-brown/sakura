using Sakura.StartGame.Main;
using UnityEngine;

namespace Sakura.UnityComponents.Rendering
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

        public Entity BindToNewEntity(UnityModel unityModel)
        {
            return main.BindToNewEntity(unityModel);
        }

        public void UnbindFromEntity(UnityModel unityModel)
        {
            main.UnbindFromEntity(unityModel);
        }

        public void RegisterWindowController(MonoBehaviour windowController)
        {
            main.RegisterWindowController(windowController);
        }

        public Entity Player
        {
            get
            {
                return main.Player;
            }
        }
    }
}

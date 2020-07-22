using Sakura.Input;
using System.Collections.Generic;
using UnityEngine;

namespace Sakura
{
    /// <summary>
    /// Acts as the main function.
    /// </summary>
    public sealed class Main : MonoBehaviour
    {
        [SerializeField] private WalletReference playersWallet = null;

        private MonoBehaviour windowController = null;
        private List<Entity> entities = null;

        private void Awake()
        {
            playersWallet.Wallet = new Wallet();
            entities = new List<Entity>();
        }

        public void RegisterWindowController(MonoBehaviour windowController)
        {
            if (this.windowController)
            {
                Destroy(this.windowController.gameObject);
            }
            this.windowController = windowController;
        }

        public void RegisterEntity(GameObject gameObject)
        {
            entities.Add(new Entity(gameObject));
            Debug.Log(
                "Registered pre-existing entity '"
                + gameObject.name
                + "'");
        }
    }
}

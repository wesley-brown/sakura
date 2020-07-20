using UnityEngine;

namespace Sakura
{
    /// <summary>
    /// Acts as the main function.
    /// </summary>
    public sealed class Main : MonoBehaviour
    {
        [SerializeField] private WalletReference playersWallet = null;
        [SerializeField] private GameObject initialWindowPrefab = null;

        private MonoBehaviour windowController = null;

        private void Awake()
        {
            playersWallet.Wallet = new Wallet();
        }

        public void RegisterWindowController(MonoBehaviour windowController)
        {
            if (this.windowController)
            {
                Destroy(this.windowController.gameObject);
            }
            this.windowController = windowController;
        }
    }
}

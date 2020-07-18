using Sakura.UI;
using UnityEngine;

namespace Sakura
{
    public sealed class Main : MonoBehaviour
    {
        [SerializeField] private WalletReference playersWallet = null;
        [SerializeField] private GameObject initialWindowPrefab = null;

        private Window window = null;
        private WindowController mainWindowController = null;

        private void Awake()
        {
            playersWallet.Wallet = new Wallet();
            var view = Instantiate(initialWindowPrefab);
            mainWindowController = view.GetComponent<WindowController>();
            window = new Window(mainWindowController);
        }

        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
            
        }
    }
}

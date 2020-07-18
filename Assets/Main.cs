using Sakura.UI;
using UnityEngine;

namespace Sakura
{
    public sealed class Main : MonoBehaviour
    {
        [SerializeField] private WalletReference playersWallet = null;
        [SerializeField] private ViewController viewController = null;

        private Window window = null;

        private void Awake()
        {
            playersWallet.Wallet = new Wallet();
            window = new Window(viewController);
            viewController.Window = window;
        }

        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
            
        }
    }
}

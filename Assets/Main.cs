using UnityEngine;

namespace Sakura
{
    public sealed class Main : MonoBehaviour
    {
        [SerializeField]
        private WalletReference playersWallet = null;

        private void Awake()
        {
            playersWallet.Wallet = new Wallet();
        }

        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
            
        }
    }
}

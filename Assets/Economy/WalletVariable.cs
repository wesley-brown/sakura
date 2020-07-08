using UnityEngine;

namespace Sakura
{
    public sealed class WalletVariable : MonoBehaviour
    {
        private Wallet wallet = null;

        private void Start()
        {
            wallet = GetComponent<WalletParameter>().Value;
        }

        public void Increment(int amount)
        {
            wallet.Add(amount);
        }
    }
}
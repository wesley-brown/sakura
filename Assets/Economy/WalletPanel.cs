using TMPro;
using UnityEngine;

namespace Sakura
{
    /// <summary>
    /// Displays a wallet's balance.
    /// </summary>
    public sealed class WalletPanel : MonoBehaviour
    {
        [SerializeField]
        private WalletReference walletReference = null;

        private Wallet wallet = null;
        private TextMeshProUGUI textBox = null;

        private void Awake()
        {
            textBox = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            wallet = walletReference.Wallet;
            wallet.Subscribe(OnWalletUpdate);
            textBox.text = wallet.Balance.ToString();
        }

        private void OnWalletUpdate(int balance)
        {
            textBox.text = balance.ToString();
        }

        private void OnDestroy()
        {
            wallet.Unsubscribe(OnWalletUpdate);
        }
    }
}

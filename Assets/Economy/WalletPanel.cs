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
            textBox.text = wallet.Balance.ToString();
        }
    }
}

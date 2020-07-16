using UnityEngine;

namespace Sakura
{
    [CreateAssetMenu(
        fileName = "New Wallet",
        menuName = "Economy/Wallet")]
    public sealed class WalletReference : ScriptableObject
    {
        public Wallet Wallet = null;
    }
}

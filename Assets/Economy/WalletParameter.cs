using UnityEngine;

namespace Sakura
{
    public sealed class WalletParameter : MonoBehaviour
    {
        public Wallet Literal = null;
        public WalletParameter Reference = null;

        public Wallet Value
        {
            get
            {
                Destroy(this);
                if (Reference)
                {
                    return Reference.Value;
                }
                else
                {
                    return Literal;
                }
            }
        }
    }
}

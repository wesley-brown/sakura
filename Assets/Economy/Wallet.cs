using UnityEngine;

namespace Sakura
{
    [CreateAssetMenu(
        fileName = "New Wallet",
        menuName = "Economy/Wallet")]
    public sealed class Wallet : ScriptableObject
    {
        [SerializeField]
        private int startingBalance = 0;

        private int balance = 0;

        private void OnEnable()
        {
            balance = startingBalance;
        }

        public void Add(int balance)
        {
            this.balance += balance;
            Debug.Log(this.balance);
        }
    }
}

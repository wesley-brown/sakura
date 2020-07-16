using Sakura.Events;

namespace Sakura
{
    public sealed class Wallet
    {
        private int balance;
        private SakuraEvent<int> onUpdate;

        public Wallet() : this(0, new SakuraEvent<int>())
        {
        }

        public Wallet(int startingBalance, SakuraEvent<int> onUpdate)
        {
            balance = startingBalance;
            this.onUpdate = onUpdate;
        }

        public int Balance
        {
            get
            {
                return balance;
            }
        }

        public void Add(int amount)
        {
            balance = balance + amount;
            onUpdate.RaiseFor(balance);
        }

        public void Subscribe(SakuraAction<int> action)
        {
            onUpdate = onUpdate.AddListener(action);
        }

        public void Unsubscribe(SakuraAction<int> action)
        {
            onUpdate = onUpdate.RemoveListener(action);
        }
    }
}

namespace Sakura
{
    public sealed class Wallet
    {
        private readonly int balance;

        public Wallet() : this(0)
        {
        }

        public Wallet(int startingBalance)
        {
            balance = startingBalance;
        }

        public int Balance
        {
            get
            {
                return balance;
            }
        }

        public Wallet Add(int amount)
        {
            return new Wallet(balance + amount);
        }
    }
}

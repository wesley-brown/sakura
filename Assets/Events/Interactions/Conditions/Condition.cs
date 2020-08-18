namespace Sakura.Events.Interactions.Conditions
{
    public sealed class Condition
    {
        private bool value;

        public Condition()
        {
            value = true;
        }

        public bool IsTrue
        {
            get
            {
                return value;
            }
        }

        public void HasNotBeenMet()
        {
            value = false;
        }
    }
}

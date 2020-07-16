using System.Collections.Generic;

namespace Sakura.Events
{
    public sealed class SakuraEvent<T>
    {
        private readonly List<SakuraAction<T>> listeners;

        public SakuraEvent()
        {
            listeners = new List<SakuraAction<T>>();
        }

        public SakuraEvent(List<SakuraAction<T>> listeners)
        {
            this.listeners = new List<SakuraAction<T>>(listeners);
        }

        public void RaiseFor(T t)
        {
            foreach (var listener in listeners)
            {
                listener(t);
            }
        }

        public SakuraEvent<T> AddListener(SakuraAction<T> action)
        {
            var actions = new List<SakuraAction<T>>(listeners);
            actions.Add(action);
            return new SakuraEvent<T>(actions);
        }

        public SakuraEvent<T> RemoveListener(SakuraAction<T> action)
        {
            var actions = new List<SakuraAction<T>>(listeners);
            actions.Remove(action);
            return new SakuraEvent<T>(actions);
        }
    }
}

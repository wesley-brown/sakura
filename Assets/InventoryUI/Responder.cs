using Sakura.Inventories.Runtime;
using UnityEngine;
using UnityEngine.Events;

namespace Sakura.Interactions
{
    /// <summary>
    /// Responds to UI events.
    /// </summary>
    public abstract class Responder<T> : MonoBehaviour
    {
        public abstract void RespondTo(T t);
    }
}

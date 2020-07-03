using UnityEngine.Events;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// An event involving an inventory slot.
    /// </summary>
    [System.Serializable]
    public sealed class SlotSelection : UnityEvent<Slot>
    {
    }
}

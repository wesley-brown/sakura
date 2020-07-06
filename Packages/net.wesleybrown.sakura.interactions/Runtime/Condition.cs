using UnityEngine;

namespace Sakura.Interactions
{
    /// <summary>
    /// A condition for an interaction.
    /// </summary>
    public abstract class Condition : MonoBehaviour
    {
        public virtual bool IsTrue { get; }
    }
}

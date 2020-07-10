using UnityEngine;

namespace Sakura.Parameters.Primitives
{
    /// <summary>
    /// A constructor parameter for an int.
    /// </summary>
    public sealed class IntParameter : MonoBehaviour
    {
        public int value = 0;

        public int Value
        {
            get
            {
                Destroy(this);
                return value;
            }
        }
    }
}

using UnityEngine;

namespace Sakura.Parameters.Primitives
{
    /// <summary>
    /// An int.
    /// </summary>
    public sealed class IntVariable : MonoBehaviour
    {
        private int value = 0;

        private void Awake()
        {
            var literal = GetComponent<IntParameter>();
            value = literal.Value;
        }

        public int Value
        {
            get
            {
                return value;
            }
        }
    }
}

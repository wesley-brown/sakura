using UnityEngine;

namespace Sakura.Parameters.Primitives
{
    /// <summary>
    /// A constructor parameter for a float.
    /// </summary>
    public sealed class FloatParameter : MonoBehaviour
    {
        public float Literal = 0.0f;
        public FloatParameter Reference = null;

        public float Value
        {
            get
            {
                if (Reference)
                {
                    return Reference.Value;
                }
                else
                {
                    return Literal;
                }
            }
        }
    }
}

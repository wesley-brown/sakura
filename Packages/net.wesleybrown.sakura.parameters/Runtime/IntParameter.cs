using UnityEngine;

namespace Sakura.Parameters.Primitives
{
    public sealed class IntParameter : MonoBehaviour
    {
        public int Literal = 0;
        public IntParameter Reference = null;

        public int Value
        {
            get
            {
                Destroy(this);
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

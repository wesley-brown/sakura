using UnityEngine;

namespace Sakura.Parameters.Primitives
{
    public sealed class IntVariableParameter : MonoBehaviour
    {
        public IntVariable Literal = null;
        public IntVariableParameter Reference = null;

        public IntVariable Value
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

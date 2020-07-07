using UnityEngine;

namespace Sakura.Movement
{
    /// <summary>
    /// A constructor parameter for a character controller.
    /// </summary>
    public sealed class CharacterControllerParameter : MonoBehaviour
    {
        public CharacterController Literal = null;
        public CharacterControllerParameter Reference = null;

        public CharacterController Value
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

using UnityEngine;

namespace Sakura
{
    /// <summary>
    /// A constructor parameter for a player.
    /// </summary>
    public sealed class PlayerParameter : MonoBehaviour
    {
        public Player Literal = null;
        public PlayerParameter Reference = null;

        public Player Value
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

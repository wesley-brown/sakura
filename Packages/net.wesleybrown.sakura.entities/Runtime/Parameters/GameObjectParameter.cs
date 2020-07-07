using UnityEngine;

namespace Sakura.Entities
{
    /// <summary>
    /// A constructor parameter for a game object.
    /// </summary>
    public sealed class GameObjectParameter : MonoBehaviour
    {
        public GameObject Literal = null;
        public GameObjectParameter Reference = null;

        /// <summary>
        /// The game object that this game object parameter represents.
        /// </summary>
        public GameObject Value
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

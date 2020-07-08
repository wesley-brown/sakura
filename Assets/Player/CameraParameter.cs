using UnityEngine;

namespace Sakura
{
    /// <summary>
    /// A constructor parameter for a camera.
    /// </summary>
    public sealed class CameraParameter : MonoBehaviour
    {
        public Camera Literal = null;
        public CameraParameter Reference = null;

        public Camera Value
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

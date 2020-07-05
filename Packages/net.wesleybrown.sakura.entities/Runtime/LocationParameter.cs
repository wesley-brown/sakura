using UnityEngine;

namespace Sakura.Entities
{
    /// <summary>
    /// A constructor parameter for a location.
    /// </summary>
    public sealed class LocationParameter : MonoBehaviour
    {
        public Location Literal = null;
        public LocationParameter Reference = null;

        public Location Value
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

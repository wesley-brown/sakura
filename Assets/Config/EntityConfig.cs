using UnityEngine;

namespace Sakura.Config
{
    [CreateAssetMenu(
        fileName = "New Entity Config",
        menuName = "Config/EntityConfig")]
    public sealed class EntityConfig : ScriptableObject
    {
        public int Id = 0;
        public GameObject ModelPrefab = null;
    }
}

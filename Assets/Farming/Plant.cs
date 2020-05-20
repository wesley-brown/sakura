using UnityEngine;
using Sakura.Inventories.Runtime;
using System;

namespace Sakura.Farming
{
    /// <summary>
    /// A plant that grows from a seed and produces crops.
    /// </summary>
    [CreateAssetMenu(
        fileName = "New Plant",
        menuName = "Farming/Plant")]
    public sealed class Plant : ScriptableObject
	{
        [SerializeField] private ItemTemplate seed = null;
        [SerializeField] private GameObject prefab = null;
        [SerializeField] private ItemTemplate crop = null;

        public ItemTemplate Seed
        {
            get
            {
                return seed;
            }
        }

        public GameObject Prefab
        {
            get
            {
                return prefab;
            }
        }

        public ItemTemplate Crop
        {
            get
            {
                return crop;
            }
        }

        private void Awake()
        {
            if (seed == null)
            {
                throw new InvalidOperationException("Seed must not be null");
            }
            else if (prefab == null)
            {
                throw new InvalidOperationException("Prefab must not be null");
            }
            else if (crop == null)
            {
                throw new InvalidOperationException("Crop must not be null");
            }
        }
    }
}

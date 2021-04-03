using System;
using Sakura.Identifiers.Client;
using Sakura.Identifiers.Infrastructure;
using UnityEngine;

namespace Sakura.Identifiers.Unity
{
    /// <summary>
    ///     An ID registry that is also a scriptable object.
    /// </summary>
    [CreateAssetMenu(
        fileName = "NewScriptableObjectIdRegistry",
        menuName = "Identifiers/ID Registries/ScriptableObjectIdRegistry")]
    public sealed class ScriptableObjectIdRegistry
        : ScriptableObject, IdRegistry
    {
        private DictionaryIdRegistry registry;

        private void OnEnable()
        {
            registry = new DictionaryIdRegistry();
        }

        public void ClaimIdFor(Guid ID, int instanceID)
        {
            registry.ClaimIdFor(ID, instanceID);
        }

        public GameObject GameObjectClaimingId(Guid ID)
        {
            return registry.GameObjectClaimingId(ID);
        }
    }
}

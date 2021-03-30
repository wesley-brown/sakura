using System;

namespace Sakura.Identifiers.Client
{
    /// <summary>
    ///     Manages game object claims for entity IDs.
    /// </summary>
    public sealed class ClaimsAgent
    {
        private readonly IdRegistry registry;

        /// <summary>
        ///     Create a new claims authority that will use a given ID
        ///     registry.
        /// </summary>
        /// <param name="registry">
        ///     The ID registry to use.
        /// </param>
        public ClaimsAgent(IdRegistry registry)
        {
            this.registry = registry;
        }

        public bool IsClaimed(Guid ID)
        {
            return (registry.GameObjectClaimingId(ID) != null);
        }

        public void ClaimIDFor(Guid ID, int instanceID)
        {
            registry.ClaimIdFor(ID, instanceID);
        }
    }
}

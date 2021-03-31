using System;

namespace Sakura.Identifiers.Client
{
    public interface ClaimsAuthority
    {
        /// <summary>
        ///     Whether or not a given entity ID has been claimed by a game
        ///     object.
        /// </summary>
        /// <param name="ID">
        ///     The entity ID to check the claimed status of.
        /// </param>
        /// <returns>
        ///     True if the given entity ID has been claimed by a game object;
        ///     false otherwise.
        /// </returns>
        bool IsClaimed(Guid ID);

        /// <summary>
        ///     Claim a given entity ID for a game object with a given instance
        ///     ID.
        /// </summary>
        /// <param name="ID">
        ///     The entity ID to claim.
        /// </param>
        /// <param name="gameObjectId">
        ///     The instance ID of the game object to make the claim for.
        /// </param>
        /// <exception cref="EntityIdAlreadyClaimed">
        ///     Thrown when the entity with the given ID has already been
        ///     claimed.
        /// </exception>
        void ClaimIDFor(Guid ID, int instanceID);
    }
}

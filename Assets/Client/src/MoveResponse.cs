using System.Collections.Generic;

namespace Sakura.Movement.Responses
{
    /// <summary>
    ///     A response based on a request to move an entity.
    /// </summary>
    public sealed class MoveResponse
    {
        /// <summary>
        ///     Whether or not the entity was moved.
        /// </summary>
        public bool DidMove { get; set; } = false;

        /// <summary>
        ///     The new location of the entity after moving, if it did move.
        /// </summary>
        public Location NewLocation { get; set; } = null;

        /// <summary>
        ///     The list of errors, if any, that occured while trying to move
        ///     the entity.
        /// </summary>
        public IList<string> Errors { get; set; } = new List<string>();
    }
}

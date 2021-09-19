namespace Sakura.Client
{
    /// <summary>
    ///     A presenter for a <see cref="CollidableMovementSystem"/>.
    /// </summary>
    public interface CollidableMovementSystemPresenter
    {
        /// <summary>
        ///     Present a given <see cref="CollidableMovement"/>.
        /// </summary>
        /// <param name="collidableMovement">
        ///     The <see cref="CollidableMovement"/> to present.
        /// </param>
        void Present(CollidableMovement collidableMovement);
    }
}

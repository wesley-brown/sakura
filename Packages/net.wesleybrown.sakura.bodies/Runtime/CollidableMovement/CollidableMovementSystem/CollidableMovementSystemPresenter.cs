namespace Sakura.Bodies.CollidableMovement
{
    /// <summary>
    ///     A presenter for a <see cref="CollidableMovementSystem"/>.
    /// </summary>
    public interface CollidableMovementSystemPresenter
    {
        /// <summary>
        ///     Report a given error.
        /// </summary>
        /// <param name="error">
        ///     The error to report.
        /// </param>
        void ReportError(string error);

        /// <summary>
        ///     Present a given <see cref="CollidableMovement"/>.
        /// </summary>
        /// <param name="collidableMovement">
        ///     The <see cref="CollidableMovement"/> to present.
        /// </param>
        void Present(CollidableMovement collidableMovement);
    }
}

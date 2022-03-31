namespace Sakura.Bodies.Movements.Creations
{
    /// <summary>
    ///     A system that creates movements.
    /// </summary>
    internal sealed class System
    {
        /// <summary>
        ///     Create a movement creation system made of a given gateway,
        ///     presenter, and fixed time step.
        /// </summary>
        /// <param name="gateway">
        ///     The gateway.
        /// </param>
        /// <param name="presenter">
        ///     The presenter.
        /// </param>
        /// <param name="fixedTimeStepSeconds">
        ///     The fixed time step.
        /// </param>
        /// <returns>
        ///     A movement creation system made of the given gateway,
        ///     presenter, and fixed time step.
        /// </returns>
        /// <exception cref="global::System.ArgumentOutOfRangeException">
        /// Thrown when the given fixed time step is negative.
        /// </exception>
        internal static System Of(
            Gateway gateway,
            OutputPort presenter,
            float fixedTimeStepSeconds)
        {
            if (fixedTimeStepSeconds < 0)
                throw new global::System.ArgumentOutOfRangeException(
                    nameof(fixedTimeStepSeconds),
                    "The given fixed time step must be non-negative.");
            throw new global::System.NotImplementedException();
        }
    }
}

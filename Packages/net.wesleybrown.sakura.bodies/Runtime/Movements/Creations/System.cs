using System.Collections.Generic;
using UnityEngine;

namespace Sakura.Bodies.Movements.Creations
{
    /// <summary>
    ///     A system that creates movements.
    /// </summary>
    internal sealed class System : InputPort
    {
        private readonly OutputPort presenter;

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
        /// <exception cref="global::System.ArgumentNullException">
        ///     Thrown when the given gateway is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given presenter is null.
        /// </exception>
        /// <exception cref="global::System.ArgumentOutOfRangeException">
        ///     Thrown when the given fixed time step is <= 0.
        /// </exception>
        internal static System Of(
            Gateway gateway,
            OutputPort presenter,
            float fixedTimeStepSeconds)
        {
            if (gateway == null)
                throw new global::System.ArgumentNullException(
                    nameof(gateway));
            if (presenter == null)
                throw new global::System.ArgumentNullException(
                    nameof(presenter));
            if (fixedTimeStepSeconds <= 0)
                throw new global::System.ArgumentOutOfRangeException(
                    nameof(fixedTimeStepSeconds),
                    "The given fixed time step must be > 0");
            return new System(presenter);
        }

        private System(OutputPort presenter)
        {
            this.presenter = presenter;
        }

        /// <summary>
        ///     Create a movement based on the given input.
        /// </summary>
        /// <param name="input">
        ///     The input to creation the movement with.
        /// </param>
        public void Move(Input input)
        {
            Debug.Assert(presenter != null);
            var validationErrors = new List<string>();
            if (input == null)
                validationErrors.Add("The given input must not be null.");
            presenter.OnValidationError(validationErrors);
        }
    }
}

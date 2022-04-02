using System.Collections.Generic;
using UnityEngine;

namespace Sakura.Bodies.Movements.Creations
{
    /// <summary>
    ///     A system that creates movements.
    /// </summary>
    internal sealed class System : InputPort
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
            validationErrors = new List<string>();
        }

        private readonly OutputPort presenter;
        private readonly List<string> validationErrors;

        /// <summary>
        ///     Create a movement based on the given input.
        /// </summary>
        /// <param name="input">
        ///     The input to creation the movement with.
        /// </param>
        public void Move(Input input)
        {
            Debug.Assert(presenter != null);
            Debug.Assert(validationErrors != null);
            ValidateInput(input);
            if (validationErrors.Count > 0)
                presenter.OnValidationError(
                    new List<string>(validationErrors));
        }

        private void ValidateInput(Input input)
        {
            Debug.Assert(presenter != null);
            Debug.Assert(validationErrors != null);
            if (input == null)
            {
                validationErrors.Add("The given input must not be null.");
            }
            else
            {
                ValidateEntity(input.Entity);
                ValidateSpeed(input.SpeedMetersPerSecond);
                ValidateTimestamp(input.Timestamp);
            }
        }

        private void ValidateEntity(string entity)
        {
            Debug.Assert(validationErrors != null);
            var isGuid = global::System.Guid.TryParse(
                entity,
                out _);
            if (!isGuid)
                validationErrors.Add($"{entity} is not a valid Guid.");
        }

        private void ValidateSpeed(float speed)
        {
            Debug.Assert(validationErrors != null);
            if (speed < 0)
                validationErrors.Add("The given speed must be non-negative.");
        }

        private void ValidateTimestamp(float timestamp)
        {
            Debug.Assert(validationErrors != null);
            if (timestamp < 0)
                validationErrors.Add(
                    "The given timestamp must be non-negative.");
        }
    }
}

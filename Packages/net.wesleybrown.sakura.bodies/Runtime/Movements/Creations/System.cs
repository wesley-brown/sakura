using System.Collections.Generic;
using Sakura.Bodies.Core;
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
            return new System(
                gateway,
                presenter);
        }

        private System(
            Gateway gateway,
            OutputPort presenter)
        {
            this.gateway = gateway;
            this.presenter = presenter;
        }

        private readonly Gateway gateway;
        private readonly OutputPort presenter;

        /// <summary>
        ///     Create a movement based on the given input.
        /// </summary>
        /// <param name="input">
        ///     The input to creation the movement with.
        /// </param>
        public void Move(Input input)
        {
            if (input == null)
                PresentSyntacticErrors(new List<string>
                {
                    "input must not be null."
                });
            else
                ValidateSyntax(input);
        }

        private void ValidateSyntax(Input input)
        {
            Debug.Assert(input != null);
            var syntacticErrors = new List<string>();
            var isGuid = global::System.Guid.TryParse(
                    input.Entity,
                    out _);
            if (!isGuid)
                syntacticErrors.Add("input.Entity must be a GUID.");
            if (input.SpeedMetersPerSecond < 0)
                syntacticErrors.Add(
                    "input.SpeedMetersPerSecond must be >= 0.");
            if (input.Timestamp < 0)
                syntacticErrors.Add("input.Timestamp must be >= 0.");
            if (syntacticErrors.Count > 0)
                PresentSyntacticErrors(syntacticErrors);
            else
                ValidateSemantics(input);
        }

        private void PresentSyntacticErrors(List<string> syntacticErrors)
        {
            Debug.Assert(presenter != null);
            Debug.Assert(syntacticErrors != null);
            presenter.OnValidationError(new List<string>(syntacticErrors));
        }

        private void ValidateSemantics(Input input)
        {
            Debug.Assert(input != null);
            Debug.Assert(gateway != null);
            Debug.Assert(presenter != null);
            var semanticErrors = new List<string>();
            var isGuid = global::System.Guid.TryParse(
                input.Entity,
                out var entity);
            Debug.Assert(isGuid);
            var body = gateway.BodyFor(entity);
            if (body == null)
                semanticErrors.Add($"No body found for entity {entity}.");
            if (semanticErrors.Count > 0)
                PresentSemanticErrors(semanticErrors);
            else
                CreateMovement(input);
        }

        private void PresentSemanticErrors(List<string> semanticErrors)
        {
            Debug.Assert(presenter != null);
            Debug.Assert(semanticErrors != null);
            presenter.OnProcessingError(new List<string>(semanticErrors));
        }

        private void CreateMovement(Input input)
        {
            Debug.Assert(input != null);
            var isGuid = global::System.Guid.TryParse(
                input.Entity,
                out var entity);
            Debug.Assert(isGuid);
            Debug.Assert(input.SpeedMetersPerSecond >= 0);
            Debug.Assert(input.Timestamp >= 0);
            var destination = input.Destination;
            var speed = input.SpeedMetersPerSecond;
            var movement = Movement.TowardsDestinationWithSpeed(
                destination,
                speed);
            var addedMovement = gateway.Add(
                movement,
                input.Timestamp,
                entity);
            var output = new Output
            {
                Entity = entity.ToString(),
                Destination = addedMovement.Destination,
                SpeedMetersPerSecond = addedMovement.Speed
            };
            presenter.OnCreation(output);
        }
    }
}

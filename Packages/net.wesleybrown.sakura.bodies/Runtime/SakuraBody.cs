using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sakura.Bodies
{
    /// <summary>
    ///     A component that creates instances of systems related to bodies.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class SakuraBody
    :
        MonoBehaviour,
        RegisterBody.Presenter
    {
        [Header("Dependencies")]
        [Tooltip("The dependencies necessary for the systems contained within"
            + " the Sakura Bodies component")]
        public SakuraBodyDependencies dependencies;

        public string entityID = "";

        private PhysicalSimulation physicalSimulation;

        private void Start()
        {
            physicalSimulation = new PhysicalSimulation(
                dependencies.bodies,
                dependencies.movementSpeeds,
                dependencies.gameObjects);
            var registerBodySystem =
                physicalSimulation.RegisterBodySystem(this);
            registerBodySystem.Register(new RegisterBody.Input
            {
                Entity = new Guid(entityID),
                BodyLocation = transform.position
            });
        }

        /// <summary>
        ///     A <see cref="CollidableMovement.MovementSystem"/> that uses a
        ///     given <see cref="CharacterController"/> and
        ///     <see cref="CollidableMovement.CollidableMovementSystemPresenter"/>.
        /// </summary>
        /// <param name="characterController">
        ///     The <see cref="CharacterController"/>.
        /// </param>
        /// <param name="presenter">
        ///     The <see cref="CollidableMovement.CollidableMovementSystemPresenter"/>.
        /// </param>
        /// <returns>
        ///     A <see cref="CollidableMovement.CollidableMovement"/> that uses
        ///     the given <see cref="CharacterController"/> and
        ///     <see cref="CollidableMovement.CollidableMovementSystemPresenter"/>.
        /// </returns>
        public CollidableMovement.MovementSystem MovementSystem(
            CharacterController characterController,
            CollidableMovement.CollidableMovementSystemPresenter presenter)
        {
            return physicalSimulation.MovementSystem(
                characterController,
                presenter);
        }

        #region Sakura.Bodies.RegisterBody.Presenter
        public void Present(RegisterBody.Output output)
        {
            Debug.Log($"Entity {gameObject.name} registered at position {output.BodyLocation}.");
        }

        public void PresentInputErrors(List<string> inputErrors)
        {
            foreach (var error in inputErrors)
            {
                Debug.LogError(error);
            }
        }

        public void PresentOutputErrors(List<Exception> outputErrors)
        {
            foreach (var error in outputErrors)
            {
                Debug.LogError(error);
            }
        }
        #endregion
    }
}

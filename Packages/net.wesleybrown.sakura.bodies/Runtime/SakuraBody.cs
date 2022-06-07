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

        private void Start()
        {
            var registrations = RegisterBody.Data
                .InMemoryRegistrations
                .Of(dependencies.bodies);
            var system = RegisterBody.Registration
                .Of(
                    registrations,
                    this);
            system.Register(new RegisterBody.Input
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
            var movementSpeeds = CollidableMovement.Data
                .InMemoryMovementSpeeds
                .From(dependencies.movementSpeeds);
            var bodies = CollidableMovement.Data
                .InMemoryBodies
                .From(dependencies.bodies);
            var gameObjects = CollidableMovement.Data
                .InMemoryGameObjects
                .From(dependencies.gameObjects);
            var collisions = CollidableMovement.Data
                .CharacterControllerCollisions
                .WithControllerAndBodiesAndGameObjects(
                    characterController,
                    bodies,
                    gameObjects);
            var collidableBodies = CollidableMovement.Data
                .InMemoryCollidableBodies
                .WithCollections(
                    movementSpeeds,
                    bodies,
                    collisions);
            return CollidableMovement.CollidableMovementSystem
                .WithCollidableBodiesAndPresenter(
                    collidableBodies,
                    presenter);
        }

        /// <summary>
        ///     A <see cref="RegisterBody.System"/> that uses a given
        ///     <see cref="RegisterBody.Presenter"/>.
        /// </summary>
        /// <param name="presenter">
        ///     The <see cref="RegisterBody.Presenter"/>.
        /// </param>
        /// <returns>
        ///     A <see cref="RegisterBody.System"/> that uses the given
        ///     <see cref="RegisterBody.Presenter"/>.
        /// </returns>
        public RegisterBody.System RegisterBodySystem(
            RegisterBody.Presenter presenter)
        {
            var registrations = RegisterBody.Data
                .InMemoryRegistrations
                .Of(dependencies.bodies);
            return RegisterBody.Registration
                .Of(
                    registrations,
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

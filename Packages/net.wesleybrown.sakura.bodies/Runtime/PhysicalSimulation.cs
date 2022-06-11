using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sakura.Bodies
{
    /// <summary>
    ///     A factory that creates systems related to simulating physical bodies.
    /// </summary>
    public sealed class PhysicalSimulation
    {
        public PhysicalSimulation(
            Dictionary<Guid, Vector3> bodies,
            Dictionary<Guid, float> movementSpeeds,
            Dictionary<Guid, GameObject> gameObjects)
        {
            this.bodies = bodies;
            this.movementSpeeds = movementSpeeds;
            this.gameObjects = gameObjects;
        }

        private readonly Dictionary<Guid, Vector3> bodies;
        private readonly Dictionary<Guid, float> movementSpeeds;
        private readonly Dictionary<Guid, GameObject> gameObjects;

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
            Debug.Assert(this.bodies != null);
            Debug.Assert(this.movementSpeeds != null);
            Debug.Assert(this.gameObjects != null);
            var movementSpeeds = CollidableMovement.Data
                .InMemoryMovementSpeeds
                .From(this.movementSpeeds);
            var bodies = CollidableMovement.Data
                .InMemoryBodies
                .From(this.bodies);
            var gameObjects = CollidableMovement.Data
                .InMemoryGameObjects
                .From(this.gameObjects);
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
                .Of(bodies);
            return RegisterBody.Registration
                .Of(
                    registrations,
                    presenter);
        }
    }
}

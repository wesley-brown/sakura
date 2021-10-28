using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sakura.Bodies
{
    public sealed class BodiesComponent
    {
        public BodiesComponent(
            Dictionary<Guid, float> initialMovementSpeeds,
            Dictionary<Guid, Vector3> initialBodies,
            Dictionary<Guid, GameObject> initialGameObjects)
        {
            this.initialBodies = initialBodies;
            movementSpeeds = CollidableMovement
                .Data
                .InMemoryMovementSpeeds
                .From(initialMovementSpeeds);
            bodies = CollidableMovement
                .Data
                .InMemoryBodies
                .From(initialBodies);
            gameObjects = CollidableMovement
                .Data
                .InMemoryGameObjects
                .From(initialGameObjects);
        }

        private readonly Dictionary<Guid, Vector3> initialBodies;
        private readonly CollidableMovement.Data.MovementSpeeds movementSpeeds;
        private readonly CollidableMovement.Data.Bodies bodies;
        private readonly CollidableMovement.Data.GameObjects gameObjects;

        public CollidableMovement.MovementSystem MovementSystem(
            CharacterController characterController,
            CollidableMovement.CollidableMovementSystemPresenter presenter)
        {
            var collisions = CollidableMovement
                .Data
                .CharacterControllerCollisions
                .WithControllerAndBodiesAndGameObjects(
                    characterController,
                    bodies,
                    gameObjects);
            var collidableBodies = CollidableMovement
                .Data
                .InMemoryCollidableBodies
                .WithCollections(
                    movementSpeeds,
                    bodies,
                    collisions);
            return CollidableMovement
                .CollidableMovementSystem
                .WithCollidableBodiesAndPresenter(
                    collidableBodies,
                    presenter);
        }

        public RegisterBody.System RegisterBodySystem(
            RegisterBody.Presenter presenter)
        {
            var registrations = RegisterBody
                .Data
                .InMemoryRegistrations
                .Of(initialBodies);
            return RegisterBody
                .Registration
                .Of(
                    registrations,
                    presenter);
        }
    }
}

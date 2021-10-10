using System;
using System.Collections.Generic;
using Sakura.Bodies.CollidableMovement;
using Sakura.Bodies.CollidableMovement.Data;
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
            movementSpeeds =
                InMemoryMovementSpeeds.From(initialMovementSpeeds);
            bodies = InMemoryBodies.From(initialBodies);
            gameObjects = InMemoryGameObjects.From(initialGameObjects);
        }

        private readonly MovementSpeeds movementSpeeds;
        private readonly CollidableMovement.Data.Bodies bodies;
        private readonly GameObjects gameObjects;

        public MovementSystem MovementSystem(
            CharacterController characterController,
            CollidableMovementSystemPresenter presenter)
        {
            var collisions = CharacterControllerCollisions
                .WithControllerAndBodiesAndGameObjects(
                    characterController,
                    bodies,
                    gameObjects);
            var collidableBodies = InMemoryCollidableBodies
                .WithCollections(
                    movementSpeeds,
                    bodies,
                    collisions);
            return CollidableMovementSystem
                .WithCollidableBodiesAndPresenter(
                    collidableBodies,
                    presenter);
        }
    }
}

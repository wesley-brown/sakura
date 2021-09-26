using System;
using NUnit.Framework;
using Sakura.Core;
using Sakura.Data;
using UnityEngine;

namespace Character_Controller_Collisions_Spec
{
    [TestFixture]
    public class Creating_with_a_controller_and_bodies_and_game_objects
    {
        [Test]
        public void Does_not_support_a_null_controller()
        {
            CharacterController characterController = null;
            var bodies = new DummyBodies();
            var gameObjects = new DummyGameObjects();
            Assert.Throws<ArgumentNullException>(() =>
            {
                CharacterControllerCollisions
                    .WithControllerAndBodiesAndGameObjects(
                        characterController,
                        bodies,
                        gameObjects);
            });
        }

        [Test]
        public void Does_not_support_a_null_bodies()
        {
            var gameObject = new GameObject();
            var characterController =
                gameObject.AddComponent<CharacterController>();
            Bodies bodies = null;
            var gameObjects = new DummyGameObjects();
            Assert.Throws<ArgumentNullException>(() =>
            {
                CharacterControllerCollisions
                    .WithControllerAndBodiesAndGameObjects(
                        characterController,
                        bodies,
                        gameObjects);
            });
        }

        [Test]
        public void Does_not_support_a_null_game_objects()
        {
            var gameObject = new GameObject();
            var characterController =
                gameObject.AddComponent<CharacterController>();
            var bodies = new DummyBodies();
            GameObjects gameObjects = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                CharacterControllerCollisions
                    .WithControllerAndBodiesAndGameObjects(
                        characterController,
                        bodies,
                        gameObjects);
            });
        }
    }

    [TestFixture]
    public class A_body_moved_with_a_movement_that_does_cause_a_collision
    {
        [Test]
        public void Does_have_a_collision()
        {
            var characterControllerCollisions =
                CreateCharacterControllerCollisions();
            var movement = PlayerMovement();
            var playerBody = PlayerBody();
            var collision = characterControllerCollisions
                .CollisionCausedByMovingBody(
                    movement,
                    playerBody);
            Assert.IsNotNull(collision);
            Assert.AreEqual(
                playerBody.Entity,
                collision.Collider.Entity);
        }

        private static CharacterControllerCollisions
            CreateCharacterControllerCollisions()
        {
            var playerGameObject = CollidedGameObjects.ColliderGameObject;
            var playerCharacterController =
                playerGameObject.GetComponent<CharacterController>();
            var bodies = new CollidedBodies();
            var gameObjects = new CollidedGameObjects();
            return CharacterControllerCollisions
                .WithControllerAndBodiesAndGameObjects(
                    playerCharacterController,
                    bodies,
                    gameObjects);
        }

        private Movement PlayerMovement()
        {
            var playerDestination = new Vector3(5.0f, 0.0f, 0.0f);
            var playerSpeed = 5.0f;
            return Movement.TowardsDestinationWithSpeed(
                playerDestination,
                playerSpeed);
        }

        private Body PlayerBody()
        {
            return CollidedBodies.ColliderBody;
        }

        [Test]
        public void Has_its_game_object_positioned_at_its_location()
        {
            var characterControllerCollisions =
                CreateCharacterControllerCollisions();
            var movement = PlayerMovement();
            var playerBody = PlayerBody();
            Assert.AreEqual(
                playerBody.Location,
                CollidedGameObjects.ColliderGameObject.transform.position);
            characterControllerCollisions
                .CollisionCausedByMovingBody(
                    movement,
                    playerBody);
            Assert.AreEqual(
                playerBody.Location,
                CollidedGameObjects.ColliderGameObject.transform.position);
        }
    }
}

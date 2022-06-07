using System;
using System.Collections;
using NUnit.Framework;
using Sakura.Bodies.Core;
using Sakura.Bodies.CollidableMovement.Data;
using UnityEngine;
using UnityEngine.TestTools;

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
    public class Moving_a_body_with_a_movement
    {
        [SetUp]
        public void SetUp()
        {
            CollidedGameObjects.ColliderGameObject.SetActive(true);
            CollidedGameObjects.CollideeGameObject.SetActive(true);
        }

        [TearDown]
        public void TearDown()
        {
            CollidedGameObjects.ColliderGameObject.SetActive(false);
            CollidedGameObjects.CollideeGameObject.SetActive(false);
        }

        [Test]
        public void Does_not_support_a_null_movement()
        {
            var characterControllerCollisions =
                CreateCharacterControllerCollisions();
            Movement movement = null;
            var playerBody = PlayerBody();
            Assert.Throws<ArgumentNullException>(() =>
            {
                characterControllerCollisions
                     .CollisionCausedByMovingBody(
                         movement,
                         playerBody);
            });
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
        public void Does_not_support_a_null_body()
        {
            var characterControllerCollisions =
                CreateCharacterControllerCollisions();
            var movement = PlayerMovement();
            Body playerBody = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                characterControllerCollisions
                    .CollisionCausedByMovingBody(
                        movement,
                        playerBody);
            });
        }

        [Test]
        public void Keeps_its_game_object_where_it_was_after_calculating_the_caused_collision()
        {
            // This case is especially important when a game object is at a
            // different location than the body of the entity it represents.
            // This would most likely be due to interpolation.
            var characterControllerCollisions =
                CreateCharacterControllerCollisions();
            var movement = PlayerMovement();
            var playerBody = PlayerBody();
            var gameObjectPositionBeforeCalculatingCollision =
                CollidedGameObjects.ColliderGameObject.transform.position;
            characterControllerCollisions
                .CollisionCausedByMovingBody(
                    movement,
                    playerBody);
            Assert.AreEqual(
                gameObjectPositionBeforeCalculatingCollision,
                CollidedGameObjects.ColliderGameObject.transform.position);
        }

        [UnityTest]
        public IEnumerator Removes_the_extra_component_added_to_its_game_object_by_the_next_frame()
        {
            var characterControllerCollisions =
                CreateCharacterControllerCollisions();
            var movement = PlayerMovement();
            var playerBody = PlayerBody();
            characterControllerCollisions
                .CollisionCausedByMovingBody(
                    movement,
                    playerBody);
            yield return null;
            Assert.IsNull(
                CollidedGameObjects
                    .ColliderGameObject
                    .GetComponent<RecordCollidee>());
        }
    }

    [TestFixture]
    public class A_body_moved_with_a_movement_that_does_cause_a_collision
    {
        [SetUp]
        public void SetUp()
        {
            CollidedGameObjects.ColliderGameObject.SetActive(true);
            CollidedGameObjects.CollideeGameObject.SetActive(true);
        }

        [TearDown]
        public void TearDown()
        {
            CollidedGameObjects.ColliderGameObject.SetActive(false);
            CollidedGameObjects.CollideeGameObject.SetActive(false);
        }

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
    }

    [TestFixture]
    public class A_body_moved_with_a_movement_that_does_not_cause_a_collision
    {
        [SetUp]
        public void SetUp()
        {
            NonCollidedGameObjects.PlayerGameObject.SetActive(true);
            NonCollidedGameObjects.EnemyGameObject.SetActive(true);
        }

        [TearDown]
        public void TearDown()
        {
            NonCollidedGameObjects.PlayerGameObject.SetActive(false);
            NonCollidedGameObjects.EnemyGameObject.SetActive(false);
        }

        [Test]
        public void Does_not_have_a_collision()
        {
            var characterControllerCollisions =
                CreateCharacterControllerCollisions();
            var movement = PlayerMovement();
            var playerBody = PlayerBody();
            var collision = characterControllerCollisions
                .CollisionCausedByMovingBody(
                    movement,
                    playerBody);
            Assert.IsNull(collision);
        }

        private static CharacterControllerCollisions
            CreateCharacterControllerCollisions()
        {
            var playerGameObject = NonCollidedGameObjects.PlayerGameObject;
            var playerCharacterController =
                playerGameObject.GetComponent<CharacterController>();
            var bodies = new NonCollidedBodies();
            var gameObjects = new NonCollidedGameObjects();
            return CharacterControllerCollisions
                .WithControllerAndBodiesAndGameObjects(
                    playerCharacterController,
                    bodies,
                    gameObjects);
        }

        private static Movement PlayerMovement()
        {
            var playerDestination = new Vector3(5.0f, 0.0f, 0.0f);
            var playerSpeed = 5.0f;
            return Movement.TowardsDestinationWithSpeed(
                playerDestination,
                playerSpeed);
        }

        private static Body PlayerBody()
        {
            return NonCollidedBodies.PlayerBody;
        }
    }

    [TestFixture]
    public class A_body_whos_game_object_is_moved_into_another_collidable_game_object_not_for_a_body
    {
        [SetUp]
        public void SetUp()
        {
            OnlyColliderBodyGameObjects.Collider.SetActive(true);
            OnlyColliderBodyGameObjects.Collidee.SetActive(true);
        }

        [TearDown]
        public void TearDown()
        {
            OnlyColliderBodyGameObjects.Collider.SetActive(false);
            OnlyColliderBodyGameObjects.Collidee.SetActive(false);
        }

        [Test]
        public void Does_not_have_a_collision()
        {
            var characterControllerCollisions =
                CreateCharacterControllerCollisions();
            var movement = CreateMovement();
            var body = CreateBody();
            var collision = characterControllerCollisions
                .CollisionCausedByMovingBody(
                    movement,
                    body);
            Assert.IsNull(collision);
        }

        private static CharacterControllerCollisions
            CreateCharacterControllerCollisions()
        {
            var colliderGameObject = OnlyColliderBodyGameObjects.Collider;
            var characterController =
                colliderGameObject.GetComponent<CharacterController>();
            var bodies = new OnlyColliderBodyBodies();
            var gameObjects = new OnlyColliderBodyGameObjects();
            return CharacterControllerCollisions
                .WithControllerAndBodiesAndGameObjects(
                    characterController,
                    bodies,
                    gameObjects);
        }

        private static Movement CreateMovement()
        {
            var playerDestination = new Vector3(5.0f, 0.0f, 0.0f);
            var playerSpeed = 1.0f;
            return Movement.TowardsDestinationWithSpeed(
                playerDestination,
                playerSpeed);
        }

        private static Body CreateBody()
        {
            return OnlyColliderBodyBodies.Collider;
        }
    }
}

using System;
using NUnit.Framework;
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
    }
}

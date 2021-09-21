using System;
using NUnit.Framework;
using Sakura.Data;
using UnityEngine;

namespace Character_Controller_Collisions_Spec
{
    [TestFixture]
    public class Creating_with_a_controller_and_bodies
    {
        [Test]
        public void Does_not_support_a_null_controller()
        {
            CharacterController characterController = null;
            var bodies = new DummyBodies();
            Assert.Throws<ArgumentNullException>(() =>
            {
                CharacterControllerCollisions.WithControllerAndBodies(
                    characterController,
                    bodies);
            });
        }
    }
}

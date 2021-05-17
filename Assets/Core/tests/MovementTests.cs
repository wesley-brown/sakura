using System;
using NUnit.Framework;
using UnityEngine;

namespace Sakura.Core
{
    [TestFixture]
    public class Identical_movements
    {
        [Test]
        public void Have_the_same_hash_codes()
        {
            var ID = new Guid("e72a1ee5-f845-44e1-a196-1cf7999e6a66");
            var location = new Vector3(2.0f, 0.0f, 2.0f);
            var body = new Body(ID, location);
            var destination = new Vector3(3.0f, 0.0f, 2.0f);
            var movement = Movement.For(body, destination);
            var duplicateMovement = Movement.For(body, destination);
            Assert.AreEqual(
                movement.GetHashCode(),
                duplicateMovement.GetHashCode());
        }

        [Test]
        public void Are_equal()
        {
            var ID = new Guid("e72a1ee5-f845-44e1-a196-1cf7999e6a66");
            var location = new Vector3(2.0f, 0.0f, 2.0f);
            var body = new Body(ID, location);
            var destination = new Vector3(3.0f, 0.0f, 2.0f);
            var movement = Movement.For(body, destination);
            var duplicateMovement = Movement.For(body, destination);
            Assert.IsTrue(duplicateMovement.Equals(movement));
        }
    }
}

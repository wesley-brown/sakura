using System;
using NUnit.Framework;
using UnityEngine;

namespace Sakura.Core
{
    [TestFixture]
    public class A_movement
    {
        [Test]
        public void Throws_when_created_without_a_body()
        {
            var destination = new Vector3(-1.0f, 1.0f, -5.0f);
            Assert.Throws<ArgumentNullException>(() =>
            {
                Movement.For(null, destination);
            });
        }

        [Test]
        public void Has_a_custom_string_representation()
        {
            var ID = new Guid("3f480bfb-2f5c-41ce-ab4d-72a73cf10a9a");
            var location = new Vector3(-1.0f, 1.0f, 3.0f);
            var body = new Body(ID, location);
            var destination = new Vector3(-1.0f, 1.0f, -5.0f);
            var movement = Movement.For(body, destination);
            var expectedString = "{"
                + "Body="
                + movement.Body()
                + ", Location="
                + movement.Location()
                + "}";
            Assert.AreEqual(expectedString, movement.ToString());
        }
    }

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

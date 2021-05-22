using System;
using NUnit.Framework;
using Sakura.Movements;
using UnityEngine;

namespace Body_spec
{
    [TestFixture]
    public class A_body
    {
        [Test]
        public void Throws_when_created_with_the_nil_UUID()
        {
            var ID = Guid.Empty;
            var location = Vector3.zero;
            Assert.Throws<ArgumentException>(() =>
            {
                new Body(ID, location);
            });
        }

        [Test]
        public void Has_a_custom_string_representation()
        {
            var ID = new Guid("33294153-8a13-4a1d-b1b9-a8ae744463b2");
            var location = new Vector3(1.0f, 1.0f, 1.0f);
            var body = new Body(ID, location);
            var expectedString = "{"
                + "EntityID="
                + body.EntityID()
                + ", Location="
                + body.Location()
                + "}";
            Assert.AreEqual(expectedString, body.ToString());
        }
    }

    [TestFixture]
    public class Identical_bodies
    {
        [Test]
        public void Have_the_same_hash_codes()
        {
            var body = CreateBody();
            var duplicateBody = CreateBody();
            Assert.AreEqual(
                duplicateBody.GetHashCode(),
                body.GetHashCode());
        }

        [Test]
        public void Are_equal()
        {
            var body = CreateBody();
            var duplicateBody = CreateBody();
            Assert.IsTrue(duplicateBody.Equals(body));
        }

        private Body CreateBody()
        {
            var ID = new Guid("945b1142-2cb1-4df0-ba4e-901c028fce56");
            var location = new Vector3(12.0f, 4.5f, 1.25f);
            return new Body(ID, location);
        }
    }
}

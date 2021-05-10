using System;
using NUnit.Framework;
using UnityEngine;

namespace Sakura.Core.Bodies.Tests
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
}

using System;
using NUnit.Framework;
using Sakura.Bodies.Core;
using UnityEngine;

namespace Body_Spec
{
    [TestFixture]
    public class A_body
    {
        [Test]
        public void Cannot_be_created_for_the_nil_entity()
        {
            var entity = Guid.Empty;
            var location = Vector3.zero;
            Assert.Throws<ArgumentException>(() =>
            {
                Body.ForEntityLocatedAt(
                    entity,
                    location);
            });
        }

        [Test]
        public void Has_a_custom_string_representation()
        {
            var entity = new Guid("b860ea74-4e77-48ca-9d1b-1a0e7e47c4c3");
            var location = Vector3.zero;
            var body = Body.ForEntityLocatedAt(
                entity,
                location);
            var expectedString = "{"
                + "Entity="
                + entity
                + ", Location="
                + location
                + "}";
            var actualString = body.ToString();
            Assert.AreEqual(
                expectedString,
                actualString);
        }
    }

    [TestFixture]
    public class Teleporting_a_body_to_a_location
    {
        [Test]
        public void Creates_one_at_that_location()
        {
            var entity = new Guid("92baf1df-bf4c-4548-8410-60d25ac32315");
            var startingLocation = new Vector3(2.0f, 0.0f, 2.0f);
            var startingBody = Body.ForEntityLocatedAt(
                entity,
                startingLocation);
            var endingLocation = new Vector3(2.0f, 0.0f, 3.0f);
            var endingBody = startingBody.TeleportTo(endingLocation);
            Assert.AreEqual(
                endingLocation,
                endingBody.Location);
        }
    }
}

using System;
using NUnit.Framework;
using Sakura.Core;
using UnityEngine;

namespace Body_Temp_Spec
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
                BodyTemp.ForEntityLocatedAt(
                    entity,
                    location);
            });
        }

        [Test]
        public void Has_a_custom_string_representation()
        {
            var entity = new Guid("b860ea74-4e77-48ca-9d1b-1a0e7e47c4c3");
            var location = Vector3.zero;
            var body = BodyTemp.ForEntityLocatedAt(
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
}

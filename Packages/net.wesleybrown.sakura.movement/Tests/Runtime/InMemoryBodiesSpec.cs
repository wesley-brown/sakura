using System;
using NUnit.Framework;
using Sakura.Core;
using Sakura.Data;
using UnityEngine;

namespace In_Memory_Bodies_Spec
{
    [TestFixture]
    public class Adding_a_body
    {
        [Test]
        public void Does_not_support_a_null_body()
        {
            var bodies = new InMemoryBodies();
            Body body = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                bodies.AddBody(body);
            });
        }
    }

    [TestFixture]
    public class Adding_a_body_for_an_entity_without_one
    {
        [Test]
        public void Makes_that_body_the_one_for_that_entity()
        {
            var bodies = new InMemoryBodies();
            var entity = new Guid("eddc06dc-e22f-450b-a270-2c395716d1d9");
            Assert.IsNull(bodies.BodyForEntity(entity));
            var entityLocation = new Vector3(0.0f, 0.0f, 0.0f);
            var body = Body.ForEntityLocatedAt(
                entity,
                entityLocation);
            bodies.AddBody(body);
            var entitysBody = bodies.BodyForEntity(entity);
            Assert.IsNotNull(bodies.BodyForEntity(entity));
            Assert.AreEqual(
                entity,
                entitysBody.Entity);
        }
    }

    [TestFixture]
    public class Adding_a_body_for_an_entity_that_already_has_one
    {
        [Test]
        public void Makes_that_body_the_body_for_that_entity()
        {
            var bodies = ExistingBodies();
            var entity = new Guid("eddc06dc-e22f-450b-a270-2c395716d1d9");
            Assert.IsNotNull(bodies.BodyForEntity(entity));
            var entityLocation = new Vector3(5.0f, 0.0f, 5.0f);
            var body = Body.ForEntityLocatedAt(
                entity,
                entityLocation);
            bodies.AddBody(body);
            var entitysBody = bodies.BodyForEntity(entity);
            Assert.IsNotNull(bodies.BodyForEntity(entity));
            Assert.AreEqual(
                entity,
                entitysBody.Entity);
        }

        private static InMemoryBodies ExistingBodies()
        {
            var bodies = new InMemoryBodies();
            var entity = new Guid("eddc06dc-e22f-450b-a270-2c395716d1d9");
            var entityLocation = new Vector3(0.0f, 0.0f, 0.0f);
            var body = Body.ForEntityLocatedAt(
                entity,
                entityLocation);
            bodies.AddBody(body);
            return bodies;
        }
    }
}

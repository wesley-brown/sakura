﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sakura.Bodies.CollidableMovement.Data;
using Sakura.Bodies.Core;
using UnityEngine;

namespace In_Memory_Bodies_Spec
{
    [TestFixture]
    public class An_empty_in_memory_bodies
    {
        [Test]
        public void Does_not_have_any_bodies()
        {
            var entity = new Guid("3287aac0-a616-44d4-94ab-39c24aba887c");
            var bodies = InMemoryBodies.Empty();
            var actualBody = bodies.BodyForEntity(entity);
            Assert.IsNull(actualBody);
        }
    }

    [TestFixture]
    public class Creating_from_a_dictionary
    {
        [Test]
        public void Does_not_support_a_null_dictionary()
        {
            Dictionary<Guid, Vector3> initialBodies = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                InMemoryBodies.From(initialBodies);
            });
        }

        [Test]
        public void Includes_those_entries()
        {
            var entity = new Guid("eddc06dc-e22f-450b-a270-2c395716d1d9");
            var entityLocation = new Vector3(0.0f, 0.0f, 0.0f);
            var body = Body.ForEntityLocatedAt(
                entity,
                entityLocation);
            var initialBodies = new Dictionary<Guid, Vector3>
            {
                { entity, entityLocation }
            };
            var bodies = InMemoryBodies.From(initialBodies);
            var actualBody = bodies.BodyForEntity(entity);
            Assert.AreEqual(
                body.Entity,
                actualBody.Entity);
            Assert.AreEqual(
                body.Location,
                actualBody.Location);
        }
    }

    [TestFixture]
    public class Adding_a_body
    {
        [Test]
        public void Does_not_support_a_null_body()
        {
            var bodies = InMemoryBodies.Empty();
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
            var bodies = InMemoryBodies.Empty();
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
            var entitysBody = bodies.BodyForEntity(entity);
            Assert.IsNotNull(bodies.BodyForEntity(entity));
            Assert.AreEqual(
                entity,
                entitysBody.Entity);
        }

        private static InMemoryBodies ExistingBodies()
        {
            var entity = new Guid("eddc06dc-e22f-450b-a270-2c395716d1d9");
            var entityLocation = new Vector3(0.0f, 0.0f, 0.0f);
            var initialBodies = new Dictionary<Guid, Vector3>
            {
                { entity, entityLocation}
            };
            return InMemoryBodies.From(initialBodies);
        }
    }
}

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sakura.Bodies.Core;
using Sakura.Bodies.RegisterBody.Data;
using UnityEngine;

namespace In_Memory_Registrations_Spec
{
    [TestFixture]
    public class Creating_with_a_dictionary
    {
        [Test]
        public void Does_not_support_a_null_dictionary()
        {
            Dictionary<Guid, Body> initialBodies = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                InMemoryRegistrations.Of(initialBodies);
            });
        }
    }

    [TestFixture]
    public class Adding_a_body_for_an_entity
    {
        [Test]
        public void That_does_not_have_one_uses_that_body()
        {
            var initialBodies = new Dictionary<Guid, Body>();
            var registrations = InMemoryRegistrations.Of(initialBodies);
            var entity = new Guid("5ee573c8-805d-462d-84cf-1c60080b3e8a");
            var entityLocation = new Vector3(0.0f, 0.0f, 0.0f);
            var body = Body.ForEntityLocatedAt(
                entity,
                entityLocation);
            Assert.IsFalse(registrations.HasBodyFor(entity));
            registrations.Add(
                body,
                entity);
            Assert.IsTrue(registrations.HasBodyFor(entity));
            var addedBody = registrations.BodyFor(entity);
            Assert.AreEqual(
                entity,
                addedBody.Entity);
            Assert.AreEqual(
                entityLocation,
                addedBody.Location);
        }

        [Test]
        public void That_already_has_one_is_an_error()
        {
            var entity = new Guid("5ee573c8-805d-462d-84cf-1c60080b3e8a");
            var entityLocation = new Vector3(0.0f, 0.0f, 0.0f);
            var body = Body.ForEntityLocatedAt(
                entity,
                entityLocation);
            var initialBodies = new Dictionary<Guid, Body>
            {
                { entity, body }
            };
            var registrations = InMemoryRegistrations.Of(initialBodies);
            Assert.IsTrue(registrations.HasBodyFor(entity));
            Assert.Throws<InvalidOperationException>(() =>
            {
                registrations.Add(
                    body,
                    entity);
            });
        }
    }
}

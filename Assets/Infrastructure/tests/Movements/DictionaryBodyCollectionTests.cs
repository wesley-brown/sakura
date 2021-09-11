using System;
using NUnit.Framework;
using Sakura.Core;
using Sakura.Movements;
using UnityEngine;

namespace Dictionary_body_collection_spec
{
    [TestFixture]
    public class An_added_body
    {
        [Test]
        public void Can_be_retrieved()
        {
            var ID = new Guid("da68712c-cdcc-4bf8-8984-98032ef3aa4d");
            var location = new Vector3(1.0f, 1.0f, 1.0f);
            var body = Body.ForEntityLocatedAt(
                ID,
                location);
            AllBodies bodies = DictionaryBodyCollection.Empty();
            Assert.IsFalse(
                bodies.HasBodyFor(
                    body.Entity));
            bodies.Add(body);
            Assert.IsTrue(
                bodies.HasBodyFor(
                    body.Entity));
            var retrievedBody = bodies.For(body.Entity);
            Assert.AreEqual(body, retrievedBody);
        }
    }
}

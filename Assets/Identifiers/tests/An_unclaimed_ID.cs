﻿using System;
using NUnit.Framework;
using Sakura.Identifiers.Client;
using Sakura.Identifiers.Infrastructure;
using UnityEngine;

namespace Sakura.Identifiers.Tests
{
    [TestFixture]
    public class An_unclaimed_ID
    {
        [Test]
        public void can_be_claimed()
        {
            var ID = new Guid("2a6e749e-94b6-4f76-8b96-8217d361895e");
            var idRegistry = new DictionaryIdRegistry();
            var agent = new ClaimsAgent(idRegistry);
            Assert.IsFalse(agent.IsClaimed(ID));
            var gameObject = new GameObject("Entity");
            agent.ClaimIDFor(ID, gameObject.GetInstanceID());
            Assert.IsTrue(agent.IsClaimed(ID));
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}

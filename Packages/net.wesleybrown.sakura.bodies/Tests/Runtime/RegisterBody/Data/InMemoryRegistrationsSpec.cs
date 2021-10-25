using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sakura.Bodies.Core;
using Sakura.Bodies.RegisterBody.Data;

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
}

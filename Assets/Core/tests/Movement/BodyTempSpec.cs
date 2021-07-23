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
    }
}

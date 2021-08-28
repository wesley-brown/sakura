using System;
using NUnit.Framework;
using Sakura.Core;
using UnityEngine;

namespace Movement_Temp_Spec
{
    [TestFixture]
    public class Creating_a_movement_for_a_body_and_location
    {
        [Test]
        public void Does_not_support_a_null_body()
        {
            BodyTemp body = null;
            var location = new Vector3(10.0f, 10.0f, 10.0f);
            Assert.Throws<ArgumentNullException>(() =>
            {
                MovementTemp.For(
                    body,
                    location);
            });
        }
    }
}

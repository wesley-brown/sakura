using System;
using NUnit.Framework;
using Sakura.Core;
using UnityEngine;

namespace Movement_Temp_Spec
{
    [TestFixture]
    public class Creating_a_movement_for_a_body
    {
        [Test]
        public void Does_not_support_null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                MovementTemp.For(null);
            });
        }
    }
}

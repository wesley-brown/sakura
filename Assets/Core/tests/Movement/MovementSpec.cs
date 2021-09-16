using System;
using NUnit.Framework;
using Sakura.Core;
using UnityEngine;

namespace Movement_Spec
{
    [TestFixture]
    public class Creating_a_movement_towards_a_destination_with_a_speed
    {
        [TestCase(-0.99f)]
        [TestCase(-1.0f)]
        [TestCase(float.MinValue)]
        public void Does_not_support_a_negative_speed(float speed)
        {
            var destination = new Vector3(2.0f, 0.0f, 0.0f);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Movement.TowardsDestinationWithSpeed(
                    destination,
                    speed);
            });
        }
    }
}

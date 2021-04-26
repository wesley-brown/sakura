using System;
using NUnit.Framework;
using Sakura.DetectPlayerMovement.Client;

namespace PlayerMovementCheckSpec
{
    [TestFixture]
    public class A_player_movement_check
    {
        [Test]
        public void Throws_if_created_without_all_destination_inputs()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                PlayerMovementCheck.Against(null);
            });
        }
    }

    [TestFixture]
    public class When_the_player_moved_during_the_previous_frame
    {
        [Test]
        public void There_is_a_desired_destination()
        {
            var alwaysMoving = new AlwaysMoving();
            var check = PlayerMovementCheck.Against(alwaysMoving);
            Assert.IsTrue(check.PlayerMovedLastFrame());
            var destination = check.DesiredDestination();
            Assert.AreEqual(
                alwaysMoving.Destination,
                destination);
        }
    }

    [TestFixture]
    public class When_the_player_did_not_move_during_the_previous_frame
    {
        [Test]
        public void There_is_no_desired_destination()
        {
            var neverMoving = new NeverMoving();
            var check = PlayerMovementCheck.Against(neverMoving);
            Assert.IsFalse(check.PlayerMovedLastFrame());
            Assert.Throws<InvalidOperationException>(() =>
            {
                check.DesiredDestination();
            });
        }
    }
}

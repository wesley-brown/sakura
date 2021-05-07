using System;
using NUnit.Framework;

namespace Sakura.DetectPlayerMovement.Client.Tests
{
    [TestFixture]
    public class A_destination_check
    {
        [Test]
        public void Throws_if_created_without_all_destination_inputs()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                DestinationCheck.Against(null);
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
            var check = DestinationCheck.Against(alwaysMoving);
            Assert.IsTrue(check.PlayerMovedLastFrame());
            var destination = check.DesiredDestination();
            Assert.AreEqual(
                alwaysMoving.Destination,
                destination);
        }

        [Test]
        public void The_desired_destination_is_in_the_string_representation()
        {
            var alwaysMoving = new AlwaysMoving();
            var check = DestinationCheck.Against(alwaysMoving);
            var expectedString = "{"
                + "PlayerMovedLastFrame="
                + check.PlayerMovedLastFrame()
                + ", DesiredDestination="
                + check.DesiredDestination()
                + "}";
            Assert.AreEqual(expectedString, check.ToString());
        }
    }

    [TestFixture]
    public class When_the_player_did_not_move_during_the_previous_frame
    {
        [Test]
        public void There_is_no_desired_destination()
        {
            var neverMoving = new NeverMoving();
            var check = DestinationCheck.Against(neverMoving);
            Assert.IsFalse(check.PlayerMovedLastFrame());
            Assert.Throws<InvalidOperationException>(() =>
            {
                check.DesiredDestination();
            });
        }
    }
}

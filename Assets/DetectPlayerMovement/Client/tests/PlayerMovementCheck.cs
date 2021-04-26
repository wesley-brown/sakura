using NUnit.Framework;
using Sakura.DetectPlayerMovement.Client;

namespace PlayerMovementCheckSpec
{
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
}

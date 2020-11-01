using NUnit.Framework;
using UnityEngine;

namespace Sakura.StartGame.Domain.Tests
{
    sealed class EntitySpec
    {
        [Test]
        public void Entities_are_moved_a_given_amount()
        {
            var player = new GameObject("Player");
            var entity = player.AddComponent<Entity>();
            entity.Move(new Vector3(1.0f, 0.0f, 0.0f));
            Assert.That(
                entity.Location,
                Is.EqualTo(new Vector3(1.0f, 0.0f, 0.0f)));
        }
    }
}

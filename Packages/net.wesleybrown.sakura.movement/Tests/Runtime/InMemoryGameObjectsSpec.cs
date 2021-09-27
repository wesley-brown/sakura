using System;
using NUnit.Framework;
using Sakura.Data;

namespace In_Memory_Game_Objects_Spec
{
    [TestFixture]
    public class An_empty_collection_of_in_memory_game_objects
    {
        [Test]
        public void Has_no_game_objects()
        {
            var gameObjects = InMemoryGameObjects.Empty();
            var entity = new Guid("39de7404-4ac8-427a-9943-7a215ddc470b");
            Assert.IsNull(gameObjects.GameObjectForEntity(entity));
        }
    }
}

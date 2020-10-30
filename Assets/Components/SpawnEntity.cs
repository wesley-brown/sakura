using Sakura.Config;
using Sakura.StartGame.Main;
using Sakura.UnityComponents.Rendering;
using UnityEngine;

namespace Sakura.Components
{
    public sealed class SpawnEntity : Component
    {
        private readonly Entity spawner;
        private readonly Main main;
        private readonly EntityConfig config;

        public SpawnEntity(Entity spawner, Main main, EntityConfig config)
        {
            this.spawner = spawner;
            this.main = main;
            this.config = config;
        }

        public void Update()
        {
            var entity = main.SpawnEntity();
            var model = Object.Instantiate(config.ModelPrefab);
            model.GetComponent<UnityModel>().Entity = entity;
            spawner.Remove(this);
        }
    }
}

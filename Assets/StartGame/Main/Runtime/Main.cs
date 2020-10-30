using Sakura.Components;
using Sakura.Config;
using Sakura.Input;
using Sakura.UnityComponents.Rendering;
using System.Collections.Generic;
using UnityEngine;

namespace Sakura.StartGame.Main
{
    /// <summary>
    /// Acts as the main function.
    /// </summary>
    public sealed class Main : MonoBehaviour
    {
        [SerializeField] private WalletReference playersWallet = null;
        [SerializeField] private EntityConfig entityConfig = null;

        private MonoBehaviour windowController = null;

        private List<Entity> entities = null;
        private List<Entity> entitiesToAdd = null;

        private List<Model> models = null;
        private InputProcessor inputProcessor = null;
        private new Camera camera = null;
        private List<Interactable> interactables = null;
        private Entity player = null;

        private void Awake()
        {
            playersWallet.Wallet = new Wallet();

            entities = new List<Entity>();
            entitiesToAdd = new List<Entity>();

            models = new List<Model>();
            camera = Camera.main;
            interactables = new List<Interactable>();
        }

        public Entity Player
        {
            get
            {
                return player;
            }
        }

        public void RegisterWindowController(MonoBehaviour windowController)
        {
            if (this.windowController)
            {
                Destroy(this.windowController.gameObject);
            }
            this.windowController = windowController;
        }

        public Entity BindToNewEntity(UnityModel model)
        {
            var entity = new Entity(model.transform.position, 0.1f);
            if (model.gameObject.tag == "Player")
            {
                inputProcessor = new InputProcessor(
                    this,
                    camera,
                    entity,
                    interactables,
                    entityConfig);
                player = entity;
            }
            //else
            //{
            //    entity.Add(new MoveToDestination(entity, new Vector3(35.13f, 1.13f, -31.63f)));
            //}
            entities.Add(entity);
            models.Add(model);
            Debug.Log(
                "Registered pre-existing entity '"
                + model.gameObject.name
                + "'"
                + " at location "
                + entity.Location);
            return entity;
        }

        public void UnbindFromEntity(UnityModel model)
        {
            models.Remove(model);
        }

        /// <summary>
        /// Spawn a new entity on the next tick.
        /// </summary>
        /// <returns>The spawned entity.</returns>
        public Entity SpawnEntity()
        {
            var entity = new Entity(Vector3.zero, 0.1f);
            entitiesToAdd.Add(entity);
            return entity;
        }

        private void FixedUpdate()
        {
            // Add any entities waiting to be added
            foreach (var entity in entitiesToAdd)
            {
                entities.Add(entity);
            }
            entitiesToAdd.Clear();

            foreach (var entity in entities)
            {
                entity.Update();
            }
        }

        private void Update()
        {
            inputProcessor.ProcessInput();
        }
    }
}

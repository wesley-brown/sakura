﻿using Sakura.Components;
using System.Collections.Generic;
using UnityEngine;

namespace Sakura
{
    /// <summary>
    /// Acts as the main function.
    /// </summary>
    public sealed class Main : MonoBehaviour
    {
        [SerializeField] private WalletReference playersWallet = null;

        private MonoBehaviour windowController = null;
        private List<Entity> entities = null;
        private List<UnityModel> models = null;

        private void Awake()
        {
            playersWallet.Wallet = new Wallet();
            entities = new List<Entity>();
            models = new List<UnityModel>();
        }

        public void RegisterWindowController(MonoBehaviour windowController)
        {
            if (this.windowController)
            {
                Destroy(this.windowController.gameObject);
            }
            this.windowController = windowController;
        }

        public void BindToNewEntity(UnityModel model)
        {
            var entity = new Entity(model.transform.position, 0.1f);
            entity.Add(new MoveToDestination(entity, new Vector3(35.13f, 1.13f, -31.63f)));
            entities.Add(entity);
            model.Entity = entity;
            models.Add(model);
            Debug.Log(
                "Registered pre-existing entity '"
                + model.gameObject.name
                + "'"
                + " at location "
                + entity.Location);
        }

        public void UnbindFromEntity(UnityModel model)
        {
            models.Remove(model);
        }

        private void FixedUpdate()
        {
            foreach (var entity in entities)
            {
                entity.Update();
            }
        }
    }
}

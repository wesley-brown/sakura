using System;
using System.Collections.Generic;
using Sakura.Bodies;
using Sakura.Bodies.CollidableMovement;
using Sakura.DetectPlayerMovement.Client;
using UnityEngine;

namespace Sakura.DetectPlayerMovement.Unity
{
    /// <summary>
    ///     A component that detects player movement each frame.
    /// </summary>
    public sealed class DetectPlayerMovement
        : MonoBehaviour, CollidableMovementSystemPresenter
    {
        public DetectPlayerMovementConfig config;

        private void Start()
        {
            var initialMovementSpeeds = new Dictionary<Guid, float>
            {
                { entity, 0.0608f * 2 } // measured in meters / tick
            };
            var initialBodies = new Dictionary<Guid, Vector3>
            {
                { entity, gameObject.transform.position }
            };
            var initialGameObjects = new Dictionary<Guid, GameObject>
            {
                { entity, gameObject }
            };
            var bodiesComponent = new BodiesComponent(
                initialMovementSpeeds,
                initialBodies,
                initialGameObjects);
            var characterController = GetComponent<CharacterController>();
            movementSystem = bodiesComponent.MovementSystem(
                characterController,
                this);
            transform = GetComponent<Transform>();
            destination = transform.position;
        }

        private MovementSystem movementSystem;
        private readonly Guid entity =
            new Guid("7b116831-5b7b-4ceb-972c-93b0221c4ccc");
        private new Transform transform;
        private Vector3 destination;

        private void FixedUpdate()
        {
            var check = DestinationCheck.Against(config.Create());
            if (check.PlayerMovedLastFrame())
            {
                var y = gameObject.transform.position.y;
                var destination = check.DesiredDestination();
                movementSystem.MoveEntityTowardsDestination(
                    entity,
                    new Vector3(destination.x, y, destination.z));
            }
        }

        private void Update()
        {
            var lag = Time.time - Time.fixedTime;
            var alpha = lag / Time.fixedDeltaTime;
            transform.position = Vector3.Lerp(
                transform.position,
                destination,
                alpha);
        }

        /// <inheritdoc/>
        public void Present(CollidableMovement collidableMovement)
        {
            destination = collidableMovement.EndingLocation;
        }

        /// <inheritdoc/>
        public void ReportError(string error)
        {
            Debug.LogError(error);
        }
    }
}

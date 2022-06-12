using System;
using System.Collections.Generic;
using Sakura.Entities;
using UnityEngine;

namespace Sakura.Bodies
{
    /// <summary>
    ///     A component that creates instances of systems related to bodies.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SakuraEntity))]
    [RequireComponent(typeof(Transform))]
    public sealed class SakuraBody
    :
        MonoBehaviour,
        RegisterBody.Presenter
    {
        private static Dictionary<Guid, Vector3> bodies =
            new Dictionary<Guid, Vector3>();
        private static Dictionary<Guid, float> movementSpeeds =
            new Dictionary<Guid, float>();

        [Header("Properties")]
        [Tooltip("How many meters per second this body can move.")]
        public float movementSpeed;

        private void Awake()
        {
            entity = GetComponent<SakuraEntity>();
            transform = GetComponent<Transform>();
        }

        private SakuraEntity entity;
        private new Transform transform;

        private void Start()
        {
            physicalSimulation = new PhysicalSimulation(
                bodies,
                movementSpeeds,
                SakuraEntity.GameObjects);
            var registerBodySystem =
                physicalSimulation.RegisterBodySystem(this);
            if (entity.IDasGuid != null)
            {
                registerBodySystem.Register(new RegisterBody.Input
                {
                    Entity = entity.IDasGuid.Value,
                    BodyLocation = transform.position
                });
                movementSpeeds.Add(
                    entity.IDasGuid.Value,
                    movementSpeed);
            }
            else
            {
                Debug.LogError(
                    "A body can only be registered for an entity."
                        + $" Game object '{gameObject.name}' is not"
                        + " bound to an entity.",
                    this);
            }
        }

        private PhysicalSimulation physicalSimulation;

        /// <summary>
        ///     A <see cref="CollidableMovement.MovementSystem"/> that uses a
        ///     given <see cref="CharacterController"/> and
        ///     <see cref="CollidableMovement.CollidableMovementSystemPresenter"/>.
        /// </summary>
        /// <param name="characterController">
        ///     The <see cref="CharacterController"/>.
        /// </param>
        /// <param name="presenter">
        ///     The <see cref="CollidableMovement.CollidableMovementSystemPresenter"/>.
        /// </param>
        /// <returns>
        ///     A <see cref="CollidableMovement.CollidableMovement"/> that uses
        ///     the given <see cref="CharacterController"/> and
        ///     <see cref="CollidableMovement.CollidableMovementSystemPresenter"/>.
        /// </returns>
        public CollidableMovement.MovementSystem MovementSystem(
            CharacterController characterController,
            CollidableMovement.CollidableMovementSystemPresenter presenter)
        {
            return physicalSimulation.MovementSystem(
                characterController,
                presenter);
        }

        #region Sakura.Bodies.RegisterBody.Presenter
        public void Present(RegisterBody.Output output)
        {
            Debug.Log(
                $"Body for entity {output.Entity}"
                    + $" registered at position {output.BodyLocation}.",
                this);
        }

        public void PresentInputErrors(List<string> inputErrors)
        {
            foreach (var error in inputErrors)
            {
                Debug.LogError(
                    error,
                    this);
            }
        }

        public void PresentOutputErrors(List<Exception> outputErrors)
        {
            foreach (var error in outputErrors)
            {
                Debug.LogError(
                    error,
                    this);
            }
        }
        #endregion
    }
}

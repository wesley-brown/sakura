using System;
using System.Collections.Generic;
using Sakura.Bodies;
using Sakura.Bodies.CollidableMovement;
using UnityEngine;

namespace Sakura.Player
{
    /// <summary>
    ///     The player.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(SakuraBody))]
    [RequireComponent(typeof(SakuraEntity))]
    public sealed class TestPlayer
    :
        MonoBehaviour,
        Bodies.RegisterBody.Presenter,
        CollidableMovementSystemPresenter
    {
        [Header("Movement")]
        [Tooltip("How many meters this player can move per tick")]
        public float movementSpeed;

        private SakuraEntity entity;
        private SakuraBody body;
        private CharacterController characterController;
        private MovementSystem movementSystem;
        private Vector3 previousLocation;
        private Vector3 currentLocation;

        private void Awake()
        {
            entity = GetComponent<SakuraEntity>();
            body = GetComponent<SakuraBody>();
            characterController = GetComponent<CharacterController>();
            movementSystem = body.MovementSystem(
                characterController,
                this);
        }

        private void Start()
        {
            var input = new Bodies.RegisterBody.Input
            {
                Entity = new Guid(entity.ID),
                BodyLocation = transform.position
            };
            previousLocation = transform.position;
            currentLocation = transform.position;
        }

        private void Update()
        {
            var lag = Time.time - Time.fixedTime;
            var alpha = lag / Time.fixedDeltaTime;
            transform.position = Vector3.Lerp(
                previousLocation,
                currentLocation,
                alpha);
        }

        #region Bodies.RegisterBody.Presenter
        public void Present(Bodies.RegisterBody.Output output)
        {
            Debug.Log("Registered body for entity " + output.Entity);
        }

        public void PresentInputErrors(List<string> inputErrors)
        {
            foreach (var inputError in inputErrors)
            {
                Debug.LogError(inputError);
            }
        }

        public void PresentOutputErrors(List<Exception> outputErrors)
        {
            foreach (var outputError in outputErrors)
            {
                Debug.LogError(outputError.Message);
            }
        }
        #endregion

        #region Bodies.CollidableMovement.CollidableMovementSystemPresenter
        public void ReportError(string error)
        {
            throw new NotImplementedException();
        }

        public void Present(CollidableMovement collidableMovement)
        {
            previousLocation = currentLocation;
            currentLocation = collidableMovement.EndingLocation;
        }
        #endregion
    }
}

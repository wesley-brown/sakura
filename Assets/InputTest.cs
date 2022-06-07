using System;
using Sakura;
using Sakura.Bodies;
using Sakura.Bodies.CollidableMovement;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(SakuraBody))]
[RequireComponent(typeof(SakuraEntity))]
[RequireComponent(typeof(SakuraInput))]
[RequireComponent(typeof(Transform))]
public sealed class InputTest
:
    MonoBehaviour,
    Sakura.Bodies.CollidableMovement.CollidableMovementSystemPresenter
{
    private CharacterController characterController;
    private SakuraBody sakuraBody;
    private SakuraEntity sakuraEntity;
    private SakuraInput sakuraInput;
    private new Transform transform;

    private Sakura.Bodies.CollidableMovement.MovementSystem movementSystem;

    private Vector3 entityLocation;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        sakuraBody = GetComponent<SakuraBody>();
        sakuraEntity = GetComponent<SakuraEntity>();
        sakuraInput = GetComponent<SakuraInput>();
        transform = GetComponent<Transform>();
    }

    private void Start()
    {
        Debug.Assert(sakuraBody != null);
        Debug.Assert(characterController != null);
        Debug.Assert(transform != null);
        movementSystem = sakuraBody.MovementSystem(
            characterController,
            this);
        entityLocation = transform.position;
    }

    private void FixedUpdate()
    {
        Debug.Assert(sakuraInput != null);
        var playerClicked = sakuraInput.GetMouseButton(0);
        if (playerClicked)
        {
            var mousePosition = Input.mousePosition;
            MoveTowardsTouchedPosition(mousePosition);
        }

        //var screenWasTouched = sakuraInput.touchCount > 0;
        //if (screenWasTouched)
        //{
        //    var touch = sakuraInput.GetTouch(0);
        //    if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId)
        //            && touch.phase == TouchPhase.Moved)
        //    {
        //        MoveTowardsTouchedPosition(touch.position);
        //    }
        //}
    }

    private void Update()
    {
        Debug.Assert(transform != null);
        var lag = Time.time - Time.fixedDeltaTime;
        var alpha = lag * Time.fixedDeltaTime;
        transform.position = Vector3.Lerp(
            transform.position,
            entityLocation,
            alpha);
    }

    private void MoveTowardsTouchedPosition(Vector2 touchedPosition)
    {
        Debug.Assert(transform != null);
        Debug.Assert(movementSystem != null);
        Debug.Assert(sakuraEntity != null);
        var ray = Camera.main.ScreenPointToRay(touchedPosition);
        RaycastHit hit;
        bool didHit = Physics.Raycast(
            ray,
            out hit,
            float.PositiveInfinity);

        // Adjust for y level of player
        var destination = new Vector3(
            hit.point.x,
            transform.position.y,
            hit.point.z);

        if (didHit && (hit.collider.gameObject != gameObject))
        {
            movementSystem.MoveEntityTowardsDestination(
                new Guid(sakuraEntity.ID),
                destination);
        }
    }

    #region Sakura.Bodies.CollidableMovement.CollidableMovementSystemPresenter
    public void ReportError(string error)
    {
        Debug.LogError(error);
    }

    public void Present(CollidableMovement collidableMovement)
    {
        entityLocation = collidableMovement.EndingLocation;
    }
    #endregion
}

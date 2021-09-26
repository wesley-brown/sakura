using System;
using Sakura.Core;

namespace Sakura.Data
{
    /// <summary>
    ///     A <see cref="Collisions"/> that uses a
    ///     <see cref="UnityEngine.CharacterController"/>.
    /// </summary>
    sealed class CharacterControllerCollisions : Collisions
    {
        /// <summary>
        ///     Create a <see cref="CharacterControllerCollisions"/> with a
        ///     given <see cref="UnityEngine.CharacterController"/>,
        ///     <see cref="Bodies"/>, and <see cref="GameObjects"/>.
        /// </summary>
        /// <param name="controller">
        ///     The <see cref="CharacterController"/>.
        /// </param>
        /// <param name="bodies">
        ///     The <see cref="Bodies"/>.
        /// </param>
        /// <param name="gameObjects">
        ///     The <see cref="GameObjects"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given
        ///     <see cref="UnityEngine.CharacterController"/> is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given <see cref="Bodies"/> is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given <see cref="GameObjects"/> is null.
        /// </exception>
        internal static CharacterControllerCollisions
            WithControllerAndBodiesAndGameObjects(
                UnityEngine.CharacterController controller,
                Bodies bodies,
                GameObjects gameObjects)
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));
            if (bodies == null)
                throw new ArgumentNullException(nameof(bodies));
            if (gameObjects == null)
                throw new ArgumentNullException(nameof(gameObjects));
            return new CharacterControllerCollisions(
                controller,
                bodies,
                gameObjects);
        }

        private CharacterControllerCollisions(
            UnityEngine.CharacterController controller,
            Bodies bodies,
            GameObjects gameObjects)
        {
            UnityEngine.Debug.Assert(controller != null);
            this.controller = controller;
            UnityEngine.Debug.Assert(bodies != null);
            this.bodies = bodies;
            UnityEngine.Debug.Assert(gameObjects != null);
            this.gameObjects = gameObjects;
        }

        private readonly UnityEngine.CharacterController controller;
        private readonly Bodies bodies;
        private readonly GameObjects gameObjects;

        /// <inheritdoc/>
        public Collision CollisionCausedByMovingBody(
            Movement movement,
            Body body)
        {
            if (movement == null)
                throw new ArgumentNullException(nameof(movement));
            var move = MoveBody(movement, body);
            var gameObject = gameObjects.GameObjectForEntity(body.Entity);
            return MoveGameObjectWithCollisions(
                gameObject,
                move);
        }

        private UnityEngine.Vector3 MoveBody(
            Movement movement,
            Body body)
        {
            var movedBody = movement.Move(body);
            return movedBody.Location - body.Location;
        }

        private Collision MoveGameObjectWithCollisions(
            UnityEngine.GameObject colliderGameObject,
            UnityEngine.Vector3 move)
        {
            var recordCollidee =
                colliderGameObject.AddComponent<RecordCollidee>();
            controller.Move(move);
            var collideeGameObject = recordCollidee.Collidee;
            UnityEngine.Object.Destroy(recordCollidee);
            if (collideeGameObject == null)
                return null;
            return CollisionBetweenGameObjects(
                colliderGameObject,
                collideeGameObject);
        }

        private Collision CollisionBetweenGameObjects(
            UnityEngine.GameObject colliderGameObject,
            UnityEngine.GameObject collideeGameObject)
        {
            var colliderEntity =
                gameObjects.EntityForGameObject(colliderGameObject);
            var collideeEntity =
                gameObjects.EntityForGameObject(collideeGameObject);
            var colliderBody = bodies.BodyForEntity(colliderEntity);
            var resolvedColliderBody =
                colliderBody.TeleportTo(colliderGameObject.transform.position);
            colliderGameObject.transform.position = colliderBody.Location;
            var collideeBody = bodies.BodyForEntity(collideeEntity);
            var collision = Collision.BetweenBodies(
                resolvedColliderBody,
                collideeBody);
            return collision;
        }
    }
}

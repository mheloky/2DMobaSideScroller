using Assets;
using System.Collections.Generic;
using UnityEngine;

namespace Physics
{
    public class GravityForceManager
    {
        #region Properties
        float gravityModifier = 1f;
        #endregion

        public GravityForceManager(PhysicsObject physicsObjects)
        {
            
        }

        public void ApplyGravityWithCollision(PhysicsObject physicsObjects, Rigidbody2D rigidbody2D,CollisionManager collisionManager, MovementManager theMovementManager)
        {
            physicsObjects.Velocity += GetGravityVelocity();
            ExecuteGravity(physicsObjects, rigidbody2D, collisionManager, theMovementManager);
        }

        void ExecuteGravity(PhysicsObject physicsObjects, Rigidbody2D rigidbody2D, CollisionManager collisionManager, MovementManager theMovementManager)
        {
            var deltaPosition = physicsObjects.Velocity * Time.deltaTime;
            var nextMovePosition = Vector2.up * deltaPosition.y;
            theMovementManager.MoveWithCollision(nextMovePosition, physicsObjects, rigidbody2D, collisionManager, true);
        }

        Vector2 GetGravityVelocity()
        {
            return gravityModifier * Physics2D.gravity * Time.deltaTime;
        }
    }

}
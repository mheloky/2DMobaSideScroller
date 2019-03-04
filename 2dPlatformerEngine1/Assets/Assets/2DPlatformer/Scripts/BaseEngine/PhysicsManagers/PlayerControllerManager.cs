using Assets._2DPlatformer.Scripts.BaseEngine.PhysicsManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class PlayerControllerManager: APlayerControllerManager
    {

        public PlayerControllerManager()
        {
          
        }

        public void MoveWithCollision(PhysicsObject physicsObjects, Rigidbody2D rigidbody2D, CollisionManager collisionManager, MovementManager theMovementManager)
        {
            physicsObjects.Velocity = new  Vector2(physicsObjects.TargetVelocity.x, physicsObjects.Velocity.y);
            var deltaPosition = physicsObjects.Velocity * Time.deltaTime;
            
            Vector2 moveAlongGround = new Vector2(theMovementManager.groundNormal.y, -theMovementManager.groundNormal.x);
            var nextMovePosition = moveAlongGround * deltaPosition.x;
            theMovementManager.MoveWithCollision(nextMovePosition, physicsObjects, rigidbody2D, collisionManager, false);
        }
    }
}

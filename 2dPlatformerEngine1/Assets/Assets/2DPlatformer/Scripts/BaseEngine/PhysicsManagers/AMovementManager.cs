using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._2DPlatformer.Scripts.BaseEngine.PhysicsManagers
{
    public interface AMovementManager
    {
         void MoveWithCollision(Vector2 nextMovePosition, PhysicsObject physicsObjects, Rigidbody2D rigidbody2D, CollisionManager collisionManager, bool yMovement);
    }
}

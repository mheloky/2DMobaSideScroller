using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._2DPlatformer.Scripts.BaseEngine.PhysicsManagers
{
    public interface APlayerControllerManager
    {
        void MoveWithCollision(PhysicsObject physicsObjects, Rigidbody2D rigidbody2D, CollisionManager collisionManager, MovementManager theMovementManager);
    }
}

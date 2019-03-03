using Assets;
using Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PhysicsObjects
{
    public interface APhysicsObject
    {
        Vector2 Velocity
        {
            get;
            set;
        }
        Vector2 TargetVelocity
        {
            get;
            set;
        }
        float TheMaxSpeed
        {
            get;
            set;
        }
        float TheJumpSpeed
        {
            get;
            set;
        }
        Rigidbody2D TheRigidbody2D
        {
            get;
            set;
        }
        GravityForceManager TheGravityManager
        {
            get;
            set;
        }
        CollisionManager TheCollisionManager
        {
            get;
            set;
        }
        PhysicsObjectStatus ThePhysicsObjectStatus
        {
            get;
            set;
        }
        PlayerControllerManager ThePlayerControllerManager
        {
            get;
            set;
        }
        MovementManager TheMovementManager
        {
            get;
            set;
        }
        RaycastHit2D[] CollidedItems
        {
            get;
            set;
        }
    }
}

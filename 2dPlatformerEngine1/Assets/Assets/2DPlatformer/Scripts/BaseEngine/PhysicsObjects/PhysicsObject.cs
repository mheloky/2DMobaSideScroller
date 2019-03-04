using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Physics;
using Assets;
using PhysicsObjects;
using System;

public class PhysicsObject : MonoBehaviour, APhysicsObject  {

    #region Properties

    Vector2 _velocity;
    public Vector2 Velocity
    {
        get
        {
            return _velocity;
        }
        set
        {
            _velocity = value;
        }
    }
    public Vector2 TargetVelocity
    {
        get;
        set;
    }
    public float maxSpeed = 4;
    public float TheMaxSpeed
    {
        get
        {
            return maxSpeed;
        }
        set
        {
            maxSpeed =value;
        }
    }
    public float JumpSpeed = 7;
    public float TheJumpSpeed
    {
        get
        {
            return JumpSpeed;
        }
        set
        {
            JumpSpeed = value;
        }
    }
    public Rigidbody2D TheRigidbody2D
    {
        get;
        set;
    }
    public GravityForceManager TheGravityManager
    {
        get;
        set;
    }
    public CollisionManager TheCollisionManager
    {
        get;
        set;
    }
    public PhysicsObjectStatus ThePhysicsObjectStatus
    {
        get;
        set;
    }
    public PlayerControllerManager ThePlayerControllerManager
    {
        get;
        set;
    }
    public MovementManager TheMovementManager
    {
        get;
        set;
    }
    public RaycastHit2D[] CollidedItems
    {
        get;
        set;
    }
    #endregion

    // Use this for initialization
    public PhysicsObject() {
        
        TheRigidbody2D = GetComponent<Rigidbody2D>();
        TheGravityManager = new GravityForceManager(this);
        ThePhysicsObjectStatus = new PhysicsObjectStatus();
        TheCollisionManager = new CollisionManager(gameObject.layer);
        ThePlayerControllerManager = new PlayerControllerManager();
        TheMovementManager = new MovementManager();
        TheCollisionManager.CollisionDetected += TheCollisionManager_CollisionDetected;
    }

    private void TheCollisionManager_CollisionDetected(RaycastHit2D[] obj)
    {
        lock (CollidedItems)
        {
            CollidedItems = obj;
        }
    }

    void FixedUpdate()
    {
        TargetVelocity = Vector2.zero;
        ExecutePerFrame();
        ThePlayerControllerManager.MoveWithCollision(this, TheRigidbody2D, TheCollisionManager, TheMovementManager);
        TheGravityManager.ApplyGravityWithCollision(this, TheRigidbody2D, TheCollisionManager, TheMovementManager);
    }

    void ExecuteJumpLogic(bool jump)
    {
        if (jump && ThePhysicsObjectStatus.isGrounded)
        {
            Velocity = new Vector2(Velocity.x, TheJumpSpeed);
        }
        else if (jump)
        {
            var y = Velocity.y > 0 ? Velocity.y * .5f : Velocity.y;
            Velocity = new Vector2(Velocity.x, y);
        }
    }

    #region Helper Methods
    protected virtual void ExecutePerFrame()
    {

    }
    #endregion
}

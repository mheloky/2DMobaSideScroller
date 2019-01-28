using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Physics;
using Assets;

public class PhysicsObject : MonoBehaviour {

    #region Properties
    public Vector2 Velocity;
    public Vector2 targetVelocity;
    protected Rigidbody2D rigidbody2D
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
    MovementManager TheMovementManager
    {
        get;
        set;
    }
    #endregion

    // Use this for initialization
    void Start () {

        rigidbody2D = GetComponent<Rigidbody2D>();
        TheGravityManager = new GravityForceManager(this);
        ThePhysicsObjectStatus = new PhysicsObjectStatus();
        TheCollisionManager = new CollisionManager(this.GetGameObject().layer);
        ThePlayerControllerManager = new PlayerControllerManager();
        TheMovementManager = new MovementManager();
    }

    void FixedUpdate()
    {
        targetVelocity = Vector2.zero;
        ExecutePerFrame();
        ThePlayerControllerManager.MoveWithCollision(this, GetComponent<Rigidbody2D>(), TheCollisionManager, TheMovementManager);
        TheGravityManager.ApplyGravityWithCollision(this, rigidbody2D, TheCollisionManager, TheMovementManager);

    }

    #region Helper Methods
    protected virtual void ExecutePerFrame()
    {

    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
    #endregion
}

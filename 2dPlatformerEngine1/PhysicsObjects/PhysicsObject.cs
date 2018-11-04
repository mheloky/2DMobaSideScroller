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
    public GravityForceManager gravityManager
    {
        get;
        set;
    }
    CollisionManager TheCollisionManager
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
        gravityManager = new GravityForceManager(this);
        ThePhysicsObjectStatus = new PhysicsObjectStatus();
        TheCollisionManager = new CollisionManager(this.GetGameObject().layer);
        ThePlayerControllerManager = new PlayerControllerManager();
        TheMovementManager = new MovementManager();
    }
	
	// Update is called once per frame
	void Update () {
      
	}

    protected virtual void ComputeVelocity()
    {

    }

    void FixedUpdate()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
        ThePlayerControllerManager.MoveWithCollision(this,GetComponent<Rigidbody2D>(), TheCollisionManager, TheMovementManager);
        gravityManager.ApplyGravityWithCollision(this, rigidbody2D, TheCollisionManager, TheMovementManager);
   
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

}

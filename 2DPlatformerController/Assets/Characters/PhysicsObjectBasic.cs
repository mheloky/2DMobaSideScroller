using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsObjectBasic : MonoBehaviour
{
    #region Properties
    DeltaManager TheDeltaManager
    {
        get;
        set;
    }
    public CollisionDetectionManager TheCollisionDetector
    {
        get;
        set;
    }
    /// <summary>
    /// Allows us to change gravity (.5 would halve gravity velocity);
    /// </summary>
    public float GravityModifier
    {
        get;
        set;
    }
    Rigidbody2D RigidBody
    {
        get;
        set;
    }
    protected Vector2 TargetVelocity
    {
        get;
        set;
    }
    protected Vector2 velocity;
    /// <summary>
    /// Makes sure we dont get stuck inside anothjer collider
    /// </summary>
    public float ShellRadius 
    {
        get;
        set;
    }
    public MovementAttributes movementAttributes = new MovementAttributes();
    #endregion
    #region Helper Methods
    void OnEnable()
    {
        Init();
        
    }

    private void Init()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        TheDeltaManager = new DeltaManager();
        TheCollisionDetector = new CollisionDetectionManager(RigidBody);
        GravityModifier = 1f;
        //ShellRadius = .01f;
        ShellRadius = .01f;
    }

    void Update()
    {
        TargetVelocity = Vector2.zero;
      ComputeVelocity();
    }
    #endregion

    #region Key Methods
    protected virtual void ComputeVelocity()
    {

    }

    void FixedUpdate()
    {
        velocity += TheDeltaManager.GetDelta(GravityModifier * Physics2D.gravity);
        velocity.x = TargetVelocity.x;

        Vector2 deltaPosition = TheDeltaManager.GetDelta(velocity);

        var moveAlongGround = new Vector2(TheCollisionDetector.GroundNormal.y, -TheCollisionDetector.GroundNormal.x);
        var move = moveAlongGround * deltaPosition.x;

        Movement(move, false);
        move = Vector2.up * deltaPosition.y;
        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
        var distance = move.magnitude;
        TheCollisionDetector.Detect(RigidBody, move,velocity, ShellRadius, yMovement);
        //dont check collision if not moving (more efficient)
        RigidBody.position += move.normalized * TheCollisionDetector.DistanceToMove;
    }

    public Vector2 GetVelocity()
    {
        return velocity;
    }
    #endregion
}

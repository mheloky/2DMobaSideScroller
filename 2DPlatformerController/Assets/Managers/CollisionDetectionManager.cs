using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionManager
{
    #region Properties and Field
    ContactFilter2D contactFilter = new ContactFilter2D();
    private bool _isGrounded;
    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
    }
    public float MinGroundNormalY
    {
        get;
        set;
    }
    public float MinMoveDistance
    {
        get;
        set;
    }
    public float DistanceToMove
    {
        get;
        set;
    }
    public Vector2 GroundNormal
    {
        get;
        set;
    }

    public delegate void CollisionDetected(RaycastHit2D secondaryCollider, Rigidbody2D primaryCollider);
    public event CollisionDetected CollisionDetectedEvent;
    #endregion

    public CollisionDetectionManager(Rigidbody2D rigidBody)
    {
      
        contactFilter.useTriggers = false;

        MinMoveDistance = 0.001f;
        MinGroundNormalY = .65f;
    }

    public void Detect(Rigidbody2D rigidBody, Vector2 moveVector, Vector2 velocity, float shellRadius, bool yMovement)
    {
            _isGrounded = false;
            DistanceToMove = 0;

            var distance = moveVector.magnitude;

            if (distance > MinMoveDistance)
            {
                var hitBuffer = new RaycastHit2D[16];
                var hitBufferList = new List<RaycastHit2D>(16);

                //Think ahead to the next frame and know what items are we going to collide with
                int count = rigidBody.Cast(moveVector, contactFilter, hitBuffer, moveVector.magnitude + shellRadius);
                hitBufferList.Clear();
                //Get a collection of what items we will collide with
                for (int i = 0; i < count; i++)
                {
                    hitBufferList.Add(hitBuffer[i]);
                }

                //For each collidind item, if the normal vector is horizontal enough (.65) then we are grounded
                foreach (var hitBufferListItem in hitBufferList)
                {

                    //If the normal of the vector means we are standing on a ground and
                    //at an angle that is flat enough then we are grounded (look up vector normal)
                    var currentNormal = hitBufferListItem.normal;
                    if (currentNormal.y > MinGroundNormalY)
                    {
                        _isGrounded = true;

                        if (yMovement)
                        {
                            GroundNormal = currentNormal;
                            currentNormal.x = 0;
                        }

                        float projection = Vector2.Dot(velocity, currentNormal);

                        if (projection < 0)
                        {
                            velocity = velocity - projection * currentNormal;
                        }
                    }

                    if(CollisionDetectedEvent!=null)
                    {
                        CollisionDetectedEvent(hitBufferListItem, rigidBody);
                    }


                    //Gets the colliding object closes to us and predicts how far we can move with a little padding of shell radius
                    float modifiedDistance = hitBufferListItem.distance - shellRadius;

                    distance = modifiedDistance < distance ? modifiedDistance : distance;
                }

                //returns the most we can move
                DistanceToMove = distance;
            }
 
    }
}
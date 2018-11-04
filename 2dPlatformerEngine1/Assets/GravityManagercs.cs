using System.Collections.Generic;
using UnityEngine;

namespace Physics
{
    public class GravityManager
    {
        float gravityModifier = 1f;
        protected const float minMoveDistance = 0.001f;
        protected ContactFilter2D contactFilter;
        RaycastHit2D[] raycastElementsHit=new RaycastHit2D[16];
        List<RaycastHit2D> rayCastActualElementsHit = new List<RaycastHit2D>();
        float shellRadius=0.01f;
        float minGroundNormalY = .65f;
        bool isGrounded = false;

        public Vector2 groundNormal;
        public Vector2 targetVelocity;

        public GravityManager(PhysicsObject physicsObjects)
        {
            contactFilter = new ContactFilter2D();
            contactFilter.useTriggers = false;
            contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(physicsObjects.GetGameObject().layer));
            contactFilter.useLayerMask = true;
        }

        public void ApplyGravityWithCollision(PhysicsObject physicsObjects, Rigidbody2D rigidbody2D)
        {
            physicsObjects.Velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
            Vector2 deltaPosition = physicsObjects.Velocity * Time.deltaTime;

            physicsObjects.Velocity.x = targetVelocity.x;
            Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
            var move = moveAlongGround * deltaPosition.x;
            Movement(move, physicsObjects, rigidbody2D, false);



            move = Vector2.up * deltaPosition.y;
            Movement(move, physicsObjects, rigidbody2D, true);
        }

        void Movement(Vector2 move, PhysicsObject physicsObjects, Rigidbody2D rigidbody2D, bool yMovement)
        {
            isGrounded = false;
            var distance = move.magnitude;

            if(distance>minMoveDistance)
            {
                int count=rigidbody2D.Cast(move, contactFilter, raycastElementsHit,distance+shellRadius);
                rayCastActualElementsHit.Clear();
                for(int i=0;i<count;i++)
                {
                    rayCastActualElementsHit.Add(raycastElementsHit[i]);
                }

                //if player is grounded
                for(int i = 0; i < rayCastActualElementsHit.Count; i++)
                {
                    var currentNormal = rayCastActualElementsHit[i].normal;
                    if(currentNormal.y>minGroundNormalY)
                    {
                        isGrounded = true;
                        if(yMovement)
                        {
                            groundNormal = currentNormal;
                            currentNormal.x = 0;
                        }
                    }

                    var projection = Vector2.Dot(physicsObjects.Velocity, currentNormal);
                    if(projection<0)
                    {
                        physicsObjects.Velocity = physicsObjects.Velocity - (projection * currentNormal);
                    }

                    float modifiedDistance = rayCastActualElementsHit[i].distance - shellRadius;
                    distance = modifiedDistance < distance ? modifiedDistance : distance;
                }
            }

            rigidbody2D.position += move.normalized * distance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class MovementManager
    {
        #region Properties
        const float minMoveDistance = 0.001f;
        const float minGroundNormalY = .65f;
        public Vector2 groundNormal;
        #endregion

        public void MoveWithCollision(Vector2 nextMovePosition, PhysicsObject physicsObjects, Rigidbody2D rigidbody2D, CollisionManager collisionManager, bool yMovement)
        {
            physicsObjects.ThePhysicsObjectStatus.isGrounded = false;
            var distance = nextMovePosition.magnitude;

            if (distance > minMoveDistance)
            {
                var rayCastActualElementsHit = collisionManager.GetRayCastCollisionElements(nextMovePosition, distance + CollisionManager.ShellRadius, rigidbody2D);

                //if player is grounded
                for (int i = 0; i < rayCastActualElementsHit.Length; i++)
                {
                    var currentRayCastElement = rayCastActualElementsHit[i];
                    var currentNormal = currentRayCastElement.normal;

                    if (currentNormal.y > minGroundNormalY)
                    {
                        physicsObjects.ThePhysicsObjectStatus.isGrounded = true;
                        if (yMovement)
                        {
                            groundNormal = currentNormal;
                            currentNormal.x = 0;
                        }
                    }

                    physicsObjects.Velocity = GetVelocityDependingOnCollision(physicsObjects, currentNormal);
                    distance = GetNextMovePositionDependingOnCollision(distance, currentRayCastElement);
                }
            }

            rigidbody2D.position += nextMovePosition.normalized * distance;
        }

        Vector2 GetVelocityDependingOnCollision(PhysicsObject physicsObjects, Vector2 adjustedRayCastElementCurrentNormal)
        {
            var projection = Vector2.Dot(physicsObjects.Velocity, adjustedRayCastElementCurrentNormal);
            if (projection < 0)
            {
                return physicsObjects.Velocity - (projection * adjustedRayCastElementCurrentNormal);
            }
            else
            {
                return physicsObjects.Velocity;
            }
        }

        float GetNextMovePositionDependingOnCollision(float nextMoveMagniture, RaycastHit2D rayCastElement)
        {
            float modifiedDistance = rayCastElement.distance - CollisionManager.ShellRadius;
            return modifiedDistance < nextMoveMagniture ? modifiedDistance : nextMoveMagniture;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Physics
{
    public class GravityManager
    {
        float gravityModifier = 1f;

        public void ApplyGravity(PhysicsObject physicsObjects, Rigidbody2D rigidbody2D)
        {
            physicsObjects.Velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
            Vector2 deltaPosition = physicsObjects.Velocity * Time.deltaTime;
            Vector2 move = Vector2.up * deltaPosition.y;
            Movement(move, rigidbody2D);
        }

        void Movement(Vector2 move, Rigidbody2D rigidbody2D)
        {
            rigidbody2D.position += move;
        }
    }
}

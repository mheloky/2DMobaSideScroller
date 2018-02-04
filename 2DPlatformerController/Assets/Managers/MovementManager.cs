using UnityEngine;
using UnityEditor;
using System;

public class MovementManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="physicsObjectBasic"></param>
    /// <param name="jumpButtonKeyName"></param>
    /// <returns>The Jump Vector's Y</returns>
    public Vector2 ExecuteJumpManagement(PhysicsObjectBasic physicsObjectBasic, string jumpButtonKeyName="Jump")
    {
        Input.GetAxis("Horizontal");
        var velocity = physicsObjectBasic.GetVelocity();

        if (Input.GetButtonDown(jumpButtonKeyName) && physicsObjectBasic.TheCollisionDetector.IsGrounded)
        {
            velocity.y= physicsObjectBasic.movementAttributes.JumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp(jumpButtonKeyName))
        {
            if (physicsObjectBasic.GetVelocity().y > 0)
            {
                velocity.y= physicsObjectBasic.GetVelocity().y * 0.5f;
            }
        }

        return velocity;
    }

    public Vector2 ExecuteHorizontalMovement()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        return move;
    }
}
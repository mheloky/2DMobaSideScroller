using UnityEngine;
using UnityEditor;
using System;
using Assets.Managers;

public class MovementManager:IMovementManager
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
        int i = 0;
        if (Input.GetKey(KeyCode.A))
        {
            i = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            i = 1;
        }
        else
        {
            i = 0;
        }
        move.x =i ;

        return move;
    }
}
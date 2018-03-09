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
    public Vector2 GetJumpManagementVector(PhysicsObjectBasic physicsObjectBasic, string jumpButtonKeyName="Jump")
    {

        var velocity = physicsObjectBasic.GetVelocity();

        if (physicsObjectBasic.TheCollisionDetector.IsGrounded)
        {
            velocity.y= physicsObjectBasic.movementAttributes.JumpTakeOffSpeed*Input.GetAxis("Vertical");
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

    public Vector2 GetHorizontalMovementVector()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        
        return move;
    }

    public void UpdateTargetVelocity(Vector2 move, ICharacter character)
    {
        character.GetPhysicsObject().TargetVelocity = 
        move * character.GetMovementAttributes().MaxSpeed;
    }
}
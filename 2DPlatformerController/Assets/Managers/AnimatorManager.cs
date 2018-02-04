using UnityEngine;
using UnityEditor;
using System;

public class AnimatorManager
{
    bool flipSprite;
    public void ExecuteFlipSprite(float moveX, SpriteRenderer spriteRenderer)
    {
        if (moveX != 0)
        {
            flipSprite = (moveX > 0.0f);
        }

        if (!flipSprite)
        {
            spriteRenderer.flipX = false;
        }
        else if (flipSprite)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void UpdateVelocityParametrer(Animator animator, PhysicsObjectBasic physicsObjectBasic)
    {
        animator.SetFloat("velocityX", Mathf.Abs(physicsObjectBasic.GetVelocity().x) / physicsObjectBasic.movementAttributes.MaxSpeed);
    }
}
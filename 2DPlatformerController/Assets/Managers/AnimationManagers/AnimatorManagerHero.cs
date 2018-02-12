using UnityEngine;
using UnityEditor;
using System;

public class AnimatorManagerHero: IAnimatorManager
{
    bool flipSprite;
    public void ExecuteFlipSprite(float moveX, ICharacter character)
    {
        bool flipSprite = false;
        if (moveX != 0)
        {
            flipSprite=(moveX > 0.0f);
        }

        character.GetSpriteRenderer().flipX= flipSprite;
    }

    public void UpdateVelocityParametrer(ICharacter character)
    {
        var animator = character.GetAnimator();
        animator.SetFloat("velocityX", Mathf.Abs(character.GetPhysicsObject().GetVelocity().x) /
                          character.GetPhysicsObject().movementAttributes.MaxSpeed);
    }

    public void ExecuteAttackAnimation(ICharacter character)
    {
        character.GetAnimator().SetBool("basicAttack", true);
    }
}
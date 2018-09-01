using UnityEngine;
using System;

public class AnimatorManagerCreep: IAnimatorManager
{
    public void ExecuteFlipSprite(float moveX, ICharacter character)
    {
        var spriteRenderer = character.GetSpriteRenderer();
        var teamAttributes = character.GetTeamAttributes();

        var flipSprite = (spriteRenderer.flipX ? (teamAttributes.Team == TAGS.Team2) : 
                          (teamAttributes.Team == TAGS.Team1));

        if (!flipSprite)
        {
            spriteRenderer.flipX= !spriteRenderer.flipX;
        }
    }

    public void UpdateVelocityParametrer(ICharacter character)
    {
        var animator = character.GetAnimator();
        animator.SetFloat("velocityX", Mathf.Abs(character.GetPhysicsObject().GetVelocity().x) / character.GetPhysicsObject().movementAttributes.MaxSpeed);
    }

    public void ExecuteAttackAnimation(ICharacter character)
    {
        character.GetAnimator().SetBool("basicAttack", true);
    }
}
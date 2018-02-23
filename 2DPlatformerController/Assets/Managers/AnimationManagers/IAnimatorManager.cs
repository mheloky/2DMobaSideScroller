using UnityEngine;
using UnityEditor;

public interface IAnimatorManager
{
    void ExecuteFlipSprite(float moveX, ICharacter character);
    void UpdateVelocityParametrer(ICharacter character);
    void ExecuteAttackAnimation(ICharacter character);
}
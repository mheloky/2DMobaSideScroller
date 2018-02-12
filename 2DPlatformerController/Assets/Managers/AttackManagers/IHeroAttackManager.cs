using UnityEngine;
using UnityEditor;
using Assets.Abilities;

public interface IHeroAttackManager
{
    IAttack GetBasicAttack_SwordHit();
    IAttack GetSpecialAttack_LightningStrike();
}
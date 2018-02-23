using UnityEngine;
using UnityEditor;
using Assets.Abilities;

public interface ICreepAttackManager
{
    IAttack GetBasicAttack_SwordHit();
    IAttack GetSpecialAttack_LightningStrike();
}
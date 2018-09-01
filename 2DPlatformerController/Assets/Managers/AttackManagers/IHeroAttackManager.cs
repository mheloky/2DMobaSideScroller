using UnityEngine;
using Assets.Abilities;

public interface IHeroAttackManager
{
    IAttack GetBasicAttack_SwordHit(int team);
    IAttack GetSpecialAttack_LightningStrike(int team);
}
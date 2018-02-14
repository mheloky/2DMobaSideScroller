using UnityEngine;
using UnityEditor;
using Assets.Abilities;

public class HeroAttackManager : IHeroAttackManager
{
    public IAttack GetBasicAttack_SwordHit(int team)
    {
        IAttack attack = new BasicAttack();
        attack.GetDamageAttributes().AttackDamage = 10;
        attack.GetDamageAttributes().Cleave = 2;
        attack.GetDamageAttributes().HowFatItIs = 2;
        attack.GetDamageAttributes().Radius = 2;
        attack.GetDamageAttributes().AttackDamage = 10;
        attack.GetDamageAttributes().AttackCooldownInSeconds = 10;
        return attack;
    }

    public IAttack GetSpecialAttack_LightningStrike(int team)
    {
        IAttack attack = new BasicAttack();
        attack.GetDamageAttributes().AttackDamage = 30;
        attack.GetDamageAttributes().Cleave = 2;
        attack.GetDamageAttributes().HowFatItIs = 2;
        attack.GetDamageAttributes().Radius = 2;
        attack.GetDamageAttributes().AttackDamage = 10;
        attack.GetDamageAttributes().AttackCooldownInSeconds = 10;
        return attack;
    }
}
using UnityEngine;
using Assets.Abilities;

public class CreepAttackManager : IHeroAttackManager
{
    public IAttack GetBasicAttack_SwordHit(int team)
    {
        IAttack attack = new BasicAttack();
        LayerMask masks;
        masks =1<<team ;
        attack.GetDamageAttributes().ToAttack = masks;
        attack.GetDamageAttributes().AttackDamage = 1;
        attack.GetDamageAttributes().Cleave = 2;
        attack.GetDamageAttributes().HowFatItIs = 1;
        attack.GetDamageAttributes().Radius = 2;
        attack.GetDamageAttributes().AttackDamage = 10;
        attack.GetDamageAttributes().AttackCooldownInSeconds = 10;
        return attack;
    }

    public IAttack GetSpecialAttack_LightningStrike(int team)
    {
        IAttack attack = new BasicAttack();
        LayerMask masks;
        masks = 1<<team;
        attack.GetDamageAttributes().ToAttack = masks;
        attack.GetDamageAttributes().AttackDamage = 30;
        attack.GetDamageAttributes().Cleave = 2;
        attack.GetDamageAttributes().HowFatItIs = 1;
        attack.GetDamageAttributes().Radius = 2;
        attack.GetDamageAttributes().AttackDamage = 10;
        attack.GetDamageAttributes().AttackCooldownInSeconds = 10;
        return attack;
    }
}
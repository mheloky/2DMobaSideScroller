using UnityEngine;
using UnityEditor;
using Assets.Abilities;

public class TowerAttackManager : ITowerAttackManager
{
    public IAttack basic(int team)
    {
        IAttack attack = new BasicAttack();
        LayerMask masks;
        masks = 1 << team;
        attack.GetDamageAttributes().ToAttack = masks;
        attack.GetDamageAttributes().AttackDamage = 5;
        attack.GetDamageAttributes().Cleave = 1;
        attack.GetDamageAttributes().HowFatItIs = 1;
        attack.GetDamageAttributes().Radius = 2;
        attack.GetDamageAttributes().AttackCooldownInSeconds = 1;
        return attack;
    }
}
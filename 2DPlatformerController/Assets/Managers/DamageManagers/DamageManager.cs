using UnityEngine;
using System;
using Assets.Attributes;
using System.Collections.Generic;
using Assets.Abilities;

public class DamageManager:IDamageManager
{
    public bool DistributeDamageWithInvincible(ICharacter character, IAttack attack,ICharacter Attacker)
    {
        var damagableAttributes = character.GetDamagerAttributes();
        var vitalityAttributes = character.GetVitalityAttributes();
        var timeElapsedSinceLastAttack=(DateTime.Now - damagableAttributes.LastAttackTime);
        var damageAttributes = attack.GetDamageAttributes();
      
        
        if (timeElapsedSinceLastAttack.TotalSeconds* 
            damageAttributes.AttackDamage >= damagableAttributes.AttackCooldownInSeconds 
            && !vitalityAttributes.IsInvincible)
        {
            damagableAttributes.LastAttackTime = DateTime.Now;
            vitalityAttributes.HP -= damageAttributes.AttackDamage;
            character.GetVitalityAttributes().audioSource.clip=attack.GetDamageAttributes().clip;
            character.GetVitalityAttributes().audioSource.Play();
            if (vitalityAttributes.HP <= 0)
                if (Attacker.GetVitalityAttributes().MP + character.GetVitalityAttributes().MpGivenOnDeath <= Attacker.GetVitalityAttributes().MaxMP)
                {
                    Attacker.GetVitalityAttributes().MP += character.GetVitalityAttributes().MpGivenOnDeath;
                    return true;
                }
                else
                {
                    Attacker.GetVitalityAttributes().MP = Attacker.GetVitalityAttributes().MaxMP;
                }
        }

        return false; 
    }
    public List<IDamagable> GetTargetsInRange(ICharacter character)
    {
        var gameObject = character.GetGameObject();
        var damagableAttributes = character.GetDamagerAttributes();
        var WhichSideIsRight=1;
        var WhichSide = (gameObject.GetComponent<SpriteRenderer>().flipX == false) ? 1 * WhichSideIsRight : -1 * WhichSideIsRight;
        var hits = Physics2D.RaycastAll(gameObject.transform.position + new Vector3(damagableAttributes.HowFatItIs * WhichSide, 0), gameObject.transform.forward, damagableAttributes.Radius, damagableAttributes.ToAttack);
        var targets = new List<IDamagable>();

        for (int i = 0; i < hits.Length && i < damagableAttributes.Cleave; i++)
        {
            var target = hits[i].collider.gameObject;
            targets.Add(target.GetComponent<IDamagable>());
            Debug.DrawLine(gameObject.transform.position, target.transform.position, Color.red);
        }

        return targets;
    }
}
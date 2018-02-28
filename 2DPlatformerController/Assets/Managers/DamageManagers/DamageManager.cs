
using UnityEngine;
using UnityEditor;
using System;
using Assets.Attributes;
using System.Collections.Generic;
using Assets.Abilities;

public class DamageManager:IDamageManager
{
	public bool DistributeDamageWithInvincible(ICharacter character, IAttack attack, AudioSource audio, GameObject particalSystem)
    {
        var damagableAttributes = character.GetDamagerAttributes();
        var vitalityAttributes = character.GetVitalityAttributes();
        var timeElapsedSinceLastAttack=(DateTime.Now - damagableAttributes.LastAttackTime);
        var damageAttributes = attack.GetDamageAttributes();
      
        
        if (timeElapsedSinceLastAttack.TotalSeconds* 
            damageAttributes.AttackDamage >= damagableAttributes.AttackCooldownInSeconds 
            && !vitalityAttributes.IsInvincible)
        {
			audio.Play ();
			particalSystem.GetComponent<ParticleSystem> ().Play ();
            damagableAttributes.LastAttackTime = DateTime.Now;
            vitalityAttributes.HP -= damageAttributes.AttackDamage;

            if (vitalityAttributes.HP <= 0)
				
                return true;
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
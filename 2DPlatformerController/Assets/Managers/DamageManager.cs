using UnityEngine;
using UnityEditor;
using System;
using Assets.Attributes;

public class DamageManager
{
    /// <summary>
    /// Distributes Damage and takes into account the invincible field 
    /// </summary>
    /// <param name="damagableAttributes"></param>
    /// <param name="hpDelta"></param>
    /// <returns>Returns if the object should be destoryed or no</returns>
    public bool DistributeDamageWithInvincible(VitalityAttributes vitalityAttributes, DamagableAttributes damagableAttributes, int Damage,float coulDown)
    {
        if ((DateTime.Now - damagableAttributes.LastAttackTime).TotalSeconds*coulDown >= damagableAttributes.AttackDelaySeconds &&
        !vitalityAttributes.IsInvincible)
        {
            damagableAttributes.LastAttackTime = DateTime.Now;
            vitalityAttributes.HP -= Damage;
            if (vitalityAttributes.HP <= 0)
                return true;
        }

        return false; 
    }
}
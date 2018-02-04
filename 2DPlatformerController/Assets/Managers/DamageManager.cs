using UnityEngine;
using UnityEditor;
using System;

public class DamageManager
{
    /// <summary>
    /// Distributes Damage and takes into account the invincible field 
    /// </summary>
    /// <param name="damagableAttributes"></param>
    /// <param name="hpDelta"></param>
    /// <returns>Returns if the object should be destoryed or no</returns>
    public bool DistributeDamageWithInvincible(DamagableAttributes damagableAttributes, int hpDelta)
    {
        if((DateTime.Now - damagableAttributes.LastAttackTime).TotalSeconds>=damagableAttributes.AttackDelaySeconds)
        if (!damagableAttributes.IsInvincible)
        {
            damagableAttributes.LastAttackTime = DateTime.Now;
            damagableAttributes.HP -= hpDelta;
            if (damagableAttributes.HP <= 0)
                return true;
        }

        return false; 
    }
}
﻿using UnityEngine;
using System;
using Assets.Attributes;
using System.Collections.Generic;
using Assets.Abilities;

public interface IDamageManager
{
    /// <summary>
    /// Distributes Damage and takes into account the invincible field 
    /// </summary>
    /// <param name="damagableAttributes"></param>
    /// <param name="hpDelta"></param>
    /// <returns>Returns if the object should be destoryed or no</returns>
    bool DistributeDamageWithInvincible(ICharacter character, IAttack attack,ICharacter Attacker);
    List<IDamagable> GetTargetsInRange(ICharacter character);
}
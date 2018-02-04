using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class DamagableAttributes
{
    public string Team;
    public int HP;
    public bool IsInvincible;
    public int AttackDamage;
    public int AttackDelaySeconds;
    public DateTime LastAttackTime;
}
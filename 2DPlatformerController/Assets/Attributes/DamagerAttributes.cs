using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

[Serializable]
public class DamagerAttributes
{
    public float AttackDamage;
    public float AttackCooldownInSeconds;
    public DateTime LastAttackTime;
    public float Radius;
    public int Cleave;
    public float HowFatItIs;
    public LayerMask ToAttack;
    public AudioClip clip;
}

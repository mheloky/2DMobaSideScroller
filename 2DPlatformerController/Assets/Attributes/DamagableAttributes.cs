using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UI;
[Serializable]
public class DamagableAttributes
{
    public int AttackDamage;
    public float AttackDelaySeconds;
    public DateTime LastAttackTime;
    public decimal Radius;
    public int Cleave;
    public RaycastHit[] Range(float range,GameObject gameObject)
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(gameObject.transform.position, gameObject.transform.forward, range);
        return hits;
    }
}

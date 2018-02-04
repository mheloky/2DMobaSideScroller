using UnityEngine;
using UnityEditor;
using Assets.Attributes;

public interface IDamagable 
{
    void TakeDamage(int damage);
    DamagableAttributes GetDamagableAttributes();
    VitalityAttributes GetVitalityAttributes();
}
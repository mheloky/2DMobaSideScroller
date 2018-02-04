using UnityEngine;
using UnityEditor;

public interface IDamagable 
{
    void TakeDamage(int damage);
    DamagableAttributes GetDamagableAttributes();
}
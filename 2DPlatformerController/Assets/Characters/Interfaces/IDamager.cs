using UnityEngine;
using Assets.Attributes;
using UnityEngine.UI;
public interface IDamager 
{
    void TakeDamage(int damage);
    DamagerAttributes GetDamagerAttributes();
    
}
using UnityEngine;
using UnityEditor;
using Assets.Attributes;
using UnityEngine.UI;
public interface IDamagable 
{
    void TakeDamage(int damage);
    DamagableAttributes GetDamagableAttributes();
    VitalityAttributes GetVitalityAttributes();

    GameObject GetGameObject();
    Slider GetHealthSlider();
}
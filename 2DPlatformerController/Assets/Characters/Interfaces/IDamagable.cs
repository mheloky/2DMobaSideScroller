using UnityEngine;
using Assets.Attributes;
using UnityEngine.UI;

public interface IDamagable
{
    VitalityAttributes GetVitalityAttributes();
    Slider GetHealthSlider();
    GameObject gameObject();
}
using UnityEngine;
using UnityEditor;
using Assets.Attributes;
using UnityEngine.UI;

public interface IDamagable
{
    VitalityAttributes GetVitalityAttributes();
    Slider GetHealthSlider();
}
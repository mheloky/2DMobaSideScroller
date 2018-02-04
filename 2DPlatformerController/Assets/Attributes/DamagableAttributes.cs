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
    public Slider SliderToLoad;
    public float height;
    [HideInInspector]
    public Slider HealthSlider;
    [HideInInspector]
    public Canvas canvas;
        //1 target only 
    //phone died - let it charge for a second
    //so, i was thinking 
}

using UnityEngine;
using UnityEditor;
using System;
using Assets.Attributes;

public class AttributeManager
{
    public void ChangeHP(VitalityAttributes gameObjectAttributes, int hpDelta)
    {
            gameObjectAttributes.HP += hpDelta;
    }
}
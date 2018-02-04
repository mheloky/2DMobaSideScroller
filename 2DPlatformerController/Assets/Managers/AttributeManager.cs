using UnityEngine;
using UnityEditor;
using System;


public class AttributeManager
{
    public void ChangeHP(DamagableAttributes gameObjectAttributes, int hpDelta)
    {
            gameObjectAttributes.HP += hpDelta;
    }
}
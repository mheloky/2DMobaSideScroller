using UnityEngine;
using UnityEditor;
using System;
using Assets.Attributes;

public class VitalityManager : IVitalityManager
{
    public void ChangeHP(VitalityAttributes gameObjectAttributes, int hpDelta)
    {
        gameObjectAttributes.HP += hpDelta;
    }

    public void DestroyIfHPIsZero(ICharacter character, bool ignoreHPCheck = false)
    {
        if (character.GetVitalityAttributes().HP <= 0|| ignoreHPCheck)
        {
            UnityEngine.Object.Destroy(character.GetGameObject());
        }
    }

    
}
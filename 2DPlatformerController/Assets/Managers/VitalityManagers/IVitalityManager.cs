using UnityEngine;
using UnityEditor;
using Assets.Attributes;

public interface IVitalityManager
{
    void ChangeHP(VitalityAttributes gameObjectAttributes, int hpDelta);
    void DestroyIfHPIsZero(ICharacter character, bool ignoreHPCheck=false);
}
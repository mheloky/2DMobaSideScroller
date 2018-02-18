using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Attributes;

public interface ISkillManager
{
    void UpgradeSkillAttributesValue(ref float attributeToChange, float valueToAdd);
}


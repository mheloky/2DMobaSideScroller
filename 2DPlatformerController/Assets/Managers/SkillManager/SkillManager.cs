using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Attributes;
public class SkillManager : ISkillManager {

	public void UpgradeSkillAttributesValue(ref float attributeToChange, float valueToAdd)
    {
        attributeToChange += valueToAdd;
    }
}


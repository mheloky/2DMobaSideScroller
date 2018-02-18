using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Attributes;
public class SkillManager : ISkillManager {

    public void UpdateStrengthAttributeValue(SkillAttributes skillAttributes, float skillValue)
    {
        skillAttributes.Strength = skillValue;
    }
    public void UpdateAgilityAttributeValue(SkillAttributes skillAttributes, float skillValue)
    {
        skillAttributes.Agility = skillValue;
    }
    public void UpdateVitalityAttributeValue(SkillAttributes skillAttributes, float skillValue)
    {
        skillAttributes.Vitality = skillValue;
    }
}


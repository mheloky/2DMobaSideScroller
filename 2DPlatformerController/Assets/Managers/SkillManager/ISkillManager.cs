using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Attributes;

public interface ISkillManager
{
    void UpdateStrengthAttributeValue(SkillAttributes skillAttributes, float skillValue);
    void UpdateAgilityAttributeValue(SkillAttributes skillAttributes, float skillValue);
    void UpdateVitalityAttributeValue(SkillAttributes skillAttributes, float skillValue);
}


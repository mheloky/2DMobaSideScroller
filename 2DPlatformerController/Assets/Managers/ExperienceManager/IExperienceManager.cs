using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Attributes;

public interface IExperienceManager
{
    void AddExperience(ExperienceAttribute gameObjectAttributes, int exp);
    bool LevelUp(ExperienceAttribute vitalityAttributes);
}

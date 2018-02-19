using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Attributes;

public interface IExperienceManager
{
    void AddExperience(ExperienceAttribute experienceAttribute, int exp);
    bool LevelUp(ExperienceAttribute experienceAttribute);
    bool CanUpgrade(ExperienceAttribute experienceAttribute);
}

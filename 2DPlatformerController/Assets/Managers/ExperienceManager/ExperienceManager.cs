using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Attributes;

public class ExperienceManager : IExperienceManager
{
    public const int expToAddPerLvl = 100;
    public void AddExperience(ExperienceAttribute experienceAttribute, int exp)
    {
        experienceAttribute.experience = exp;
        
        if(LevelUp(experienceAttribute))
        {
            experienceAttribute.experience = (experienceAttribute.expToLevelUp - experienceAttribute.experience) * (-1);
            experienceAttribute.expToLevelUp += expToAddPerLvl;
            
        }
    }

    public bool LevelUp(ExperienceAttribute experienceAttribute)
    {
        if(experienceAttribute.experience >= experienceAttribute.expToLevelUp)
        {
            experienceAttribute.level++;
            experienceAttribute.canUpgrade = true;
            //experienceAttribute.playerHUD.SetActive(true);
            return true;
        }
        //experienceAttribute.canUpgrade = false;
        return false;
    }

    public bool CanUpgrade(ExperienceAttribute experienceAttribute)
    {
        return experienceAttribute.canUpgrade;
    }

}

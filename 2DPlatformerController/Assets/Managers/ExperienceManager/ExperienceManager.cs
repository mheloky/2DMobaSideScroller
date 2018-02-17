using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Attributes;

public class ExperienceManager : IExperienceManager
{

	public void AddExperience(ExperienceAttribute gameObjectAttributes, int exp)
    {
        gameObjectAttributes.experience += exp;
        
        if(LevelUp(gameObjectAttributes))
        {
            gameObjectAttributes.expToLevelUp += 100;
            gameObjectAttributes.experience = 0;
        }
    }

    public bool LevelUp(ExperienceAttribute gameObjectAttributes)
    {
        if(gameObjectAttributes.experience >= gameObjectAttributes.expToLevelUp)
        {
            gameObjectAttributes.level++;
            return true;
        }
        return false;
    }

}

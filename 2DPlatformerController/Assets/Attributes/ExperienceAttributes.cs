using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Attributes
{
    [System.Serializable]
    

    public class ExperienceAttribute
    {
        public int experience;
        public int expToLevelUp;
        public int level;
        public bool canUpgrade;
        public int upgradePoints;
        //public GameObject playerHUD;
        public ExperienceAttribute()
        {
            experience = 10;
            level = 0;
            expToLevelUp = 100;
            upgradePoints = 0;
        }


    }
}
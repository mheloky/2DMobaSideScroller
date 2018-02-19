using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Attributes;
using Assets.Managers;

public class PlayerHUD : MonoBehaviour {
    ICharacter hero = new Hero();
    ISkillManager skillManager = new SkillManager();
    IExperienceManager experienceManager = new ExperienceManager();
    public static GameObject playerHUD;
    public Text Strength;
    public Text Agility;
    public Text Vitality;
    
    private void Awake()
    {
        playerHUD = gameObject;
        UpdateUI();

    }

    private void Update()
    {
        print(hero + " " + hero.GetExperienceAttributes().experience);
        //playerHUD.SetActive(experienceManager.CanUpgrade(hero.GetExperienceAttributes()));
    }
    #region PlayerUI

    void UpdateUI()
    {
        var skillAttributes = hero.GetSkillAttributes();
        print(skillAttributes.Strength);
        Strength.text = skillAttributes.Strength.ToString();
        Agility.text = skillAttributes.Agility.ToString();
        Vitality.text = skillAttributes.Vitality.ToString();
        //playerHUD.SetActive(false);

    }
    public void OnUpgradeStrengthClicked()
    {
        var skillAttributes = hero.GetSkillAttributes();
        skillManager.UpdateStrengthAttributeValue(skillAttributes, skillAttributes.Strength + 10);
        UpdateUI();
    }

    public void OnUpgradeAgilityClicked()
    {
        var skillAttributes = hero.GetSkillAttributes();
        skillManager.UpdateAgilityAttributeValue(skillAttributes, skillAttributes.Agility  + 10);
        UpdateUI();
    }

    public void OnUpgradeVitalityClicked()
    {
        var skillAttributes = hero.GetSkillAttributes();
        skillManager.UpdateVitalityAttributeValue(skillAttributes, skillAttributes.Vitality + 10);
        UpdateUI();
    }

    public void OnAddExpClicked()
    {
        var experienceAttributes = hero.GetExperienceAttributes();
        experienceManager.AddExperience(experienceAttributes, experienceAttributes.experience + 100);
    }
    //public UpdateUI
    #endregion PlayerUI 
}

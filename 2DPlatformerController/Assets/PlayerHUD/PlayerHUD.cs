using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {
    ICharacter hero = new Hero();
    ISkillManager skillManager = new SkillManager();
    //UpgradeButton upgrade;
    public Text Strength;
    public Text Agility;
    public Text Vitality;
    
    private void Awake()
    {
        UpdateUI();
    }
    #region PlayerUI
    void UpdateUI()
    {
        var skillAttributes = hero.GetSkillAttributes();
        Strength.text = skillAttributes.Strength.ToString();
        Agility.text = skillAttributes.Agility.ToString();
        Vitality.text = skillAttributes.Vitality.ToString();

    }
    public void OnUpgradeStrengthClicked()
    {
        var skillAttributes = hero.GetSkillAttributes();
        skillManager.UpdateStrengthAttributeValue(skillAttributes, skillAttributes.Strength+10);
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

    //public UpdateUI
    #endregion PlayerUI 
}

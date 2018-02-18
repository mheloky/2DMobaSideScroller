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
    SkillAttributes skillAttributes;
    private void Awake()
    {
        skillAttributes = hero.GetSkillAttributes();
        UpdateUI();
    }
    #region PlayerUI
    void UpdateUI()
    {
        Strength.text = skillAttributes.Strength.ToString();
        Agility.text = skillAttributes.Agility.ToString();
        Vitality.text = skillAttributes.Vitality.ToString();

    }
    public void OnUpgradeStrengthClicked()
    {
        skillManager.UpdateStrengthAttributeValue(skillAttributes, skillAttributes.Strength+10);
        UpdateUI();
    }

    public void OnUpgradeAgilityClicked()
    {
        skillManager.UpdateAgilityAttributeValue(skillAttributes, skillAttributes.Agility  + 10);
        UpdateUI();
    }

    public void OnUpgradeVitalityClicked()
    {
        skillManager.UpdateVitalityAttributeValue(skillAttributes, skillAttributes.Vitality + 10);
        UpdateUI();
    }

    //public UpdateUI
    #endregion PlayerUI 


}

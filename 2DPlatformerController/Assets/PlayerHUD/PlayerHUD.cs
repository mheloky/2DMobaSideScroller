using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Attributes;
using Assets.Managers;

public class PlayerHUD : MonoBehaviour {
    #region Properties
    Hero hero;
    ISkillManager skillManager = new SkillManager();
    IExperienceManager experienceManager = new ExperienceManager();

    PlayerInventorySlot[] slots;
    public Transform itemsParent;
    public static GameObject playerHUD;
    public Text Strength;
    public Text Agility;
    public Text Vitality;
    private Button[] buttons;
    #endregion
    private void Awake()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        playerHUD = gameObject;
        slots = itemsParent.GetComponentsInChildren<PlayerInventorySlot>();
        UpdateUI();
        buttons = new Button[3];
        buttons[0] = Strength.GetComponentInParent<Button>();
        buttons[1] = Agility.GetComponentInParent<Button>();
        buttons[2] = Vitality.GetComponentInParent<Button>();
        SetInteractionButtons();
    }

    private void Update()
    {
        SetInteractionButtons();
    }
    #region PlayerUI

    public void SetInteractionButtons()
    {
        if (hero.experienceAttribute.canUpgrade)
        {
            foreach (Button btn in buttons)
            {
                btn.interactable = true;
            }
        }
        else
        {
            foreach (Button btn in buttons)
            {
                btn.interactable = false;
            }
        }
    }

    public void UpdateUI()
    {
        var skillAttributes = hero.GetSkillAttributes();
        Strength.text = skillAttributes.Strength.ToString();
        Agility.text = skillAttributes.Agility.ToString();
        Vitality.text = skillAttributes.Vitality.ToString();
        UpdateInventorySlots();

    }

    void UpdateInventorySlots()
    {
        List<Item> inventoryItems = hero.inventoryAttributes.items;
        int i = 0;
        foreach(Item item in inventoryItems)
        {
            if(item)
            {
                slots[i].AddItem(item);
            }
            else
            {
                slots[i].ClearSlot();
            }
            i++;
        }
        
    }

    private void ShowPlayerHUD()
    {
        var experienceAttributes = hero.GetExperienceAttributes();
        --experienceAttributes.upgradePoints;
        if (experienceAttributes.upgradePoints <= 0)
        {
            experienceAttributes.canUpgrade = false;
        }
        else
        {
            experienceAttributes.canUpgrade = true;
        }
    }

    public void OnUpgradeStrengthClicked()
    {
        var skillAttributes = hero.GetSkillAttributes();
        skillManager.UpdateStrengthAttributeValue(skillAttributes, skillAttributes.Strength + 10);
        UpdateUI();
        ShowPlayerHUD();
    }

    public void OnUpgradeAgilityClicked()
    {
        var skillAttributes = hero.GetSkillAttributes();
        skillManager.UpdateAgilityAttributeValue(skillAttributes, skillAttributes.Agility  + 10);
        UpdateUI();
        ShowPlayerHUD();
    }

    public void OnUpgradeVitalityClicked()
    {
        var skillAttributes = hero.GetSkillAttributes();
        skillManager.UpdateVitalityAttributeValue(skillAttributes, skillAttributes.Vitality + 10);
        UpdateUI();
        ShowPlayerHUD();
    }

    public void OnAddExpClicked()
    {
        var experienceAttributes = hero.GetExperienceAttributes();
        experienceManager.AddExperience(experienceAttributes, experienceAttributes.experience + 100);
        if (experienceAttributes.canUpgrade)
            PlayerHUD.playerHUD.SetActive(true);
    }
    //public UpdateUI
    #endregion PlayerUI 
}

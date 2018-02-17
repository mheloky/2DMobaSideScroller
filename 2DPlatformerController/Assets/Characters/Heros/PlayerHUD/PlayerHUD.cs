using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {
    Hero hero;
    //UpgradeButton upgrade;
    public Text damageText;
    public Text attackSpeedText;
    public Text armorText;
    public Text movementSpeedText;
    public Text criticalStrikeText;
    private void Start()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        UpdateUI();
    }
    #region PlayerUI
    void UpdateUI()
    {
        damageText.text = hero.basicAttack.GetDamageAttributes().AttackDamage.ToString();
        attackSpeedText.text = hero.basicAttack.GetDamageAttributes().AttackCooldownInSeconds.ToString();
        armorText.text = 0.ToString();
        movementSpeedText.text = hero.GetMovementAttributes().MaxSpeed.ToString();
        criticalStrikeText.text = 0.ToString();
    }
    public void OnUpgradeAttackDamageClicked()
    {
        UpgradeAttributesValue(ref hero.basicAttack.GetDamageAttributes().AttackDamage, 10);
        UpdateUI();
    }

    public void OnUpgradeAttackSpeedClicked()
    {
        UpgradeAttributesValue(ref hero.basicAttack.GetDamageAttributes().AttackCooldownInSeconds, 10);
        UpdateUI();
    }

    public void OnUpgradeMovementSpeedClicked()
    {
        UpgradeMovementAttributesValue(ref hero.movementAttributes.MaxSpeed, 2);
        UpdateUI();
    }
    //public UpdateUI
    #endregion PlayerUI 

    void UpgradeAttributesValue(ref float valueToChange, int valueToAdd)
    {
        valueToChange += valueToAdd;       
    }

    void UpgradeMovementAttributesValue(ref int valueToChange, int valueToAdd)
    {
        valueToChange += valueToAdd;
    }
}

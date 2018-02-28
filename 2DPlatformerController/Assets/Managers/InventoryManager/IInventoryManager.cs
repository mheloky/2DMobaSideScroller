using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Attributes;

public interface IInventoryManager
{
    void AddItemToInventory(Hero inventory, Item item);
    void BuyItem(Hero inventory, Item item);
    void AddVitalityProperties(VitalityAttributes vitality, Item item);
    void AddStrengthProperties(DamagerAttributes strength, Item item);
}

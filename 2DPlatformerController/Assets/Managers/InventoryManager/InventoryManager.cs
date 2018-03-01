using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Attributes;

public class InventoryManager : IInventoryManager {

    public void AddItemToInventory(Hero hero, Item item)
    {
        InventoryAttributes inventory = hero.GetInventoryAttributes();
        VitalityAttributes vitality = hero.GetVitalityAttributes();
        DamagerAttributes strength = hero.GetDamagerAttributes();
        //agilityitems  = 0
        //Strengthitem  = 1
        //Vitalityitems = 2
        //potions       = 3

        if (inventory.size < inventory.maxSize)
        {
            for(int i = 0; i < inventory.items.Count;i++)
            {
                if(!inventory.items[i])
                {
                    inventory.items[i] = item;
                    switch (item.itemID)
                    {
                        case 0:
                            //TODO..
                            break;
                        case 1:
                            AddStrengthProperties(strength, item);
                            break;
                        case 2:
                            AddVitalityProperties(vitality, item);
                            break;
                        case 3:
                            //TODO...
                            break;
                    }
                    inventory.size++;
                    return;
                }
            }
        }
        
    }

    public void BuyItem(Hero hero, Item item)
    {
        InventoryAttributes inventory = hero.GetInventoryAttributes();
        if (inventory.goldAmount >= item.cost)
        {
            AddItemToInventory(hero, item);            
            inventory.goldAmount -= item.cost;
        }
    }

    public void AddVitalityProperties(VitalityAttributes vitality, Item item)
    {
        VitalityItem vitalityItem = (VitalityItem)item;
        vitality.MaxHP += vitalityItem.hp;
        vitality.armor += vitalityItem.armor;
    }

    public void AddStrengthProperties(DamagerAttributes strength, Item item)
    {
        StrengthItem strengthItem = (StrengthItem)item;
        strength.AttackDamage += strengthItem.damage;

    }
}

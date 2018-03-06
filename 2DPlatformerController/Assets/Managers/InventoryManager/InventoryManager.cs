using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Attributes;

public class InventoryManager : IInventoryManager {

    public void AddItemToInventory(InventoryAttributes inventory, Item item)
    {
        
        if(inventory.size <= inventory.maxSize)
        {
            for(int i = 0; i < inventory.items.Count;i++)
            {
                if(!inventory.items[i])
                {
                    inventory.items[i] = item;
                    return;
                }
            }
        }
    }

    public void BuyItem(InventoryAttributes inventory, Item item)
    {
        if (inventory.goldAmount >= item.cost)
        {
            AddItemToInventory(inventory, item);
            inventory.goldAmount -= item.cost;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Attributes;

public interface IInventoryManager
{
    void AddItemToInventory(InventoryAttributes inventory, Item item);
    void BuyItem(InventoryAttributes inventory, Item item);
}

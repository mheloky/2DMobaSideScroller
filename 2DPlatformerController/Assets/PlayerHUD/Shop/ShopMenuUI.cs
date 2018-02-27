using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopMenuUI : MonoBehaviour
{
    public Text goldAmount;
    public Transform itemsParent;
    Hero hero;
    PlayerInventorySlot[] slots;
    public static GameObject shopMenuUI;
    private void Start()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        shopMenuUI = gameObject;
        slots = itemsParent.GetComponentsInChildren<PlayerInventorySlot>();
        UpdateUI();
    }

    private void Update()
    {
        goldAmount.text = hero.inventoryAttributes.goldAmount.ToString();
    }

    void UpdateUI()
    {
        UpdateInventorySlots();
    }

    void UpdateInventorySlots()
    {
        List<Item> inventoryItems = hero.inventoryAttributes.items;
        int i = 0;
        foreach (Item item in inventoryItems)
        {
            if (item)
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

    public void BuyItem(Item item)
    {
        hero.inventoryManager.BuyItem(hero.inventoryAttributes, item);
        UpdateUI();
    }
}

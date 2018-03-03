using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClicked : MonoBehaviour, IPointerClickHandler
{
    public ItemDescriptionSlot itemDescriptionSlot;
    public ShopMenuUI shopMenuUI;
    ShopMenuSlot shopMenuSlot;
   


    private void Awake()
    {
        shopMenuSlot = GetComponentInParent<ShopMenuSlot>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            BuyItem();
        }
        else if(eventData.button == PointerEventData.InputButton.Left)
        {
            //shopMenuSlot.item;
            itemDescriptionSlot.item = (Item)shopMenuSlot.item;
            itemDescriptionSlot.SetImage();
            //print(itemDescriptionSlot.item);
            //print(shopMenuSlot.item);
        }
    }

    public void BuyItem()
    {
        if(shopMenuUI.GetHero().IsOnSpawn())
            shopMenuUI.BuyItem(shopMenuSlot.item);
        //hero.inventoryManager.AddItemToInventory(hero.inventoryAttributes, shopMenuSlot.item);
    }

    public void UsePotion()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionSlot : ShopMenuSlot {

    //inherited
    //public Item item;
    //Image icon;
    //Text text;
    Image itemIcon;
    Text description;
    private void Start()
    {
        itemIcon = GetComponent<Image>();
        description = GameObject.Find("DescriptionPanel").GetComponentInChildren<Text>();
    }


    public void SetImage()
    {
        itemIcon.sprite = item.icon;
        description.text = item.itemDescription;
    }
}

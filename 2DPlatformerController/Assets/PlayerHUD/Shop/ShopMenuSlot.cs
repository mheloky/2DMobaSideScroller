using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuSlot : Slot {

    //inherited
    //public Item item;
    //protected Image icon;

    Text text;
    

	// Use this for initialization
	void Start () {
        base.Start();
        icon = this.GetComponentInChildren<Image>();
        icon.sprite = item.icon;
        text = this.GetComponentInChildren<Text>();
        text.text = item.cost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClicked()
    {
        print("Click!!");
    }

    public void AddItem(Item newItem)
    {
        if (newItem)
        {
            item = newItem;
            icon.sprite = newItem.icon;
            icon.enabled = true;
        }
        else
        {
            item = null;
            icon.enabled = false;
        }
    }
}

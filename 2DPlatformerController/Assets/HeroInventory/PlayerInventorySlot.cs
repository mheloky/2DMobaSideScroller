using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventorySlot : Slot {

    //inherited
    //public Item item;
    //protected Image icon;

    // Use this for initialization
    void Awake() {
        //icon = gameObject.GetComponentInChildren<Image>();
        icon.enabled = false;
        
    }
	
	// Update is called once per frame
	void Update () {
		
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

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        print("Clearing: " + gameObject);
    }
}

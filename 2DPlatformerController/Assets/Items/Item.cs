using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Item")]

public class Item : ScriptableObject {
    public string itemName = "Item";
    public string itemDescription;
    public Sprite icon;
    public int cost;
    public int itemID;
}

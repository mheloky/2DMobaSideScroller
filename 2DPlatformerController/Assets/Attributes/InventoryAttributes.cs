using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Attributes
{
    [System.Serializable]
    public class InventoryAttributes
    {
        public List<Item> items = new List<Item>();
        public int goldAmount;
        public readonly int maxSize = 5;
        public int size = 0;

       

    }
}

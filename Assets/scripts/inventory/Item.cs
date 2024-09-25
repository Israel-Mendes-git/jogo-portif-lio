using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

   public enum ItemType
    {
        Weapon,
        Chips,
        Water,
        Refri,
        
    }

    public ItemType itemType;
    public int amount;
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory
{
    private List<Item> itemList;

    public Inventory() // Construtor
    {
        itemList = new List<Item>();

        // Adicione itens ao inventário
        AddItem(new Item { itemType = Item.ItemType.Weapon, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Chips, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Water, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Refri, amount = 1 });

        Debug.Log(itemList.Count);
    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}

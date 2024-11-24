using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    public ItemSO[] itemSOs;

    // Update is called once per frame
    void Update()
    {
        // Verifica se a tecla pressionada e se o menu estiver ativado
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            // Menu fica falso
            InventoryMenu.SetActive(false);
            menuActivated = false;
            Time.timeScale = 1;
        }
        // Verifica a tecla pressionada e se o menu estiver desativado
        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            // Menu fica verdadeiro
            InventoryMenu.SetActive(true);
            menuActivated = true;
            Time.timeScale = 0;
        }
    }

    public void UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                itemSOs[i].UseItem();
                break; // Saia do loop após usar o item
            }
        }
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].name == name || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if (leftOverItems > 0)
                {
                    // Tente adicionar o que sobrou em outro slot
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                }
                return leftOverItems;
            }
        }
        return quantity; // Retorna a quantidade restante se não couber em nenhum slot
    }

    // Método para desselecionar todos os slots do inventário
    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    public ItemSO[] itemSOs;
    

    private void Awake()
    {
        InventoryMenu.SetActive(false);
    }

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
        //para cada item us�vel no invent�rio
        for (int i = 0; i < itemSOs.Length; i++)
        {
            //se o nome for igual
            if (itemSOs[i].itemName == itemName)
            {
                //chama a fun��o usar o item
                itemSOs[i].UseItem();
                break; 
            }
        }
    }

    //fun��o para adicionar o item no invent�rio
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            //se o slot n�o estiver lotado adiciona o item no slot
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
        return quantity; // Retorna a quantidade restante se n�o couber em nenhum slot

    }

    // M�todo para desselecionar todos os slots do invent�rio
    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}

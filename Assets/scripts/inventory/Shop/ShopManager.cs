using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[6,6];
    public float coins;
    public Text CoinsTxt;
    public InventoryManager inv;
    public Item item;
    public GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        shop.SetActive(false);
        CoinsTxt.text = "Dinheiro: R$ " + coins.ToString() + ",00";

        //ID
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;

        //Preço
        shopItems[2, 1] = 1;
        shopItems[2,2] = 1;
        shopItems[2,3] = 1;
        shopItems[2,4] = 1;
        shopItems[2,5] = 1;

        //Quantidade
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
        shopItems[3,5] = 0;


        inv = GameObject.Find("Canvas").GetComponent<InventoryManager>();
        item = GameObject.Find("PaçocaShop").GetComponent<Item>();
    }

    // Update is called once per frame
        public void Buy()
        {
            GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

            if( coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
            {
                coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
                shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
                CoinsTxt.text = "Dinheiro: R$ " + coins.ToString() + ",00";
                ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
                inv.AddItem(item.itemName, item.quantity, item.sprite, item.itemDescription);

            }
        }


    public void Return()
    {
        shop.SetActive(false);
    }


}

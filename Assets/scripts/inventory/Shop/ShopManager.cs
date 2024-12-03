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

    void Start()
    {
        //shop da soraya come�a desativado 
        shop.SetActive(false);
        //atualiza a quantidade de dinheiro do jogador 
        CoinsTxt.text = "Dinheiro: R$ " + coins.ToString() + ",00";

        //ID dos items
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;

        //Pre�o dos items
        shopItems[2, 1] = 1;
        shopItems[2,2] = 1;
        shopItems[2,3] = 1;
        shopItems[2,4] = 1;
        shopItems[2,5] = 1;

        //Quantidade dos items
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
        shopItems[3,5] = 0;


        //busca os componentes do invent�rio e dos items
        inv = GameObject.Find("Canvas").GetComponent<InventoryManager>();
        item = GameObject.Find("Pa�ocaShop").GetComponent<Item>();
    }

    // fun��o para compra do item na loja
        public void Buy()
        {
            //busca o componente do event system para o bot�o funcionar
            GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

            //verifica se a quantidade de dinheiro do jogador � maior que o pre�o do item na loja
            if( coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
            {
                //caso seja, subtrai e atualiza a quantidade de dinheiro do jogador, atualiza a quantidade do pr�prio item e coloca o item no invent�rio
                coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
                shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
                CoinsTxt.text = "Dinheiro: R$ " + coins.ToString() + ",00";
                ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
                inv.AddItem(item.itemName, item.quantity, item.sprite, item.itemDescription);

            }
        }

    //fun��o de retorno para o bot�o de voltar funcionar
    public void Return()
    {
        shop.SetActive(false);
    }


}

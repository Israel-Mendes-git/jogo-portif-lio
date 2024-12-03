using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text PirceTxt;
    public Text QuantityTxt;
    public GameObject ShopManager;

    // Update is called once per frame
    void Update()
    {
        //define o preço do item 
        PirceTxt.text = "Preço: R$" + ShopManager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();
        //atualiza e define a quantidade do item no inventário 
        QuantityTxt.text = ShopManager.GetComponent<ShopManager>().shopItems[3, ItemID].ToString();

        
    }
}

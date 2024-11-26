using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //=====VARIÁVEIS DOS ITENS=====//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    public Item slotsItem; // Referência ao item armazenado no slot
    public int amountInStack;

    [SerializeField]
    private int maxNumberOfItems;
    //=====ITEM SLOT=====//
    //faz com que a variável seja visível e editável na unity
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    //===ITEM DESCRIPTION SLOT===//
    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;



    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    private void Awake()
    {
        EmptySlot();
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();

    }
    
    
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        //checa se o slot já está cheio
        if (isFull)
            return quantity;
        //armazena os valores dos itens//
        //atualiza o nome
        this.itemName = itemName;
        
        //atualiza o sprite
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        //atualiza a descrição
        this.itemDescription = itemDescription;

        //atualiza a quantidade 
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;

            //retorna o leftOver
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        //atualiza a quantidade de texto 
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;



    }

    //carregar qual o botão foi usado
    public void OnPointerClick (PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    //selecionar ou deselecionar o slot com o botão esquerdo
    public void OnLeftClick ()
    {
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
        if(itemDescriptionImage.sprite == null)
        {
            itemDescriptionImage.sprite = emptySprite;
        }
    }

    private void EmptySlot()
    {
        itemName = null;
        itemSprite = null;
        itemDescription = null;
        quantity = 0;
        isFull = false;

        quantityText.enabled = false;
        itemImage.sprite = emptySprite;

        ItemDescriptionNameText.text = "";
        ItemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptySprite;
    }


    public void OnRightClick()
    {
        if (quantity <= 0)
        {
            Debug.LogWarning("Não há itens para descartar.");
            return;
        }

        GameObject itemToDrop = new GameObject(itemName);
        Item newItem = itemToDrop.AddComponent<Item>();
        newItem.quantity = 1; // Ajuste para dropar apenas 1 unidade
        newItem.itemName = itemName;
        newItem.sprite = itemSprite;
        newItem.itemDescription = itemDescription;

        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
        sr.sprite = itemSprite;
        sr.sortingOrder = 5;
        sr.sortingLayerName = "Ground";

        itemToDrop.AddComponent<BoxCollider2D>();
        itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(1, 0, 0);
        itemToDrop.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Atualiza o slot
        this.quantity -= 1;
        quantityText.text = this.quantity > 0 ? this.quantity.ToString() : "";

        if (this.quantity <= 0)
            EmptySlot();
    }


}

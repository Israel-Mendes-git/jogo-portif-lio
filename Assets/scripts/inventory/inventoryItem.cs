using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inventoryItem : MonoBehaviour, IPointerClickHandler
{
    Image itemIcon; 

    public CanvasGroup canvasGroup {get; private set;}

    public item myItem { get; set; }

    public inventorySlot activeSlot { get; set;}

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        itemIcon = GetComponent<Image>();
    }

    public void Initialize(item item, inventorySlot parent)
    {
        activeSlot = parent;
        activeSlot.myItem = this;
        myItem = item;
        itemIcon.sprite = item.sprite;

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            inventory.Singleton.SetCarriedItem(this);
        }
        else if(eventData.button == PointerEventData.InputButton.Right)
        {
            inventory.Singleton.DropItem(this);
        }
    }
}

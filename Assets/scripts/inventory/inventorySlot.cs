using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inventorySlot : MonoBehaviour, IPointerClickHandler
{
    public inventoryItem myItem { get; set; }

    public SlotTag myTag;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if(inventory.carriedItem == null)
            {
                return;
            }

            if(myTag != SlotTag.None && inventory.carriedItem.myItem.itemTag != myTag)
            {
                return;
            }
            SetItem(inventory.carriedItem);
        }
    }

    public void SetItem(inventoryItem item)
    {
        inventory.carriedItem = null;

        item.activeSlot.myItem = null;

        myItem = item;
        myItem.activeSlot = this;
        myItem.transform.SetParent(transform);
        myItem.canvasGroup.blocksRaycasts = true;

        if (myTag != SlotTag.None) 
        { 
            inventory.Singleton.EquipEquipment(myTag,myItem);
        }
    }
}

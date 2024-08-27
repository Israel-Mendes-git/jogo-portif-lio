using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public static inventory Singleton;
    public static inventoryItem carriedItem;

    [SerializeField] inventorySlot[] inventorySlots;
    [SerializeField] inventorySlot[] equipmentSlots;

    [SerializeField] Transform draggablesTransform;
    [SerializeField] inventoryItem itemPrefab;

    [SerializeField] item[] items;

    [SerializeField] Button giveItemBtn;

    public player player;
    private item helmetTempItem;
    private item chestTempItem;
    private item legsTempItem;
    private item feetTempItem;


    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<player>();
        Singleton = this;   
        giveItemBtn.onClick.AddListener(delegate { SpawnInventoryItem(); });
       
    }

    private void Update()
    {
        if (carriedItem == null)
        {
            return;
        }
        carriedItem.transform.position = Input.mousePosition;
    }

    public void SetCarriedItem(inventoryItem item)
    {
        if (carriedItem != null)
        {
            if (item.activeSlot.myTag != SlotTag.None && item.activeSlot.myTag != carriedItem.myItem.itemTag)
            {
                return;
            }
            item.activeSlot.SetItem(carriedItem);
        }
        if (item.activeSlot.myTag != SlotTag.None)
        {
            EquipEquipment(item.activeSlot.myTag, null);
        }
        carriedItem = item;
        carriedItem.canvasGroup.blocksRaycasts = false;
        carriedItem.transform.SetParent(draggablesTransform);
    }

    public void EquipEquipment(SlotTag tag, inventoryItem item = null)
    {
        switch (tag)
        {
            case SlotTag.Head:
                if (item == null)
                {
                    player.entity.strength -= helmetTempItem.str;
                    player.entity.resistence -= helmetTempItem.res;
                    helmetTempItem = null;
                    Debug.Log("Removeu um item da tag Head");
                }
                else
                {
                    helmetTempItem = item.myItem;
                    player.entity.strength += helmetTempItem.str;
                    player.entity.resistence += helmetTempItem.res;
                    Debug.Log("Equipou um item na tag Head");
                }
                break;
            case SlotTag.Chest:
                if (item == null)
                {
                    chestTempItem = null;
                    Debug.Log("Removeu um item da tag chest");
                }
                else
                {
                    chestTempItem = item.myItem;
                    Debug.Log("Equipou um item na tag chest");
                }
                break;
            case SlotTag.Legs:
                if (item == null)
                {
                    legsTempItem = null;
                    Debug.Log("Removeu um item da tag legs");
                }
                else
                {
                    legsTempItem = item.myItem;
                    Debug.Log("Equipou um item na tag legs");
                }
                break;
            case SlotTag.Feet:
                if (item == null)
                {
                    feetTempItem = null;
                    Debug.Log("Removeu um item da tag feet");
                }
                else
                {
                    feetTempItem = item.myItem;
                    Debug.Log("Equipou um item na tag feet");
                }
                break;
        }
    }

    public void SpawnInventoryItem(item item = null)
    {
        item _item = item;
        if (_item == null)
        {
            _item = PickRandomItem();
        }
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].myItem == null)
            {
                Instantiate(itemPrefab, inventorySlots[i].transform).Initialize(_item, inventorySlots[i]);
                break;
            }
        }
    }

    item PickRandomItem()
    {
        int random = Random.Range(0, items.Length);
        return items[random];

    }

    item PickItem(item pickItem)
    {
        item selectedItem = null;

        foreach (var item in items)
        {
            if (item.name == pickItem.name)
            {
                selectedItem = item;
                break;
            }

        }
        return selectedItem;
    }
    
    public void PickupItem(item item)
    {
        item _item = item;
        if (_item == null)
        {
            _item = PickItem(item);
        }
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].myItem == null)
            {
                Instantiate(itemPrefab, inventorySlots[i].transform).Initialize(_item, inventorySlots[i]);
                break;
            }
        }
    }

    public void DropItem(inventoryItem item)
    {
        Debug.Log("Drop item");
        SpawnObjectNearPlayer(item);
        Destroy(item.gameObject);
    }

    public void SpawnObjectNearPlayer(inventoryItem item)
    {
        Transform player = GameObject.Find("Player").transform;

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(0.1f, 0.5f);
        Vector2 spawnPosition = (Vector2)player.position + randomDirection * randomDistance;

        GameObject dropItemPrefab = Instantiate(item.myItem.prefab, spawnPosition, Quaternion.identity);
        dropItemPrefab.GetComponent<SpriteRenderer>().sprite = item.myItem.sprite;
        dropItemPrefab.GetComponent<PickupItem>().item = item.myItem;
    }

}

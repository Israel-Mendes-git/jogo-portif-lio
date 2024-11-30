using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public string itemName;
    [SerializeField] public int quantity;
    [SerializeField] public Sprite sprite;
    [TextArea][SerializeField] public string itemDescription;

    public int itemId;
    public int amountInStack;
    public InventoryManager inventoryManager;
    public GameObject interactBtn;

    private bool isPlayerInRange = false;

    void Start()
    {
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();

        if (UIManager.Instance != null)
        {
            // Garantir que o botão exista e esteja associado
            GameObject prefab = Resources.Load<GameObject>("Prefabs/InteractButtonUI");
            UIManager.Instance.InitializeInteractBtn(prefab, GameObject.Find("Canvas").transform);

            interactBtn = UIManager.Instance.interactBtn;
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            CollectItem();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && interactBtn != null)
        {
            isPlayerInRange = true;
            interactBtn.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && interactBtn != null)
        {
            isPlayerInRange = false;
            interactBtn.SetActive(false);
        }
    }

    private void CollectItem()
    {
        int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
        if (leftOverItems <= 0)
        {
            if (interactBtn != null)
            {
                interactBtn.SetActive(false);
            }
            Destroy(gameObject);
        }
        else
        {
            quantity = leftOverItems;
        }
    }
}

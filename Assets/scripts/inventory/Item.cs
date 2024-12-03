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
        //procura o game object com o nome Canvas e pega o componente InventoryManager
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();

        if (UIManager.Instance != null)
        {
            // Garantir que o bot�o exista e esteja associado
            GameObject prefab = Resources.Load<GameObject>("Prefabs/InteractButtonUI");
            UIManager.Instance.InitializeInteractBtn(prefab, GameObject.Find("Canvas").transform);

            interactBtn = UIManager.Instance.interactBtn;
        }
    }

    private void Update()
    {
        //se o player estiver no alcance e a tecla E seja pressionada 
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            //chama a fun��o de coletar itens
            CollectItem();
        }
    }

    //caso o player entre na �rea de colis�o 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //e a tag for realmente Player e o bot�o de intera��o n�o seja nulo
        if (collision.gameObject.CompareTag("Player") && interactBtn != null)
        {
            //player est� no raio
            isPlayerInRange = true;
            //bot�o de intera��o � ativado
            interactBtn.SetActive(true);
        }
    }

    //caso saia da �rea de colis�o 
    private void OnCollisionExit2D(Collision2D collision)
    {
        //a tag for realmente Player e o bot�o de intera��o n�o for nulo 
        if (collision.gameObject.CompareTag("Player") && interactBtn != null)
        {
            //sai o raio de alcance 
            isPlayerInRange = false;
            //bot�o de intera��o se desativa
            interactBtn.SetActive(false);
        }
    }

    //fun��o para coletar os itens
    private void CollectItem()
    {
        //chama a fun��o para coletar itens no inventory manager
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

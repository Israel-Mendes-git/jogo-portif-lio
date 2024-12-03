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
            // Garantir que o botão exista e esteja associado
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
            //chama a função de coletar itens
            CollectItem();
        }
    }

    //caso o player entre na área de colisão 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //e a tag for realmente Player e o botão de interação não seja nulo
        if (collision.gameObject.CompareTag("Player") && interactBtn != null)
        {
            //player está no raio
            isPlayerInRange = true;
            //botão de interação é ativado
            interactBtn.SetActive(true);
        }
    }

    //caso saia da área de colisão 
    private void OnCollisionExit2D(Collision2D collision)
    {
        //a tag for realmente Player e o botão de interação não for nulo 
        if (collision.gameObject.CompareTag("Player") && interactBtn != null)
        {
            //sai o raio de alcance 
            isPlayerInRange = false;
            //botão de interação se desativa
            interactBtn.SetActive(false);
        }
    }

    //função para coletar os itens
    private void CollectItem()
    {
        //chama a função para coletar itens no inventory manager
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

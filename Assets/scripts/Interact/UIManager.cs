using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject interactBtnPrefab; // Prefab do bot�o
    public GameObject interactBtn; // Inst�ncia do bot�o

    private void Awake()
    {
        //se a inst�ncia n�o existir 
        if (Instance == null)
        {
            //ela se torna essa e n�o destroi quando for carregada
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //se existir, s� destroi 
            Destroy(gameObject);
            return;
        }

        // Verificar se o prefab est� atribu�do
        if (interactBtnPrefab == null)
        {
            Debug.LogError("Prefab do bot�o de intera��o n�o est� atribu�do! Certifique-se de atribu�-lo no Inspector.");
        }
    }


    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        //inicializando o bot�o
        if (interactBtnPrefab != null)
        {
            InitializeInteractBtn(interactBtnPrefab, transform);
        }
    }


    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Remove inscri��o
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Garante que o bot�o de intera��o seja inicializado novamente ap�s carregar a cena
        InitializeInteractBtn(interactBtnPrefab, transform);
    }

    public void InitializeInteractBtn(GameObject prefab, Transform parent)
    {
        if (prefab == null)
        {
            //verifica se o prefab � nulo
            Debug.LogError("Prefab do bot�o de intera��o n�o est� atribu�do!");
            return;
        }

        if (interactBtn == null)
        {
            //bot�o de intera��o se torna uma inst�ncia
            interactBtn = Instantiate(prefab, parent, false);
            interactBtn.SetActive(false); // Inicia desativado
        }
    }

    public void ShowInteractButton(Transform npcTransform)
    {
        if (interactBtn == null)
        {
            //verifica se o bot�o de intera��o foi inicializado
            Debug.LogWarning("Bot�o de intera��o n�o inicializado.");
            return;
        }
        
        //ativa o bot�o de intera��o
        interactBtn.SetActive(true);
        // Ajusta a posi��o da c�mera
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(npcTransform.position + Vector3.up * 2); 
        interactBtn.transform.position = screenPosition;
    }
    
    //fun��o para esconder o bot�o de intera��o
    public void HideInteractButton()
    {
        if (interactBtn != null)
        {
            interactBtn.SetActive(false);
        }
    }
}

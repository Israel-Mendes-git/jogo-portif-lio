using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject interactBtnPrefab; // Prefab do botão
    public GameObject interactBtn; // Instância do botão

    private void Awake()
    {
        //se a instância não existir 
        if (Instance == null)
        {
            //ela se torna essa e não destroi quando for carregada
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //se existir, só destroi 
            Destroy(gameObject);
            return;
        }

        // Verificar se o prefab está atribuído
        if (interactBtnPrefab == null)
        {
            Debug.LogError("Prefab do botão de interação não está atribuído! Certifique-se de atribuí-lo no Inspector.");
        }
    }


    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        //inicializando o botão
        if (interactBtnPrefab != null)
        {
            InitializeInteractBtn(interactBtnPrefab, transform);
        }
    }


    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Remove inscrição
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Garante que o botão de interação seja inicializado novamente após carregar a cena
        InitializeInteractBtn(interactBtnPrefab, transform);
    }

    public void InitializeInteractBtn(GameObject prefab, Transform parent)
    {
        if (prefab == null)
        {
            //verifica se o prefab é nulo
            Debug.LogError("Prefab do botão de interação não está atribuído!");
            return;
        }

        if (interactBtn == null)
        {
            //botão de interação se torna uma instância
            interactBtn = Instantiate(prefab, parent, false);
            interactBtn.SetActive(false); // Inicia desativado
        }
    }

    public void ShowInteractButton(Transform npcTransform)
    {
        if (interactBtn == null)
        {
            //verifica se o botão de interação foi inicializado
            Debug.LogWarning("Botão de interação não inicializado.");
            return;
        }
        
        //ativa o botão de interação
        interactBtn.SetActive(true);
        // Ajusta a posição da câmera
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(npcTransform.position + Vector3.up * 2); 
        interactBtn.transform.position = screenPosition;
    }
    
    //função para esconder o botão de interação
    public void HideInteractButton()
    {
        if (interactBtn != null)
        {
            interactBtn.SetActive(false);
        }
    }
}

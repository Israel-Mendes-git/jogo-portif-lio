using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject interactBtnPrefab; // Prefab do botão
    public GameObject interactBtn; // Instância do botão

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
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

        // Inicializar botão no Start para evitar erros
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
            Debug.LogError("Prefab do botão de interação não está atribuído!");
            return;
        }

        if (interactBtn == null)
        {
            interactBtn = Instantiate(prefab, parent, false);
            interactBtn.SetActive(false); // Inicia desativado
        }
    }

    public void ShowInteractButton(Transform npcTransform)
    {
        if (interactBtn == null)
        {
            Debug.LogWarning("Botão de interação não inicializado.");
            return;
        }

        interactBtn.SetActive(true);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(npcTransform.position + Vector3.up * 2); // Ajuste a posição para cima da cabeça
        interactBtn.transform.position = screenPosition;
    }

    public void HideInteractButton()
    {
        if (interactBtn != null)
        {
            interactBtn.SetActive(false);
        }
    }
}

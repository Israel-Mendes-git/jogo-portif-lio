using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject interactBtn;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste o UIManager entre cenas
        }
        else
        {
            Destroy(gameObject); // Evita m�ltiplas inst�ncias do UIManager
        }
    }

    private void Start()
    {
        // Inscreva-se para o evento de carregamento de cena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Desinscreva-se para evitar erros quando o objeto for destru�do
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // M�todo chamado quando a cena for carregada
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Inicialize o bot�o de intera��o novamente
        InitializeInteractBtn(interactBtn, transform);
    }

    public void InitializeInteractBtn(GameObject prefab, Transform parent)
    {
        if (interactBtn == null && prefab != null)
        {
            interactBtn = Instantiate(prefab, parent, false);
            interactBtn.SetActive(false); // O bot�o fica desativado inicialmente
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject interactBtnPrefab; // Prefab do bot�o
    public GameObject interactBtn; // Inst�ncia do bot�o

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

        // Verificar se o prefab est� atribu�do
        if (interactBtnPrefab == null)
        {
            Debug.LogError("Prefab do bot�o de intera��o n�o est� atribu�do! Certifique-se de atribu�-lo no Inspector.");
        }
    }


    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Inicializar bot�o no Start para evitar erros
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
            Debug.LogError("Prefab do bot�o de intera��o n�o est� atribu�do!");
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
            Debug.LogWarning("Bot�o de intera��o n�o inicializado.");
            return;
        }

        interactBtn.SetActive(true);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(npcTransform.position + Vector3.up * 2); // Ajuste a posi��o para cima da cabe�a
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

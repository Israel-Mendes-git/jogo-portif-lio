using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Destroy(gameObject); // Evita múltiplas instâncias do UIManager
        }
    }

    public void InitializeInteractBtn(GameObject prefab, Transform parent)
    {
        if (interactBtn == null && prefab != null)
        {
            interactBtn = Instantiate(prefab, parent, false);
            interactBtn.SetActive(false);
        }
    }

}


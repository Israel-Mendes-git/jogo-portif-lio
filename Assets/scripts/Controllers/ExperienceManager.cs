using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance { get; private set; }

    private void Awake()
    {
        // Checa se já existe uma instância
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantém a instância entre cenas
        }
        else
        {
            Destroy(gameObject); // Garante que apenas uma instância exista
        }
    }

    public delegate void ExperienceChangeHandler(int amount);
    public event ExperienceChangeHandler OnExperienceChange;

    public void AddExperience(int amount)
    {
        OnExperienceChange?.Invoke(amount);
    }
}




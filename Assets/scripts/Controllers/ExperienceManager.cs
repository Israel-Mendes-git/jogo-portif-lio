using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance { get; private set; }

    private void Awake()
    {
        // Checa se j� existe uma inst�ncia
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mant�m a inst�ncia entre cenas
        }
        else
        {
            Destroy(gameObject); // Garante que apenas uma inst�ncia exista
        }
    }

    public delegate void ExperienceChangeHandler(int amount);
    public event ExperienceChangeHandler OnExperienceChange;

    public void AddExperience(int amount)
    {
        OnExperienceChange?.Invoke(amount);
    }
}




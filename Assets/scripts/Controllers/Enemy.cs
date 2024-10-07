using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public GameObject BackgroundFight;

    public ExperienceManager ExperienceManager;
    int expAmount = 50;

    public int Health { 
        set 
        { 
            health = value; 

            
        } 
        get
        {
            return health;
        }
    }
    public int health = 3;

    public void OnHit()
    {
        BackgroundFight.SetActive(true);
    }
    void Die()
    {
        Destroy(gameObject);

        if (ExperienceManager.Instance != null)
        {
            ExperienceManager.Instance.AddExperience(expAmount);
        }
        else
        {
            Debug.LogWarning("ExperienceManager.Instance não está atribuído.");
        }
    }


}

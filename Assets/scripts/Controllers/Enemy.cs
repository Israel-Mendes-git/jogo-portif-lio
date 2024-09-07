using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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

    public void OnHit(int damage)
    {
        Debug.Log("deu dano");
        Health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
            Destroy(gameObject);
            ExperienceManager.Instance.AddExperience(expAmount);        
    }

}

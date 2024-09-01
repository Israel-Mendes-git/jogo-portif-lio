using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health { 
        set 
        { 
            health = value; 

            if (health <= 0)
            {
                Destroy(gameObject);
            }
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
    }


}

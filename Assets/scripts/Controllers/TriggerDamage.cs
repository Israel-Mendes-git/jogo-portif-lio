using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDamage : MonoBehaviour
{
    public string cena; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            SceneManager.LoadScene(cena);
            Debug.Log("Loading scene: " + cena);
        }
    }
}

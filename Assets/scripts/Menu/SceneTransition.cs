using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string cena;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(cena);
        Debug.Log("Loading scene: " + cena);
    }

}

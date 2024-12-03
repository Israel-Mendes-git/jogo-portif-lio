using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string cena;
    
    //caso entre na área de colisão 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //carregue a cena que foi setada
        SceneManager.LoadScene(cena);
        Debug.Log("Loading scene: " + cena);
    }

}

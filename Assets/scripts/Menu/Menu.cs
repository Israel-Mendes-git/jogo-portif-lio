using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void LoadScene(string cena)
    {
        //carrega a cena 
        SceneManager.LoadScene(cena);        
    }

    public void QuitGame()
    {
        //sai da aplicação 
        Application.Quit();
    }


}

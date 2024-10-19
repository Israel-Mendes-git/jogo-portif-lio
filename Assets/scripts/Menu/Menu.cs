using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void LoadScene(string cena)
    {
        SceneManager.LoadScene(cena);
        Debug.Log("pressionou");
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}

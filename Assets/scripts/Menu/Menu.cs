using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //carrega uma cena espec�fica
    public void LoadScene(string cena)
    {
        //carrega a cena 
        SceneManager.LoadScene(cena);        
    }

    //fun��o para sair do jogo
    public void QuitGame()
    {
        //sai da aplica��o 
        Application.Quit();
    }


}

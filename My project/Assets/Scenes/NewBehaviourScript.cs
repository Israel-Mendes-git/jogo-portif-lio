using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void LoadScenes(string cena)
    {
        Debug.Log("Carregando a cena: " + cena);
        SceneManager.LoadScene(cena);
    }
}
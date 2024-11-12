using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDamage : MonoBehaviour
{
//===VARIÁVEIS DE TRIGGER DAMAGE===//
    //cria uma variável de uma cena
    public string cena; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //se o game object com a tag Player entrar na área de colisão
        if (collision.gameObject.CompareTag("Player")) 
        {
            //carrega a cena que foi armazenada 
            SceneManager.LoadScene(cena);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection_controller : MonoBehaviour
{
    //cria e armazena uma tag alvo como sendo Player
    public string TagTarget = "Player";

    //cria uma lista de colisores chamada de detectedObjs
    public List<Collider2D> detectedObjs = new List<Collider2D>();

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //se o game object com a mesma tag que a tag alvo entrar na área de colisão 
        if(collision.gameObject.tag == TagTarget)
        {
            //adiciona o collision a lista de objetos detectado 
            detectedObjs.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //se o game object com a mesma tag que a tag alvo sair da área de colisão 
        if (collision.gameObject.tag == TagTarget)
        {
            //remove o collision da lista 
            detectedObjs.Remove(collision);

        }
    }
}

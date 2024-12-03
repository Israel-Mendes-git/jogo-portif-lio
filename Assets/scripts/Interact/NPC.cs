using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //caso entre na área de colisão
    private void OnTriggerEnter(Collider other)
    {
        //se a tag for igual a Player
        if (other.CompareTag("Player"))
        {
            // Exibe o botão de interação na cabeça do NPC
            UIManager.Instance.ShowInteractButton(this.transform);
        }
    }

    //caso saia da área de colisão 
    private void OnTriggerExit(Collider other)
    {
        //se a tag for igual a Player
        if (other.CompareTag("Player"))
        {
            // Esconde o botão de interação quando o jogador se afasta
            UIManager.Instance.HideInteractButton();
        }
    }
}


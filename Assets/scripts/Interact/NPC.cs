using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //caso entre na �rea de colis�o
    private void OnTriggerEnter(Collider other)
    {
        //se a tag for igual a Player
        if (other.CompareTag("Player"))
        {
            // Exibe o bot�o de intera��o na cabe�a do NPC
            UIManager.Instance.ShowInteractButton(this.transform);
        }
    }

    //caso saia da �rea de colis�o 
    private void OnTriggerExit(Collider other)
    {
        //se a tag for igual a Player
        if (other.CompareTag("Player"))
        {
            // Esconde o bot�o de intera��o quando o jogador se afasta
            UIManager.Instance.HideInteractButton();
        }
    }
}


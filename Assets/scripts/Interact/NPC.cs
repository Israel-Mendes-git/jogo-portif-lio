using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Exibe o botão de interação na cabeça do NPC
            UIManager.Instance.ShowInteractButton(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Esconde o botão de interação quando o jogador se afasta
            UIManager.Instance.HideInteractButton();
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    private GameObject interactBtn;
    public GameObject shop;


    private void Awake()
    {
        //se a intancia do UImanager não for nula
        if (UIManager.Instance != null)
        {
            //busca o prefab do botão de interação
            GameObject prefab = Resources.Load<GameObject>("Prefabs/InteractButtonUI");
            //inicializa o botão de interãção
            UIManager.Instance.InitializeInteractBtn(prefab, GameObject.Find("Canvas").transform);
        }
    }

    private void Update()
    {
        //caso o jogador esteja na área de alcance e pressione a tecla E
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            //o shop da soraya ativa
            shop.SetActive(true);
        }
    }

    //caso entre na área de alcance
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //e a tag for igual a Player
        if (collision.CompareTag("Player"))
        {
            //está na área de colisão 
            isPlayerInTrigger = true;

            //se o botão de interação não for nulo
            if (interactBtn != null)
            {
                //ativa o botão de interação
                interactBtn.SetActive(true);
            }
        }
    }

    //caso saia da área de alcance
    private void OnTriggerExit2D(Collider2D collision)
    {
        //e a tag for igual a Player
        if (collision.CompareTag("Player"))
        {
            //não está na área
            isPlayerInTrigger = false;
            if (interactBtn != null)
            {
                //botão de interação é falso
                interactBtn.SetActive(false);
            }

        }
    }
}

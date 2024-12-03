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
        //se a intancia do UImanager n�o for nula
        if (UIManager.Instance != null)
        {
            //busca o prefab do bot�o de intera��o
            GameObject prefab = Resources.Load<GameObject>("Prefabs/InteractButtonUI");
            //inicializa o bot�o de inter���o
            UIManager.Instance.InitializeInteractBtn(prefab, GameObject.Find("Canvas").transform);
        }
    }

    private void Update()
    {
        //caso o jogador esteja na �rea de alcance e pressione a tecla E
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            //o shop da soraya ativa
            shop.SetActive(true);
        }
    }

    //caso entre na �rea de alcance
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //e a tag for igual a Player
        if (collision.CompareTag("Player"))
        {
            //est� na �rea de colis�o 
            isPlayerInTrigger = true;

            //se o bot�o de intera��o n�o for nulo
            if (interactBtn != null)
            {
                //ativa o bot�o de intera��o
                interactBtn.SetActive(true);
            }
        }
    }

    //caso saia da �rea de alcance
    private void OnTriggerExit2D(Collider2D collision)
    {
        //e a tag for igual a Player
        if (collision.CompareTag("Player"))
        {
            //n�o est� na �rea
            isPlayerInTrigger = false;
            if (interactBtn != null)
            {
                //bot�o de intera��o � falso
                interactBtn.SetActive(false);
            }

        }
    }
}

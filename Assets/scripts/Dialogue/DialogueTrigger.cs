using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//serializa uma nova classe para o nome e a imagem de quem tá falando
[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

//serializa uma nova classe para as linhas de diálogo do personagem que está falando
[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

//serializa uma nova classe para criar uma lista das linhas de diálogo
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool isPlayerInTrigger = false;
    private GameObject interactBtn;

    private void Awake()
    {
        //se a intância do UI manager não for nula 
        if (UIManager.Instance != null)
        {
            //busca o prefab 
            GameObject prefab = Resources.Load<GameObject>("Prefabs/InteractButtonUI");
            UIManager.Instance.InitializeInteractBtn(prefab, GameObject.Find("Canvas").transform);
        }
    }

    //função para começar o diálogo caso a instância não seja nula
    public void TriggerDialogue()
    {
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.StartDialogue(dialogue);
        }
    }

    private void Update()
    {
        // se estiver na área de colisão e pressione a tecla E
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            //chama a função de iniciar o diálogo
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;

            if (interactBtn != null)
            {
                interactBtn.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            if (interactBtn != null)
            {
                interactBtn.SetActive(false);
            }

            DialogueManager.Instance?.EndDialogue();
        }
    }
}


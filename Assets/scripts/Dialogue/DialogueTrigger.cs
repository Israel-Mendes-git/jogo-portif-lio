using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//serializa uma nova classe para o nome e a imagem de quem t� falando
[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

//serializa uma nova classe para as linhas de di�logo do personagem que est� falando
[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

//serializa uma nova classe para criar uma lista das linhas de di�logo
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
        //se a int�ncia do UI manager n�o for nula 
        if (UIManager.Instance != null)
        {
            //busca o prefab 
            GameObject prefab = Resources.Load<GameObject>("Prefabs/InteractButtonUI");
            UIManager.Instance.InitializeInteractBtn(prefab, GameObject.Find("Canvas").transform);
        }
    }

    //fun��o para come�ar o di�logo caso a inst�ncia n�o seja nula
    public void TriggerDialogue()
    {
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.StartDialogue(dialogue);
        }
    }

    private void Update()
    {
        // se estiver na �rea de colis�o e pressione a tecla E
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            //chama a fun��o de iniciar o di�logo
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


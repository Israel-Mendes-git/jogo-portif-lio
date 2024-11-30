using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

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
    private DialogueManager dialogueManager;

    public void Awake()
    {
        if (UIManager.Instance != null)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/InteractButtonUI");
            UIManager.Instance.InitializeInteractBtn(prefab, GameObject.Find("Canvas").transform);

            interactBtn = UIManager.Instance.interactBtn;
            dialogueManager = GetComponent<DialogueManager>();
        }
    }

    public void TriggerDialogue()
    {
        if (DialogueManager.Instance == null)
        {
            Debug.LogError("N�o foi poss�vel iniciar o di�logo. DialogueManager n�o est� dispon�vel.");
            return;
        }

        DialogueManager.Instance.StartDialogue(dialogue);
    }


    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Colidiu");
            if (Input.GetKey(KeyCode.E))
            {
                TriggerDialogue();
            }
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
            DialogueManager.Instance?.EndDialogue();

            if (interactBtn != null)
            {
                interactBtn.SetActive(false);
            }
        }
    }
}

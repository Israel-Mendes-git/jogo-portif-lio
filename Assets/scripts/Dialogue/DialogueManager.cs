    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;
    public GameObject dialogueBox;

    public float typingSpeed = 0.2f;

    // Start is called before the first frame update
    private void Start()
    {
        lines = new Queue<DialogueLine>();
        dialogueBox.SetActive(false);
    }

    void Awake()
    {
        // Garante que apenas uma instância do DialogueManager exista
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Para que o DialogueManager persista entre as cenas
        }
        else
        {
            Destroy(gameObject); // Impede múltiplas instâncias
        }

        // Inicializa o DialogueBox
        if (dialogueBox == null)
        {
            dialogueBox = GameObject.Find("DialogueBox");
        }

        // Verifique se o DialogueBox foi encontrado
        if (dialogueBox == null)
        {
            Debug.LogError("DialogueBox não encontrado na cena. Verifique se o GameObject está presente.");
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        dialogueBox.SetActive(true);
        lines.Clear();
        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }
        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines(); // Parar qualquer Coroutine anterior

        // Inicia a digitação da linha do diálogo
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed); // Atraso entre as letras
        }
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
        dialogueArea.text = "";
        dialogueBox.SetActive(false);
    }
}

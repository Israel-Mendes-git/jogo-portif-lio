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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("DialogueManager inicializado corretamente.");
        }
        else
        {
            Destroy(gameObject);
            Debug.LogWarning("J� existe uma inst�ncia do DialogueManager.");
        }

        if (dialogueBox == null)
        {
            dialogueBox = GameObject.Find("DialogueBox");
        }

        if (dialogueBox == null)
        {
            Debug.LogError("DialogueBox n�o encontrado na cena.");
        }
    }


    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Exibindo o di�logo...");

        isDialogueActive = true;
        dialogueBox.SetActive(true);
        lines.Clear();

        if (dialogue.dialogueLines.Count == 0)
        {
            Debug.LogError("N�o h� linhas de di�logo.");
            return;
        }

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();

        // Ativar o bot�o de intera��o quando o di�logo come�ar
        UIManager.Instance.interactBtn.SetActive(true);
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

    StopAllCoroutines(); // Para qualquer Coroutine anterior
    StartCoroutine(TypeSentence(currentLine));

    // Habilitar bot�o apenas quando o texto estiver completamente exibido
    Button nextBtn = GameObject.Find("NextBtn").GetComponent<Button>();
    nextBtn.interactable = true;
}




    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        Debug.Log("Iniciando digita��o da linha.");

        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed); // Atraso entre as letras
        }

        Debug.Log("Linha digitada.");
    }


    public void EndDialogue()
    {
        Debug.Log("Fim do di�logo.");

        isDialogueActive = false;
        dialogueArea.text = "";
        dialogueBox.SetActive(false);
    }

}

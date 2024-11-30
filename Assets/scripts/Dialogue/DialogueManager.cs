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
            Debug.LogWarning("Já existe uma instância do DialogueManager.");
        }

        if (dialogueBox == null)
        {
            dialogueBox = GameObject.Find("DialogueBox");
        }

        if (dialogueBox == null)
        {
            Debug.LogError("DialogueBox não encontrado na cena.");
        }
    }


    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Exibindo o diálogo...");

        isDialogueActive = true;
        dialogueBox.SetActive(true);
        lines.Clear();

        if (dialogue.dialogueLines.Count == 0)
        {
            Debug.LogError("Não há linhas de diálogo.");
            return;
        }

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();

        // Ativar o botão de interação quando o diálogo começar
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

    // Habilitar botão apenas quando o texto estiver completamente exibido
    Button nextBtn = GameObject.Find("NextBtn").GetComponent<Button>();
    nextBtn.interactable = true;
}




    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        Debug.Log("Iniciando digitação da linha.");

        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed); // Atraso entre as letras
        }

        Debug.Log("Linha digitada.");
    }


    public void EndDialogue()
    {
        Debug.Log("Fim do diálogo.");

        isDialogueActive = false;
        dialogueArea.text = "";
        dialogueBox.SetActive(false);
    }

}

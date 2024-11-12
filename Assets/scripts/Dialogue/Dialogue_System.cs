using UnityEngine;

//função que gera estados para o diálogo
public enum STATE
{
    DISABLED,
    WAITING,
    TYPING
}

public class Dialogue_System : MonoBehaviour
{
//=====VARIÁVEIS DO DIÁLOGO=====//
    public DialogueData dialogueData;
    int currentText = 0;
    bool finished = false;

    //criando variáveis chamando scripts e componentes
    TypeTextAnimation typeText;
    DialogueUI dialogueUI;

    //a função state vai ser usada como state
    STATE state;

    void Awake()
    {
        //chamando as funções que serão utilizadas
        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI = FindObjectOfType<DialogueUI>();

        typeText.TypeFinished = OnTypeFinishe;
    }

    void Start()
    {
        //atualiza o estado padrão como desabilitado 
        state = STATE.DISABLED;
    }

    void Update()
    {
        if (state == STATE.DISABLED) return;

        switch (state)
        {
            //quando estiver no estado de espera ele chama a função Waiting
            case STATE.WAITING:
                Waiting();
                break;

            //qunado estiver no estado de digitando ele chama a função Typing
            case STATE.TYPING:
                Typing();
                break;
        }
    }

    public void Next()
    {
        //se ainda estiver texto ele vai continuar escrevendo 
        if (currentText == 0)
        {
            dialogueUI.Enable();
        }
        //se o texto atual for menor que a quantidade em dialogue Data
        if (currentText < dialogueData.talkScript.Count)
        {
            //o nome vai ser colocado a partir do que foi colocado em dialogue Data
            dialogueUI.SetName(dialogueData.talkScript[currentText].Name);
            //o texto vai ser colocado a partir do que foi colocado em dialogue Data
            typeText.fullText = dialogueData.talkScript[currentText].Text;
            currentText++;
            //se a quantidade de texto for igual ao que tinha em dialogue Data, então ele encerra e chama a função Typing
            if (currentText == dialogueData.talkScript.Count) finished = true;
            typeText.StartTyping();
            state = STATE.TYPING;
        }

    }
    
    //função para atualizar o estado para Waiting
    void OnTypeFinishe()
    {
        state = STATE.WAITING;
    }

    void Waiting()
    {
        //quando a tecla return for pressionada, chama a função next
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!finished)
            {
                Next();
            }
            //caso não seja 
            else
            {
                //a caixa de diálogo é desabilitada
                dialogueUI.Disable();
                //o estado é desabilitado
                state = STATE.DISABLED;
                //o texto atual zera
                currentText = 0;
                finished = false;
            }
        }
    }

    void Typing()
    {
        //caso a tecla return seja pressionada 
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //pula o texto que está aparecendo
            typeText.Skip();
            //atualiza o estado para Waiting
            state = STATE.WAITING;
        }
    }
}
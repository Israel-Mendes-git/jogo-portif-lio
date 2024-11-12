using UnityEngine;

//fun��o que gera estados para o di�logo
public enum STATE
{
    DISABLED,
    WAITING,
    TYPING
}

public class Dialogue_System : MonoBehaviour
{
//=====VARI�VEIS DO DI�LOGO=====//
    public DialogueData dialogueData;
    int currentText = 0;
    bool finished = false;

    //criando vari�veis chamando scripts e componentes
    TypeTextAnimation typeText;
    DialogueUI dialogueUI;

    //a fun��o state vai ser usada como state
    STATE state;

    void Awake()
    {
        //chamando as fun��es que ser�o utilizadas
        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI = FindObjectOfType<DialogueUI>();

        typeText.TypeFinished = OnTypeFinishe;
    }

    void Start()
    {
        //atualiza o estado padr�o como desabilitado 
        state = STATE.DISABLED;
    }

    void Update()
    {
        if (state == STATE.DISABLED) return;

        switch (state)
        {
            //quando estiver no estado de espera ele chama a fun��o Waiting
            case STATE.WAITING:
                Waiting();
                break;

            //qunado estiver no estado de digitando ele chama a fun��o Typing
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
            //se a quantidade de texto for igual ao que tinha em dialogue Data, ent�o ele encerra e chama a fun��o Typing
            if (currentText == dialogueData.talkScript.Count) finished = true;
            typeText.StartTyping();
            state = STATE.TYPING;
        }

    }
    
    //fun��o para atualizar o estado para Waiting
    void OnTypeFinishe()
    {
        state = STATE.WAITING;
    }

    void Waiting()
    {
        //quando a tecla return for pressionada, chama a fun��o next
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!finished)
            {
                Next();
            }
            //caso n�o seja 
            else
            {
                //a caixa de di�logo � desabilitada
                dialogueUI.Disable();
                //o estado � desabilitado
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
            //pula o texto que est� aparecendo
            typeText.Skip();
            //atualiza o estado para Waiting
            state = STATE.WAITING;
        }
    }
}
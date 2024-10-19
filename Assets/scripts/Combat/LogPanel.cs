using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogPanel : MonoBehaviour
{
    // Inst�ncia atual do LogPanel
    protected static LogPanel current;

    // Label para exibir mensagens no painel de log
    public Text logLabel;

    void Awake()
    {
        // Define a inst�ncia atual do LogPanel
        current = this;
    }

    // M�todo est�tico para escrever mensagens no painel de log
    public static void Write(string message)
    {
        // Atualiza o texto do logLabel com a mensagem recebida
        current.logLabel.text = message;
    }
}

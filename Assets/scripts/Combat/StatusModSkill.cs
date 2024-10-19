using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusModSkill : Skill
{
    [Header("Status mod Skill")]
    public string message;

    protected StatusMod mod;

    protected override void OnRun()
    {
        // Verifica se o modificador ainda não foi inicializado
        if (this.mod == null)
        {
            this.mod = this.GetComponent<StatusMod>();
        }

        // Adiciona a mensagem formatada na fila de mensagens
        this.messages.Enqueue(this.message.Replace("{receiver}", this.receiver.idName));

        // Adiciona o modificador de status ao lutador receptor
        this.receiver.statusMods.Add(this.mod);
    }
}

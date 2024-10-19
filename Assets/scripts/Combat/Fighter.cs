using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe abstrata que serve como base para todos os lutadores
public abstract class Fighter : MonoBehaviour
{
    //=====VARI�VEIS DO FIGHTER=====//
    public string idName; // Nome do lutador
    public StatusPanel statusPanel; // Painel de status associado ao lutador

    public CombatManager combatManager; // Gerenciador de combate

    public List<StatusMod> statusMods;

    protected Stats stats; // Estat�sticas do lutador (health, attack, etc.)

    protected Skill[] skills; // Corrigido para Skill com letra mai�scula

    public bool isAlive
    {
        get => this.stats.health > 0; // Retorna se o lutador est� vivo
    }

    // M�todo chamado no in�cio da vida do objeto
    protected virtual void Start()
    {
        // Configura o painel de status com o nome e as estat�sticas do lutador
        this.statusPanel.SetStats(this.idName, this.stats);
        this.skills = this.GetComponentsInChildren<Skill>(); // Obt�m as habilidades do lutador

        this.statusMods = new List<StatusMod>();
    }

    // M�todo para modificar a sa�de do lutador
    public void ModifyHealth(float amount)
    {
        // Ajusta a sa�de, garantindo que n�o ultrapasse os limites (0 a maxHealth)
        this.stats.health = Mathf.Clamp(this.stats.health + amount, 0f, this.stats.maxHealth);

        this.stats.health = Mathf.Round(this.stats.health);
        // Atualiza o painel de status com a nova sa�de
        this.statusPanel.SetHealth(this.stats.health, this.stats.maxHealth);
    }

    // M�todo para obter as estat�sticas atuais do lutador
    public Stats GetCurrentStats()
    {
        Stats modedStats = this.stats;
        
        foreach (var mod in this.statusMods)
        {
            modedStats = mod.Apply(modedStats);
        }

        return modedStats; // Retorna as estat�sticas atuais
    }

    // M�todo abstrato que deve ser implementado pelas classes que herdam de Fighter
    public abstract void InitTurn(); // M�todo para iniciar o turno do lutador
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe abstrata que serve como base para todos os lutadores
public abstract class Fighter : MonoBehaviour
{
    //=====VARIÁVEIS DO FIGHTER=====//
    public string idName; // Nome do lutador
    public StatusPanel statusPanel; // Painel de status associado ao lutador

    public CombatManager combatManager; // Gerenciador de combate

    public List<StatusMod> statusMods;

    protected Stats stats; // Estatísticas do lutador (health, attack, etc.)

    protected Skill[] skills; // Corrigido para Skill com letra maiúscula

    public bool isAlive
    {
        get => this.stats.health > 0; // Retorna se o lutador está vivo
    }

    // Método chamado no início da vida do objeto
    protected virtual void Start()
    {
        // Configura o painel de status com o nome e as estatísticas do lutador
        this.statusPanel.SetStats(this.idName, this.stats);
        this.skills = this.GetComponentsInChildren<Skill>(); // Obtém as habilidades do lutador

        this.statusMods = new List<StatusMod>();
    }

    // Método para modificar a saúde do lutador
    public void ModifyHealth(float amount)
    {
        // Ajusta a saúde, garantindo que não ultrapasse os limites (0 a maxHealth)
        this.stats.health = Mathf.Clamp(this.stats.health + amount, 0f, this.stats.maxHealth);

        this.stats.health = Mathf.Round(this.stats.health);
        // Atualiza o painel de status com a nova saúde
        this.statusPanel.SetHealth(this.stats.health, this.stats.maxHealth);
    }

    // Método para obter as estatísticas atuais do lutador
    public Stats GetCurrentStats()
    {
        Stats modedStats = this.stats;
        
        foreach (var mod in this.statusMods)
        {
            modedStats = mod.Apply(modedStats);
        }

        return modedStats; // Retorna as estatísticas atuais
    }

    // Método abstrato que deve ser implementado pelas classes que herdam de Fighter
    public abstract void InitTurn(); // Método para iniciar o turno do lutador
}

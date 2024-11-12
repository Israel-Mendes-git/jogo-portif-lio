using System.Collections.Generic;
using UnityEngine;
using Combat; // Importa o namespace Combat

public abstract class Fighter : MonoBehaviour
{
    public string idName; // Nome do lutador
    public StatusPanel statusPanel; // Painel de status associado ao lutador
    public CombatManager combatManager; // Gerenciador de combate

    protected bool isAlive => stats.Health > 0; // Altere para:
    public bool IsAlive => stats.Health > 0; // Agora � p�blico

    public List<StatusMod> statusMods;
    protected Stats stats; // Supondo que voc� tenha uma classe Stats definida em outro lugar
    public Skill[] skills;
 
    public float CurrentHealth => stats.Health; // Acesso � propriedade
    public float MaxHealth => stats.MaxHealth; // Acesso � propriedade
    public int Level => stats.Level; // Acesso � propriedade

    public void InitializeStatsPanel( float Health, float maxHealth, int level)
    {
        statusPanel.SetHealth(Health, maxHealth); // Atualiza o painel de status
        statusPanel.SetStats(idName, Health, maxHealth, level);
    }

    protected virtual void InitializeStats(float initialHealth, float maxHealth, int level)
    {
        stats = new Stats(level, maxHealth, initialHealth, 0, 0); // Passando os par�metros corretos

    }
    

    public void ModifyHealth(float amount)
    {
        if (stats == null)
        {
            Debug.LogError("Stats n�o inicializado!");
            return;
        }

        stats.AdjustHealth(amount); // Ajusta a sa�de
        statusPanel.SetHealth(stats.Health, stats.MaxHealth); // Atualiza o painel de status
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

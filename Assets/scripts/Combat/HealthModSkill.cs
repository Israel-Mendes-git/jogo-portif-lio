using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enum para definir os tipos de modificação de saúde
public enum HealthModType
{
    STAT_BASED, // Baseado em estatísticas
    FIXED,      // Fixo
    PERCENTAGE  // Percentual
}

// Classe que representa uma habilidade que modifica a saúde
public class HealthModSkill : Skill // Corrigido para herdar de Skill com letra maiúscula
{
    [Header("Health Mod")]
    public float amount; // Quantidade a ser modificada

    public HealthModType modType; // Tipo de modificação de saúde

    [Range(0f, 1f)]
    public float critChance = 0;

    // Método que executa a habilidade
    protected override void OnRun()
    {
        float amount = this.GetModification(); // Obtém a quantidade de modificação

        float dice = Random.Range(0f, 1f);

        if(dice <= this.critChance)
        {
            amount *= 2f;
            this.messages.Enqueue("Acerto crítico!");
        }

        this.receiver.ModifyHealth(amount); // Modifica a saúde do receptor
    }

    // Método que calcula a modificação com base no tipo
    public float GetModification()
    {
        switch (this.modType)
        {
            case HealthModType.STAT_BASED:
                Stats emitterStats = this.emitter.GetCurrentStats(); // Estatísticas do emissor
                Stats receiverStats = this.receiver.GetCurrentStats(); // Estatísticas do receptor

                // Cálculo de dano bruto
                float rawDamage = (((2 * emitterStats.level) / 5) + 2) * this.amount * (emitterStats.attack / receiverStats.defense);

                return (rawDamage / 50) + 2; // Retorna a modificação de saúde

            case HealthModType.FIXED:
                return this.amount; // Retorna a quantidade fixa

            case HealthModType.PERCENTAGE:
                Stats rStats = this.receiver.GetCurrentStats(); // Estatísticas do receptor

                return rStats.maxHealth * this.amount; // Retorna a modificação percentual
        }

        throw new System.InvalidOperationException("HealthModSkill::GetModification.Unreachable!"); // Exceção caso o código não entre em nenhum caso
    }
}

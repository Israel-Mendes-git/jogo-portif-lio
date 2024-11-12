using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;

public enum StatusModType
{
    ATTACK_MOD,
    DEFFENSE_MOD
}

public class StatusMod : MonoBehaviour
{
    public StatusModType type;
    public float amount;

    public Stats Apply(Stats stats)
    {
        Stats modedStats = stats.Clone();

        switch (this.type)
        {
            case StatusModType.ATTACK_MOD:
                modedStats.Attack += this.amount; // Usar a propriedade Attack
                break;

            case StatusModType.DEFFENSE_MOD:
                modedStats.Defense += this.amount; // Usar a propriedade Defense
                break;
        }

        return modedStats;
    }

    public void ApplyMod(Stats stats)
    {
        // Acesse as propriedades corretamente
        float attackValue = stats.Attack; // Correto
        float defenseValue = stats.Defense; // Correto
        // ...
    }
}


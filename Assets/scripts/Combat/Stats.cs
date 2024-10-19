using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //===== VARIÁVEIS DOS STATS =====//
    public float health;      // Vida atual do lutador
    public float maxHealth;   // Vida máxima do lutador

    public int level;         // Nível do lutador
    public float attack;      // Poder de ataque do lutador
    public float defense;     // Poder de defesa do lutador
    public float spirit;      // Poder espiritual do lutador

    // Construtor para inicializar as estatísticas do lutador
    public Stats(int level, float maxHealth, float attack, float defense, float spirit)
    {
        this.level = level;                // Define o nível do lutador
        this.maxHealth = maxHealth;        // Define a vida máxima
        this.health = maxHealth;           // Inicializa a vida atual com a vida máxima
        this.attack = attack;              // Define o poder de ataque
        this.defense = defense;            // Define o poder de defesa
        this.spirit = spirit;              // Define o poder espiritual
    }

    // Método para criar uma cópia dos stats atuais
    public Stats Clone()
    {
        return new Stats(this.level, this.maxHealth, this.attack, this.defense, this.spirit); // Retorna uma nova instância com os mesmos valores
    }
}

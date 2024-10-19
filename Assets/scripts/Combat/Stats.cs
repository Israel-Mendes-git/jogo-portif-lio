using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //===== VARI�VEIS DOS STATS =====//
    public float health;      // Vida atual do lutador
    public float maxHealth;   // Vida m�xima do lutador

    public int level;         // N�vel do lutador
    public float attack;      // Poder de ataque do lutador
    public float defense;     // Poder de defesa do lutador
    public float spirit;      // Poder espiritual do lutador

    // Construtor para inicializar as estat�sticas do lutador
    public Stats(int level, float maxHealth, float attack, float defense, float spirit)
    {
        this.level = level;                // Define o n�vel do lutador
        this.maxHealth = maxHealth;        // Define a vida m�xima
        this.health = maxHealth;           // Inicializa a vida atual com a vida m�xima
        this.attack = attack;              // Define o poder de ataque
        this.defense = defense;            // Define o poder de defesa
        this.spirit = spirit;              // Define o poder espiritual
    }

    // M�todo para criar uma c�pia dos stats atuais
    public Stats Clone()
    {
        return new Stats(this.level, this.maxHealth, this.attack, this.defense, this.spirit); // Retorna uma nova inst�ncia com os mesmos valores
    }
}

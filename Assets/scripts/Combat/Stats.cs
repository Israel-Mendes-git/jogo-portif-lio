using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class Stats
    {
        //===== VARI�VEIS DOS STATS =====//
        public float Health { get; private set; }      // Vida atual do lutador
        public float MaxHealth { get; private set; }   // Vida m�xima do lutador

        public int Level { get; private set; }         // N�vel do lutador
        public float Attack { get; set; }      // Poder de ataque do lutador
        public float Defense { get; set; }     // Poder de defesa do lutador
        public float Spirit { get; private set; }      // Poder espiritual do lutador
      


        // Construtor para inicializar as estat�sticas do lutador
        public Stats(int level, float maxHealth, float attack, float defense, float spirit)
        {
            Level = level;                // Define o n�vel do lutador
            MaxHealth = maxHealth;        // Define a vida m�xima
            Health = maxHealth;           // Inicializa a vida atual com a vida m�xima
            Attack = attack;              // Define o poder de ataque
            Defense = defense;            // Define o poder de defesa
            Spirit = spirit;              // Define o poder espiritual


        }

        // M�todo para criar uma c�pia dos stats atuais
        public Stats Clone()
        {
            return new Stats(Level, MaxHealth, Attack, Defense, Spirit); // Retorna uma nova inst�ncia com os mesmos valores
        }

        public void AdjustHealth(float amount)
        {
            Health = Mathf.Clamp(Health + amount, 0, MaxHealth);
        }

        public void LevelUp()
        {
            Level++;
            MaxHealth += 10; // Exemplo de aumento
            Health = MaxHealth; // Restaura a vida ao m�ximo ap�s o n�vel
            Attack += 2; // Aumenta o ataque ao subir de n�vel
        }
    }
}

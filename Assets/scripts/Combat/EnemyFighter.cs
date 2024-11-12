using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;

public class EnemyFighter : Fighter // Classe que representa um lutador inimigo, herda de Fighter
{
    void Awake()
    {
        // Inicializa os stats do inimigo com valores específicos
        this.stats = new Stats(20, 50, 40, 30, 60);
    }

    // Método chamado no início do turno do inimigo
    public override void InitTurn()
    {
        StartCoroutine(this.IA());
    }

    IEnumerator IA()
    {
        yield return new WaitForSeconds(1f); // Espera 1 segundo

        // Corrigido: uso correto de Random.Range
        Skill skill = this.skills[Random.Range(0, this.skills.Length)];

        skill.SetEmitterAndReceiver(
            this, this.combatManager.GetOpposingFighter()
        );

        this.combatManager.OnFighterSkill(skill); // Chama o método para executar a habilidade
    }
}

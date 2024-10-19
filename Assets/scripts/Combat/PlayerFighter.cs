using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : Fighter
{

    [Header("UI")]
    public PlayerSkillPanel skillPanel;

    // Inicializa as estat�sticas do jogador
    void Awake()
    {
        this.stats = new Stats(21, 60, 50, 45, 20); // Define os valores das estat�sticas
    }

    // M�todo que inicia o turno do jogador
    public override void InitTurn()
    {
        this.skillPanel.Show();

        for (int i = 0; i < this.skills.Length; i++)
        {
            this.skillPanel.ConfigureButtons(i, this.skills[i].skillName);
        }
    }
    ///========================================
    ///<summary>
    /// se chama dos bot�es do painel de habilidades
    ///</summary>
    ///<param name= "index"></param>
    public void ExecuteSkill(int index)
    {
        this.skillPanel.Hide();

        Skill skill = this.skills[index];

        skill.SetEmitterAndReceiver(
            this, this.combatManager.GetOpposingFighter()
        );

        this.combatManager.OnFighterSkill(skill);

        
    }
}

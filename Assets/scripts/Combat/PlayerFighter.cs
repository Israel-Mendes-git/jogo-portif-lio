using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;

public class PlayerFighter : Fighter
{
    [Header("UI")]
    public PlayerSkillPanel skillPanel;

    // Defina uma lista ou array de habilidades
    public Skill[] skills = new Skill[5]; // Adicione esta linha para definir 'skills'

    // Inicializa as estatísticas do jogador
    void Awake()
    {
        this.stats = new Stats(1, 20, 15, 8, 1); // Define os valores das estatísticas
    }

    // Método que inicia o turno do jogador
    public override void InitTurn()
    {
        this.skillPanel.Show();
        Debug.Log(this.skills);

        if (this.skills != null && this.skills.Length > 0)
        {
            for (int i = 0; i < this.skills.Length; i++)
            {
                if (this.skills[i] != null)
                {
                    this.skillPanel.ConfigureButtons(i, this.skills[i].skillName);
                }
                else
                {
                    Debug.LogWarning($"A habilidade na posição {i} está null.");
                }
            }
        }
        else
        {
            Debug.LogWarning("skills está null ou vazio. Certifique-se de inicializá-lo com habilidades.");
        }
    }

    ///========================================
    ///<summary>
    /// se chama dos botões do painel de habilidades
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

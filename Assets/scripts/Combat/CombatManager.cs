using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CombatStatus
{
    WAITING_FOR_FIGHTER,
    FIGHTER_ACTION,
    CHECK_ACTION_MESSAGES,
    CHECK_FOR_VICTORY,
    NEXT_TURN
}

public class CombatManager : MonoBehaviour
{
    //=====VARI�VEIS DO COMBAT MANAGER=====//
    public Fighter[] fighters; // Array de lutadores envolvidos na batalha
    private int fighterIndex; // �ndice do lutador atual que est� fazendo o turno

    private bool isCombatActive; // Indica se a batalha est� ativa

    private CombatStatus combatStatus;

    private Skill currentFighterSkill;

    public string cena;

    void Start()
    {
        // Informa que a batalha come�ou
        LogPanel.Write("A batalha come�ou.");

        foreach(var fgtr in this.fighters)
        {
            fgtr.combatManager = this;
        }


        this.combatStatus = CombatStatus.NEXT_TURN;

        this.fighterIndex = -1; // Inicializa o �ndice do lutador para o primeiro
        this.isCombatActive = true; // Define que o combate est� ativo
        StartCoroutine(this.CombatLoop()); // Inicia o loop de combate
    }

    // Coroutine que controla a sequ�ncia de turnos dos lutadores
    IEnumerator CombatLoop()
    {
        while (this.isCombatActive) // Enquanto o combate estiver ativo
        {
            switch (this.combatStatus)
            {
                case CombatStatus.WAITING_FOR_FIGHTER:
                    yield return null;
                    break;

                case CombatStatus.FIGHTER_ACTION:
                    LogPanel.Write($"{this.fighters[this.fighterIndex].idName} usou {currentFighterSkill.skillName}.");
                    

                    yield return null;

                    currentFighterSkill.Run();

                    yield return new WaitForSeconds(currentFighterSkill.animationDuration);
                    this.combatStatus = CombatStatus.CHECK_ACTION_MESSAGES;

                    break;

                case CombatStatus.CHECK_ACTION_MESSAGES:
                    string nextMessage = this.currentFighterSkill.GetNextMessage();

                    if(nextMessage != null)
                    {
                        LogPanel.Write(nextMessage);
                        yield return new WaitForSeconds(2f);
                    }
                    else
                    {
                        this.currentFighterSkill = null;
                        this.combatStatus = CombatStatus.CHECK_FOR_VICTORY;
                        yield return null;
                    }
                    break;


                case CombatStatus.CHECK_FOR_VICTORY:
                    foreach (var fgtr in this.fighters)
                    {
                        if(fgtr.isAlive == false)
                        {
                            this.isCombatActive = false;

                            LogPanel.Write("Vit�ria!");

                            SceneManager.LoadScene(cena);
                        }
                        else
                        {
                            this.combatStatus = CombatStatus.NEXT_TURN;
                        }
                    }
                    yield return null;
                    break;
                case CombatStatus.NEXT_TURN:
                    yield return new WaitForSeconds(1f);
                    // Atualiza o �ndice para o pr�ximo lutador, voltando ao in�cio se chegar ao final
                    this.fighterIndex = (this.fighterIndex + 1) % this.fighters.Length;

                    // Obt�m o lutador atual baseado no �ndice
                    var currentTurn = this.fighters[this.fighterIndex];

                    // Informa quem � o lutador da vez
                    LogPanel.Write($"{currentTurn.idName} � o seu turno.");
                    currentTurn.InitTurn(); // Chama o m�todo para iniciar o turno do lutador 

                    this.combatStatus = CombatStatus.WAITING_FOR_FIGHTER;

                    break;
            }
            
        }
    }

    public Fighter GetOpposingFighter()
    {
        if(this.fighterIndex == 0)
        {
            return this.fighters[1];
        } 
        else
        {
            return this.fighters[0];
        }
    }

    public void OnFighterSkill(Skill skill)
    {
        this.currentFighterSkill = skill;
        this.combatStatus = CombatStatus.FIGHTER_ACTION;
    }
}

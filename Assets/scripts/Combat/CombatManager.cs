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
    //=====VARIÁVEIS DO COMBAT MANAGER=====//
    public Fighter[] fighters; // Array de lutadores envolvidos na batalha
    private int fighterIndex; // Índice do lutador atual que está fazendo o turno

    private bool isCombatActive; // Indica se a batalha está ativa

    private CombatStatus combatStatus;

    private Skill currentFighterSkill;

    public string cena;

    void Start()
    {
        // Informa que a batalha começou
        LogPanel.Write("A batalha começou.");

        foreach(var fgtr in this.fighters)
        {
            fgtr.combatManager = this;
        }


        this.combatStatus = CombatStatus.NEXT_TURN;

        this.fighterIndex = -1; // Inicializa o índice do lutador para o primeiro
        this.isCombatActive = true; // Define que o combate está ativo
        StartCoroutine(this.CombatLoop()); // Inicia o loop de combate
    }

    // Coroutine que controla a sequência de turnos dos lutadores
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

                            LogPanel.Write("Vitória!");

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
                    // Atualiza o índice para o próximo lutador, voltando ao início se chegar ao final
                    this.fighterIndex = (this.fighterIndex + 1) % this.fighters.Length;

                    // Obtém o lutador atual baseado no índice
                    var currentTurn = this.fighters[this.fighterIndex];

                    // Informa quem é o lutador da vez
                    LogPanel.Write($"{currentTurn.idName} é o seu turno.");
                    currentTurn.InitTurn(); // Chama o método para iniciar o turno do lutador 

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

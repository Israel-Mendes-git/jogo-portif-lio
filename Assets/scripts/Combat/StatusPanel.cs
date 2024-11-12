using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour
{
    //===== VARI�VEIS DO STATUS PANEL =====//
    public Text nameLabel; // Texto para exibir o nome do lutador
    public Text levelLabel; // Texto para exibir o n�vel do lutador
    public Slider healthSlider; // Slider para mostrar a sa�de do lutador
    public Image healthSliderBar; // Imagem que representa a barra de sa�de
    public Text healthLabel; // Texto para exibir a quantidade de sa�de

   

    // M�todo para definir as estat�sticas do lutador
    public void SetStats(string name, float health, float maxHealth, int level)
    {
        nameLabel.text = name; // Atualiza o nome do lutador
        levelLabel.text = $"N. {level}"; // Atualiza o n�vel do lutador
        SetHealth(health, maxHealth); // Chama o m�todo para atualizar a sa�de
    }


    // M�todo para definir a sa�de do lutador
    public void SetHealth(float health, float maxHealth)
    {
        healthLabel.text = $"{Mathf.RoundToInt(health)} / {Mathf.RoundToInt(maxHealth)}"; // Atualiza o texto da sa�de
        float percentage = health / maxHealth; // Calcula a porcentagem de sa�de

        healthSlider.value = percentage; // Atualiza o slider de sa�de

        // Muda a cor da barra de sa�de se a sa�de estiver baixa
        healthSliderBar.color = percentage < 0.33f ? Color.red : Color.green;
    }

    
}

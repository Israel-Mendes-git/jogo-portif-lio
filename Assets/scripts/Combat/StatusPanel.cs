using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour
{
    //===== VARIÁVEIS DO STATUS PANEL =====//
    public Text nameLabel; // Texto para exibir o nome do lutador
    public Text levelLabel; // Texto para exibir o nível do lutador
    public Slider healthSlider; // Slider para mostrar a saúde do lutador
    public Image healthSliderBar; // Imagem que representa a barra de saúde
    public Text healthLabel; // Texto para exibir a quantidade de saúde

   

    // Método para definir as estatísticas do lutador
    public void SetStats(string name, float health, float maxHealth, int level)
    {
        nameLabel.text = name; // Atualiza o nome do lutador
        levelLabel.text = $"N. {level}"; // Atualiza o nível do lutador
        SetHealth(health, maxHealth); // Chama o método para atualizar a saúde
    }


    // Método para definir a saúde do lutador
    public void SetHealth(float health, float maxHealth)
    {
        healthLabel.text = $"{Mathf.RoundToInt(health)} / {Mathf.RoundToInt(maxHealth)}"; // Atualiza o texto da saúde
        float percentage = health / maxHealth; // Calcula a porcentagem de saúde

        healthSlider.value = percentage; // Atualiza o slider de saúde

        // Muda a cor da barra de saúde se a saúde estiver baixa
        healthSliderBar.color = percentage < 0.33f ? Color.red : Color.green;
    }

    
}

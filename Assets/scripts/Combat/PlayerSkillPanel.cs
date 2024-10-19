using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Adicionada a diretiva de using para acessar a classe Text

public class PlayerSkillPanel : MonoBehaviour
{
    public GameObject[] skillButtons; // Bot�es das habilidades
    public Text[] skillButtonLabels; // R�tulos das habilidades nos bot�es

    void Awake()
    {
        this.Hide(); // Esconde o painel de habilidades ao iniciar

        foreach (var btn in this.skillButtons)
        {
            btn.SetActive(false); // Desativa todos os bot�es inicialmente
        }
    }

    // Configura um bot�o de habilidade espec�fico
    public void ConfigureButtons(int index, string skillName)
    {
        this.skillButtons[index].SetActive(true); // Ativa o bot�o
        this.skillButtonLabels[index].text = skillName; // Define o nome da habilidade
    }

    // Mostra o painel de habilidades
    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    // Esconde o painel de habilidades
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}

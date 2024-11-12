using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
//===VARI�VEIS DA IMAGEM DO DI�LOGO===//
    Image background;
    TextMeshProUGUI nameText;
    TextMeshProUGUI talkText;
    public float speed = 10f;
    bool open = false;
    

    void Awake()
    {
        //os valores dos filhos s�o atribuidos as vari�veis  
        background = transform.GetChild(0).GetComponent<Image>();
        nameText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        talkText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //se open for verdadeiro 
        if (open)
        {
            //preenche o fundo gradualmente 
            background.fillAmount = Mathf.Lerp(background.fillAmount, 1, speed * Time.deltaTime);
        }
        //caso n�o
        else
        {
            //fecha o fundo gradualmente
            background.fillAmount = Mathf.Lerp(background.fillAmount, 0, speed * Time.deltaTime);
        }
    }

    public void SetName(string name)
    {
        //a vari�vel do nome � preenchida com o nome que foi colocado
        nameText.text = name;
    }

    //caso esteja aberto
    public void Enable()
    {
        //o fundo � preenchido 
        background.fillAmount = 0;
        //open se torna verdadeiro 
        open = true;
        
    }

    //caso esteja fechado
    public void Disable()
    {
        //open se torna falso
        open = false;
        //preenche o nome com um espa�o vazio 
        nameText.text = "";
        //preenche o texto com um espa�o vazio
        talkText.text = "";
        

        
    }

}
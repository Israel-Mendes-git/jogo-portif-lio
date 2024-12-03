using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    //chama o script entity
    public entity entity;

    //define os componentes que vão ser usados
    [Header("Player UI")]
    public Text strTxt;
    public Text resTxt;
    public Text agiTxt;
    public Text pointsTxt;
    public Button strPositiveBtn;
    public Button resPositiveBtn;
    public Button agiPositiveBtn;
    public Button strNegativeBtn;
    public Button resNegativeBtn;
    public Button agiNegativeBtn;
    
    //define a tecla para abrir o inventário
    [Header("Player inventory")]
    public KeyCode inventoryKey = KeyCode.I;

    //define o objeto que vai ser ativado, no caso o inventário
    [Header("Player UI Panels")]
    public GameObject inventory;

    void Start()
    {
        UpdatePoints();
        SetupUIButtons();
    }
   
    private void Update()
    {
        
        //ativa o inventário caso pressione a tecla 
        if (Input.GetKeyUp(inventoryKey))
        {
            inventory.SetActive(!inventory.activeSelf);
        }


    }

    public void UpdatePoints()
    {
        //converto os pontos para string
        strTxt.text = entity.strength.ToString();
        resTxt.text = entity.resistence.ToString();
        agiTxt.text = entity.agility.ToString();
        pointsTxt.text = entity.points.ToString();
    }

    public void SetupUIButtons()
    {
        //adiciona ou remove pontos caso seja clicado 
        strPositiveBtn.onClick.AddListener(() => AddPoints(1));
        resPositiveBtn.onClick.AddListener(() => AddPoints(2));
        agiPositiveBtn.onClick.AddListener(() => AddPoints(3));

        strNegativeBtn.onClick.AddListener(() => RemovePoints(1));
        resNegativeBtn.onClick.AddListener(() => RemovePoints(2));
        agiNegativeBtn.onClick.AddListener(() => RemovePoints(3));

    }
   

    public void AddPoints(int index)
    {
        //define o valor mínimo para a quantidade de pontos
        if (entity.points > 0)
        {
            if (index == 1)
            {
                entity.strength++;
                entity.damage++;
            }
            else if (index == 2)
            {
                entity.resistence++;
                entity.defense++;
            }
            else if (index == 3)
            {
                entity.agility++;
                entity.speed += 0.1f;
            }
            entity.points--;
            UpdatePoints();
        }

    }

    public void RemovePoints(int index)
    {
        //remove uma quantidade de pontos
            if (index == 1 && entity.strength > 0)
                entity.strength--;
            else if (index == 2 && entity.resistence > 0)
                entity.resistence--;
            else if (index == 3 && entity.agility > 0)
                entity.agility--;

            entity.points++;
            UpdatePoints();

    }
}
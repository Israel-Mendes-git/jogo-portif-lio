using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{

    public entity entity;

    [Header("Player UI")]
    public Slider health;
    public Slider stamina;
    public Slider exp;
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

    [Header("Player shortcuts")]
    public KeyCode attributeKey = KeyCode.C;

    [Header("Player UI Panels")]
    public GameObject attributesPanel;


    [Header("Player inventory")]
    public KeyCode inventoryKey = KeyCode.I;

    [Header("Player UI Panels")]
    public GameObject inventory;

    void Start()
    {
        entity.currentHealth = entity.maxHealth;
        entity.currentStamina = entity.maxStamina;

        health.maxValue = entity.maxStamina;
        health.value = health.maxValue;

        stamina.maxValue = entity.maxStamina;
        stamina.value = stamina.maxValue;

        exp.value = 0;

        UpdatePoints();
        SetupUIButtons();
    }
   
    private void Update()
    {
        if (Input.GetKeyUp(attributeKey))
        {
            attributesPanel.SetActive(!attributesPanel.activeSelf);
        }
        if (Input.GetKeyUp(inventoryKey))
        {
            inventory.SetActive(!inventory.activeSelf);
        }

        health.value = entity.currentHealth;
        stamina.value = entity.currentStamina;

    }

    public void UpdatePoints()
    {
        strTxt.text = entity.strength.ToString();
        resTxt.text = entity.resistence.ToString();
        agiTxt.text = entity.agility.ToString();
        pointsTxt.text = entity.points.ToString();
    }

    public void SetupUIButtons()
    {
        strPositiveBtn.onClick.AddListener(() => AddPoints(1));
        resPositiveBtn.onClick.AddListener(() => AddPoints(2));
        agiPositiveBtn.onClick.AddListener(() => AddPoints(3));

        strNegativeBtn.onClick.AddListener(() => RemovePoints(1));
        resNegativeBtn.onClick.AddListener(() => RemovePoints(2));
        agiNegativeBtn.onClick.AddListener(() => RemovePoints(3));

    }
   

    public void AddPoints(int index)
    {
        if (index == 1)
            entity.strength++;
        else if (index == 2)
            entity.resistence++;
        else if (index == 3)
            entity.agility++;
        UpdatePoints();
    }

    public void RemovePoints(int index)
    {
            if (index == 1 && entity.strength > 0)
                entity.strength--;
            else if (index == 2 && entity.resistence > 0)
                entity.resistence--;
            else if (index == 3 && entity.speed > 0)
                entity.agility--;
            
            UpdatePoints();
        
    }
}
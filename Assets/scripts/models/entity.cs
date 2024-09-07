using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class entity
{
    [Header("Name")]
    public string name;


    [Header("Stamina")]
    public int currentStamina;
    public int maxStamina;

    [Header("Stats")]
    public int strength = 1;
    public int resistence = 1;
    public int damage = 1;
    public int defense = 1;
    public float speed = 5.5f;
    public int points = 0;
    public int agility = 1;

    [Header("Experience")]
    public int currentExp;
    public int maxExp;
    public int currentlvl;

    private void OnEnable()
    {
        ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
    }
    private void OnDisable()
    {
        ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
    }
    private void HandleExperienceChange(int newExperience)
    {
        currentExp += newExperience;    
        if (currentExp >= maxExp )
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        points++;
        currentExp = 0;
        currentlvl++;
        maxExp += 50;
    }


}

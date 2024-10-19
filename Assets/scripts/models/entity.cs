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

   

  


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//criando uma opção no menu da pasta asset
[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public AttributesToChange AttributeToChange = new AttributesToChange();
    public int amountToChangeAttribute;

    public void UseItem()
    {
        if(statToChange == StatToChange.health)
        { 

        }
        
    }


    public enum StatToChange
    {   
        none,
        health,
        stamina
    };
    public enum AttributesToChange
    {
        none,
        strength,
        defese,
        intelligence,
        agility
    };

}

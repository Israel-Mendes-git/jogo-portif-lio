using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject player;

    [SerializeField]
    private GameObject StrengthAttPrefab;

    [SerializeField]
    private GameObject weakAttPrefab;

 


    private GameObject currentAttack;
    private GameObject strengthAttack;
    private GameObject weakAttack;

    public void SelectAttack(string btn)
    {
        GameObject victim = player;
        if(tag == "Player")
        {
            victim = enemy;
        }
        if (btn.CompareTo("strength") == 0)
        {
            Debug.Log("stength attack");
        } else if (btn.CompareTo("weak") == 0)
        {
            Debug.Log("weak attack");
        } else
        {
            Debug.Log("dodge");
        }
    }


    
}

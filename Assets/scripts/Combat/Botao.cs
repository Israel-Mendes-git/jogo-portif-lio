using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botao : MonoBehaviour
{
    [SerializeField]
    private bool physical;

    private GameObject player;


    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        GameObject player = GameObject.FindGameObjectWithTag("Player");

    }


    private void AttachCallback(string btn)
    {
        if (btn.CompareTo("strengthAttack") == 0 )
        {
            player.GetComponent<FighterAction>().SelectAttack("strength");
        } else if (btn.CompareTo("weakAttack") == 0 )
        {
            player.GetComponent<FighterAction>().SelectAttack("weak");
        } else
        {

        }
    }
}

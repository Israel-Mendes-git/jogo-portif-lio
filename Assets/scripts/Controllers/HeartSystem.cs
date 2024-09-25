using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public int vida;
    public int vidaMaxima;

    public Image[] heart;
    public Sprite cheio;
    public Sprite machucado;
    public Sprite ferido;
    public Sprite vazio;


    void Update()
    {
        Health();
        DeadState();
    }

    void Health()
    {
        if(vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }
        for (int i = 0;i < heart.Length; i++)
        {
            if (i < vida)
            {
                heart[i].sprite = cheio;
            }
            else
            {
                heart[i].sprite = vazio;
            }
            if ( i < vidaMaxima)
            {
                heart[i].enabled = true;
            }
            else
            {
                heart[i].enabled = false;
            }
        }
    }

    void DeadState()
    {
        if (vida <= 0)
        {
            GetComponent<player_controller>().enabled = false;
            Destroy(gameObject, 1.0f);
        }
    }

}

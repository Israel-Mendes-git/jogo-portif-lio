using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    private GameObject PontoAtaque = default;

    private bool attacking = false;
    public player_controller player;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    void Start()
    {

        player = GetComponent<player_controller>();

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Attack();
            player.OnAttack();

        }
        if (attacking)
        {
            timer += Time.deltaTime;
            
            if (timer > timeToAttack )
            {
                timer = 0;
                attacking = false;
                PontoAtaque.SetActive(attacking);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PontoAtaque = transform.GetChild(0).gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PontoAtaque = transform.GetChild(1).gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            PontoAtaque = transform.GetChild(2).gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            PontoAtaque = transform.GetChild(3).gameObject;
        }
    }

    private void Attack()
    {
        attacking = true;
        if (PontoAtaque != null)
        {
            PontoAtaque.SetActive(attacking);
        }
    }

}

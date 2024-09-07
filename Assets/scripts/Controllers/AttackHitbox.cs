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

    // Dicionário para mapear KeyCode para o índice do filho
    private Dictionary<KeyCode, int> keyToChildIndex = new Dictionary<KeyCode, int>
    {
        { KeyCode.D, 0 },
        { KeyCode.S, 1 },
        { KeyCode.W, 2 },
        { KeyCode.A, 3 }
    };
    
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
        // Itera sobre o dicionário para verificar se alguma tecla foi pressionada
        foreach (var entry in keyToChildIndex)
        {
            if (Input.GetKeyDown(entry.Key))
            {
                PontoAtaque = transform.GetChild(entry.Value).gameObject;
                break; // Opcional, para sair do loop após encontrar a tecla pressionada
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{

    public int attackDamage;
    public player player;
    public Collider2D attackCollider;

    void Start()
    {
        player = GetComponent<player>();
        if (player == null)
        {
            Debug.LogError("O componente 'entity' n�o foi encontrado no GameObject.");
            return; // Interrompe a execu��o se o componente 'entity' n�o for encontrado
        }
        
        attackDamage = player.entity.damage;
        if(attackCollider == null)
        {
            Debug.LogWarning("Collider do ataque n�o foi setado");
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        col.collider.SendMessage("OnHit", attackCollider);
    }
    
}

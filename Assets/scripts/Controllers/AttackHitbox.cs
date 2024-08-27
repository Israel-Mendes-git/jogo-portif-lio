using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{

    public float attackDamage = 1f;
    public Collider2D attackCollider;

    void Start()
    {
        if(attackCollider == null)
        {
            Debug.LogWarning("Collider do ataque não foi setado");
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        col.collider.SendMessage("OnHit", attackCollider);
    }
    
}

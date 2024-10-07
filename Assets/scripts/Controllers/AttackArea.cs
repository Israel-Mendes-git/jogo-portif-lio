using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //verifica se ele tá colidindo
        if (collider.GetComponent<Enemy>() != null)
        {
            //se ele estiver, chama a função OnHit
            Enemy hit = collider.GetComponent<Enemy>();
            hit.OnHit();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*fun��o que identifica se o player est� andando para a direita, esquerda, cima ou baixo 
  e seta a imagem/anima��o que vai mostrada na tela*/

public class playeranimation : MonoBehaviour
{
    public Animator anim;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;

    }
}

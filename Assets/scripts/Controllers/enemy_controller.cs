using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    public float speed = 2.5f;
    private Vector2 direction;
    private Rigidbody2D rig;

    public detection_controller detectionArea;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void FixedUpdate()
    {

        if (detectionArea != null && detectionArea.detectedObjs.Count > 0)
        {
            // Pega a posição do primeiro objeto detectado
            Vector2 targetPosition = detectionArea.detectedObjs[0].transform.position;

            // Calcula a direção em relação ao player detectado
            direction = (targetPosition - (Vector2)transform.position).normalized;

            // Move o inimigo na direção do jogador
            rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
        }

    }
}

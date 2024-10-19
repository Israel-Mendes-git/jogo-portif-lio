using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    public float moveSpeed = 2f;
    Rigidbody2D rig;
    public Transform target;
    Vector2 moveDirection;

    public Detection_controller detectionArea;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    { 
        if (target)
        {
            moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }

    private void FixedUpdate()
    {
        if(detectionArea.detectedObjs.Count > 0)
        {
            moveDirection = (detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

            rig.MovePosition(rig.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
        
    }
    
}


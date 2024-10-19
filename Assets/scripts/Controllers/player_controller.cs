using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(player))]

public class player_controller : MonoBehaviour
{
    Dialogue_System dialogue_System;
    private enum State
    {
        Normal,
        Rolando,
    }
    private State state;
    public player player;
    private Rigidbody2D rig;
    private float inicialSpeed;
    public float runSpeed;
    private Vector2 direction;
    private Vector3 rolldir;
    private float rollspeed;
    private bool dash;
    private Vector3 moviment;
    public LayerMask solidObjectsLayer;
    public LayerMask interactablesLayer;
    public Transform npc;
    public VectorValue startingPosition;

    [SerializeField]
    public Direction direcaoMovimento;



    void Awake()
    {
        state = State.Normal;
        rig = GetComponent<Rigidbody2D>();
        dialogue_System = FindObjectOfType<Dialogue_System>();

       
    }

    void Start()
    {
        player = GetComponent<player>();

        this.direcaoMovimento = Direction.Direita;
        //armazena o componente da f�sica
        
        transform.position = startingPosition.initialValue;

        inicialSpeed = player.entity.speed;
       
    }

    void Update()
    {
        switch (state)
        {
            case State.Normal:
                //armazena as dire��es horizontal e vertical
                direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

                if (Input.GetKeyDown(KeyCode.L))
                {
                    dash = true;    
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    direction = moviment;
                    rollspeed = player.entity.speed * 2;
                    state = State.Rolando;
                }
                break;
            case State.Rolando:
                float rollspeedmult = 5f;
                rollspeed -= rollspeedmult * rollspeed * Time.deltaTime;
                float minrollspd = 11f;
                if (rollspeed < minrollspd)
                {
                    state = State.Normal;
                }
                break;
        }

                PlayerRun();

                OnAttack();
        if(Mathf.Abs(transform.position.x - npc.position.x) <2.0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                dialogue_System.Next();
            }
        }

        if(direction.x > 0)
        {
            this.direcaoMovimento = Direction.Direita;
        }
        else if (direction. x < 0) {

            this.direcaoMovimento = Direction.Esquerda;
        }
    }
    void FixedUpdate()
        {
            rig.MovePosition(rig.position + direction * player.entity.speed * Time.fixedDeltaTime);

            switch (state)
            {
                case State.Normal:
                    float speeddesh = 10f;
                    rig.velocity = moviment * player.entity.speed;
                    if (dash)
                    {
                    rig.MovePosition(transform.position + moviment * speeddesh);
                    dash = false;
                     }
                    break;
                case State.Rolando:
                    rig.velocity = direction * rollspeed;
                    break;
            }
        }
    void PlayerRun()
        
    {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                player.entity.speed = runSpeed;
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                player.entity.speed = inicialSpeed;
            }
        }
    public void OnAttack()
    {
        if (Input.GetKeyDown(KeyCode.G) || Input.GetMouseButtonDown(0))
        {
            player.entity.speed = 0;

        }
        if (Input.GetKeyUp(KeyCode.G) || Input.GetMouseButtonUp(0))
        {
            player.entity.speed = inicialSpeed;
        }
    }
}

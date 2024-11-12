using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//requer o componente do tipo player 
[RequireComponent(typeof(player))]

public class player_controller : MonoBehaviour
{
//===VARIÁVEIS DO PLAYER CONTROLLER===//
    //varíaveis de componentes
    Dialogue_System dialogue_System;
    public player player;
    private Rigidbody2D rig;
    public Transform npc;

    //variáveis de movimentação e velocidade
    private float inicialSpeed;
    public float runSpeed;
    private Vector2 direction;
    private Vector3 moviment;
    [SerializeField]
    public Direction direcaoMovimento;

    //variáveis de posições e layers
    public LayerMask solidObjectsLayer;
    public LayerMask interactablesLayer;
    public VectorValue startingPosition;

    void Awake()
    {
        //recebendo o componente da física 
        rig = GetComponent<Rigidbody2D>();
        //buscando o objeto do Dialogue System
        dialogue_System = FindObjectOfType<Dialogue_System>();

    }

    void Start()
    {
        //recebendo o componente do player
        player = GetComponent<player>();

        //armazena que a direção inicial do movimento é a direita
        this.direcaoMovimento = Direction.Direita;
        
        //armazena a posição do transform como posicial inicial 
        transform.position = startingPosition.initialValue;

        //a velociadade inicial é a velocidade do script entity
        inicialSpeed = player.entity.speed;
       
    }

    void Update()
    {

        //armazena as direcoes horizontal e vertical
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;            
        
        //chama a função de corrida do player
        PlayerRun();

        //se o player estiver na área de colisão do npc 
        if(Mathf.Abs(transform.position.x - npc.position.x) <2.0)
        {
            //se a tecla pressionada for o return 
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //chama a função de pular o diálogo 
                dialogue_System.Next();
            }
        }

        // se a direção de x for positiva 
        if(direction.x > 0)
        {
            //o player anda para a direita 
            this.direcaoMovimento = Direction.Direita;
        }
        //se a direção de x for negativa 
        else if (direction. x < 0) {
               
            //o player anda para a esquerda
            this.direcaoMovimento = Direction.Esquerda;
        }
    }
    void FixedUpdate()
        {
            
            rig.MovePosition(rig.position + direction * player.entity.speed * Time.fixedDeltaTime);

        }
    void PlayerRun()   
    {
            //se a tecla control esquerdo for pressionado     
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                //a velocidade recebe a velocidade do player correndo
                player.entity.speed = runSpeed;
            }
            //se parar de pressionar a tecla 
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                //a velocidade do player recebe a velocidade inicial
                player.entity.speed = inicialSpeed;
            }
    }
    
}

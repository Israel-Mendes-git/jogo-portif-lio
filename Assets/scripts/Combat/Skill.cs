using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Torna a classe Skill abstrata para permitir métodos abstratos
public abstract class Skill : MonoBehaviour
{
    [Header("Base Skill")]
    public string skillName;      // Nome da habilidade
    public float animationDuration; // Duração da animação da habilidade

    public bool selfInflicted;     // Indica se a habilidade é auto-infligida

    public GameObject effectPrfb;  // Prefab do efeito da habilidade

    protected Fighter emitter;      // Lutador que emite a habilidade
    protected Fighter receiver;      // Lutador que recebe a habilidade

    protected Queue<string> messages;

    void Awake()
    {
        this.messages = new Queue<string>();
    }

    // Método para animar o efeito da habilidade
    private void Animate()
    {
        var go = Instantiate(this.effectPrfb, this.receiver.transform.position, Quaternion.identity);
        Destroy(go, this.animationDuration); // Destroi o efeito após a duração da animação
    }

    // Método para executar a habilidade
    public void Run()
    {
        if (this.selfInflicted)
        {
            this.receiver = this.emitter; // Se a habilidade é auto-infligida, o receptor é o emissor
        }

        this.Animate(); // Executa a animação da habilidade
        this.OnRun();   // Chama o método abstrato que será implementado nas subclasses
    }

    // Método para definir o emissor e o receptor da habilidade
    public void SetEmitterAndReceiver(Fighter _emitter, Fighter _receiver)
    {
        this.emitter = _emitter; // Define o emissor
        this.receiver = _receiver; // Define o receptor
    }

    public string GetNextMessage()
    {
        if (this.messages.Count != 0)
            return this.messages.Dequeue();
        else
            return null;
    }

    // Método abstrato que deve ser implementado nas subclasses
    protected abstract void OnRun();
}

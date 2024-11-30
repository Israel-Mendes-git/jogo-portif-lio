using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject2 : MonoBehaviour
{
    public GameObject interactBtn;
    public GameObject dialogue;

    void Awake()
    {
        dialogue.SetActive(false);
        interactBtn.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("funcionou");
        }
    }
}

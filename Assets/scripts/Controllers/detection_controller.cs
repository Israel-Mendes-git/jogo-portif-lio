using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection_controller : MonoBehaviour
{
    public string TagTarget = "Player";

    public List<Collider2D> detectedObjs = new List<Collider2D>();


    private void  OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == TagTarget)
        {
            detectedObjs.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagTarget)
        {
            detectedObjs.Remove(collision);
        }
    }
}

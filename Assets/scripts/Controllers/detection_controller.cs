using System.Collections.Generic;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    public GameObject Enemy; // Referência ao inimigo
    public string tagTargetDetection = "Enemy"; // A tag que você quer detectar

    public List<Collider2D> detectedObjs = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagTargetDetection))
        {
            detectedObjs.Add(collision);
            Enemy enemy = collision.GetComponent<Enemy>(); // Obtendo o componente Enemy

            if (enemy != null)
            {
                enemy.OnHit(); // Chama o método OnHit do inimigo
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tagTargetDetection))
        {
            detectedObjs.Remove(collision);
        }
    }
}

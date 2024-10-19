using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string cena;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(cena);
            Debug.Log("Loading scene: " + cena);
        }
    }

}

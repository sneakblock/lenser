using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Goal : MonoBehaviour
{
    public enum Layer
    {
        RED = 6, BLUE = 7, GREEN = 8, YELLOW = 9
    };

    private GameManager gameManager;

    public Layer layer;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == (int)layer)
        {
            Destroy(collision.gameObject);
            gameManager.IncrementScore();
        }
    }
}

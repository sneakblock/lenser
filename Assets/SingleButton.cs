using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleButton : MonoBehaviour
{

    private Ball target;

    private GameManager gameManager;

    public Direction toDirection;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        if (gameManager.selectedBall != null)
        {
            target = gameManager.selectedBall;
            target.currentDirection = toDirection;
            gameManager.SelectBall(target);
        }
        
    }

}

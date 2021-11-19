using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    GameManager gameManager;
    Text text;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = gameManager.score.ToString();
    }
}

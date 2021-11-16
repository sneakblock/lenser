using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Ball selectedBall;

    public Material[] colorMats;

    public Material selectionMat;

    public int totalBalls;

    private Buttons buttons;


    private void Start()
    {
        buttons = GameObject.Find("buttons").GetComponent<Buttons>();
        buttons.gameObject.SetActive(false);
    }

    public void SelectBall(Ball b)
    {
        if (selectedBall != b)
        {
            selectedBall = b;
            b.SetMaterial(selectionMat);
            buttons.gameObject.SetActive(true);
            buttons.target = b;
        } else
        {
            selectedBall = null;
            b.SetMaterial(b.ballMat);
            buttons.gameObject.SetActive(false);
            buttons.target = null;
        }
        
    }

    public void initBalls(int numBalls)
    {
        int numRedBalls, numBlueBalls, numGreenBalls, numYellowBalls;
        numRedBalls = numBalls / 4;
        numBlueBalls = numBalls / 4;
        numGreenBalls = numBalls / 4;
        numYellowBalls = numBalls / 4;
    }
}

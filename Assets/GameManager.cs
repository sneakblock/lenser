using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject ball;

    public GameObject[] mines = new GameObject[4];

    public GameObject[] smackers = new GameObject[4];

    public int approxHazards;

    public int hazardsRange;

    public Ball selectedBall;

    public float spawnRadius;

    public Material[] colorMats;

    public Color[] fieldColors;

    public Color[] bgColors;

    public Material selectionMat;

    public int totalBalls;

    private Buttons buttons;

    private Camera cam;

    private GameObject field;

    public int score = 0;

    public float timer = 30;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        buttons = GameObject.Find("buttons").GetComponent<Buttons>();
        buttons.gameObject.SetActive(false);
        initBalls(totalBalls);
        initMines();
        initSmackers();
        cam = Camera.main;
        field = GameObject.Find("field");
        cam.cullingMask = 1 << 0 | 1 << 6;
        field.GetComponent<MeshRenderer>().material.color = fieldColors[0];
        cam.backgroundColor = bgColors[0];
        
    }

    public void SelectBall(Ball b)
    {
        if (selectedBall != b)
        {
            if (selectedBall != null)
            {
                selectedBall.SetMaterial(selectedBall.ballMat);
            }
            
            selectedBall = b;
            b.SetMaterial(selectionMat);
            buttons.gameObject.SetActive(true);
            buttons.target = b;
            buttons.gameObject.layer = b.gameObject.layer;
            //set all children of buttons to the proper layer as well
            foreach (Transform child in buttons.gameObject.transform)
            {
                child.gameObject.layer = b.gameObject.layer;
            }
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
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < numBalls / 4; j++)
            {
                Vector3 pos = Random.insideUnitSphere * spawnRadius;
                GameObject b = GameObject.Instantiate(ball, new Vector3(pos.x, transform.position.y, pos.z), Quaternion.identity);
                b.GetComponent<Ball>().ballMat = colorMats[i];
                b.layer = i + 6;
            }
        }
        
    }

    public void initMines()
    {
        int numMines = (int)Random.Range(approxHazards - hazardsRange, approxHazards + hazardsRange);
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < numMines / 4; j++)
            {
                Vector3 pos = Random.insideUnitSphere * spawnRadius;
                GameObject mine = GameObject.Instantiate(mines[i], new Vector3(pos.x, .3f, pos.z), Quaternion.identity);
                mine.transform.localScale *= Random.Range(1, 3);
            }
        }
    }

    public void initSmackers()
    {
        int numSmackers = (int)Random.Range(approxHazards - hazardsRange, approxHazards + hazardsRange) / 2;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < numSmackers / 4; j++)
            {
                Vector3 pos = Random.insideUnitSphere * spawnRadius;
                GameObject smacker = GameObject.Instantiate(smackers[i], new Vector3(pos.x, .3f, pos.z), Quaternion.identity);
                smacker.transform.localScale += new Vector3(0, 0, Random.Range(1, 3));
                smacker.GetComponent<Smacker>().rotationAmount = Random.Range(.1f, 2);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cam.cullingMask = 1 << 0 | 1 << 6;
            field.GetComponent<MeshRenderer>().material.color = fieldColors[0];
            cam.backgroundColor = bgColors[0];
            
            
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            cam.cullingMask = 1 << 0 | 1 << 8;
            field.GetComponent<MeshRenderer>().material.color = fieldColors[1];
            cam.backgroundColor = bgColors[1];
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            cam.cullingMask = 1 << 0 | 1 << 7;
            field.GetComponent<MeshRenderer>().material.color = fieldColors[2];
            cam.backgroundColor = bgColors[2];
            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            cam.cullingMask = 1 << 0 | 1 << 9;
            field.GetComponent<MeshRenderer>().material.color = fieldColors[3];
            cam.backgroundColor = bgColors[3];
            
        }

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("ball"))
        {
            if (g.transform.position.y < -50)
            {
                Destroy(g);
                
            }
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (SceneManager.GetActiveScene().name != "Score")
            {
                SceneManager.LoadScene("Score");
            }
        }
    }

    public void IncrementScore()
    {
        score+=100;
        Debug.Log(score);
    }

    


}

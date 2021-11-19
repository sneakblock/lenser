using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

    public float moveForce;

    public Material ballMat;

    

    Rigidbody _rigidbody;

    public Direction currentDirection = Direction.REST;

    

    GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SetMaterial(ballMat);
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentDirection)
        {
            case Direction.FORWARD:
                _rigidbody.AddForce(Vector3.forward * moveForce * Time.deltaTime);
                break;

            case Direction.BACK:
                _rigidbody.AddForce(Vector3.back * moveForce * Time.deltaTime);
                break;

            case Direction.LEFT:
                _rigidbody.AddForce(Vector3.left * moveForce * Time.deltaTime);
                break;

            case Direction.RIGHT:
                _rigidbody.AddForce(Vector3.right * moveForce * Time.deltaTime);
                break;
        }
    }

    private void OnMouseDown()
    {
       
        gameManager.SelectBall(this);
        
    }

    public void SetMaterial(Material m)
    {
        GetComponent<Renderer>().material = m;
    }

    

}

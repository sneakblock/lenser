using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    public float force;

    public float radius;

    public enum Layer
    {
        RED = 6, BLUE = 7, GREEN = 8, YELLOW = 9
    };

    public Layer layer;

    public Color parentColor;

    public Color targetColor;

    Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        //Sets parent color
        parent.gameObject.GetComponent<MeshRenderer>().material.color = parentColor;
        //Desats the color a bit for the central target
        GetComponent<MeshRenderer>().material.color = targetColor;
        gameObject.layer = (int)layer;
        parent.gameObject.layer = (int)layer;

    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
        //Debug.Log("Exploding...");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smacker : MonoBehaviour
{
    public float rotationAmount;

    private void Update()
    {
        transform.Rotate(new Vector3(0, rotationAmount, 0));
    }
}

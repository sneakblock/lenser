using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public Ball target;

    private void Update()
    {
        transform.position = target.transform.position;
    }


}

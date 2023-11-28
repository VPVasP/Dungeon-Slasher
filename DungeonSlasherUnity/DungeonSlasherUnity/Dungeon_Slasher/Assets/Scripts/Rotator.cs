using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float  speed=0.5f;
    //Update is called every frame
    void Update()
    {
        //we rotate it -45 degrees on the y axis,we can rotate it in other axes as well if we wish to
        transform.Rotate(new Vector3(0, -45, 0) * Time.deltaTime*speed);
    }
}

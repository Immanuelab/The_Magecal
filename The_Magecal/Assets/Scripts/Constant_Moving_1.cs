using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant_Moving_1 : MonoBehaviour
{
    //Current Position
    Vector3 pos; 

    //Maximum value of x-coordinate
    float delta = 6.0f;

    //Movement Speed of the object
    float speed = 3.0f;




    void Start () {
        //Updating position
        pos = transform.position;

    }


    void Update () {
        //Call updated position
        Vector3 v = pos;

        //Move horizontally. Speed is defined by sine graph so it accelerates and deccelerates constantly
        v.x += delta * Mathf.Sin(Time.time * speed);

        //Update Position of v
        transform.position = v;

    }
}

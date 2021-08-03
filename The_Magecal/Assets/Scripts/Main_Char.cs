using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Char : MonoBehaviour
{
    public float movespeed = 3;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left");
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right");
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space bar");
        }
    }
}
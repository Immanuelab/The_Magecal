using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Char : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Left");
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Right");
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space bar");
        }
    }
}
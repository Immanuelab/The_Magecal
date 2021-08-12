using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Char : MonoBehaviour
{
    public float movespeed = 3;
    // Start is called before the first frame update
    Animator animator;
    public bool dynamic = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            dynamic = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left");
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
            dynamic = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right");
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
            dynamic = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space bar");
        }
        
        if (Input.GetKey(KeyCode.K))
        {
            Debug.Log("Attack");
            animator.SetTrigger("atk");
        }


        if (dynamic == false)
        {animator.SetBool("run", false);}
        else {
            animator.SetBool("run", true);
        }
    }
}
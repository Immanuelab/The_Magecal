using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Char : MonoBehaviour
{
    // speed of character is set here
    public float movespeed = 3;
    // calling animator
    Animator animator;

    Rigidbody2D rigid2d;
    // dynamic check whether character is moving or not
    // so it can play appropriate animation
    public bool dynamic = false;
    public bool input_right = false;
    public bool input_left = false;
    void Start()
    {
        // getting component of animoator to control animator in script
        rigid2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // update is called once per frame
    void Update()
    {
        // this set dynamic to false when user is not moving horizontally
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            dynamic = false;
        }
        // this moves character to left when a is pressed
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left");
            // localscale changes direction of character
            transform.localScale = new Vector3(1, 1, 1);
            // this moves a character to left
            // transform.Translate(Vector3.left * movespeed * Time.deltaTime);
            // set dynamic to true to play running animation
            dynamic = true;
            input_left = true;
        }
        // this moves character to right when d is pressed
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right");
            // used localscale to change a direction of character to opposite direction of what was this looking at
            transform.localScale = new Vector3(-1, 1, 1);
            // this moves character to right
            // transform.Translate(Vector3.right * movespeed * Time.deltaTime);
            // set dynamic to true to play running animation
            dynamic = true;
            input_right = true;
        }

        // this makes character jump when spacebar or w is pressed
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            Debug.Log("Space bar");
            animator.SetTrigger("jump");
        }
        
        // this let character attack when k is pressed
        if (Input.GetKey(KeyCode.K))
        {
            Debug.Log("Attack");
            animator.SetTrigger("atk");
        }

        // when A or D is not pressed, dynamic is false so it changes animator to idle
        if (dynamic == false) {
            animator.SetBool("run", false);
            // These two statment sets both boolean to false
            input_right = false;
            input_left = false;
        }
        // when A or D is pressed dynamic get set to true so it changes animator to running
        else {
            animator.SetBool("run", true);
        }
    }
    void FixedUpdate() {
        if(input_left) {
            input_left = false;
            rigid2d.Addforce(Vector2.left * movespeed);
        }

        if(input_right) {
            input_right = false;
            rigid2d.Addforce(Vector.right * movespeed);
        }
        if (rigid2d.velocity.x >= 2.5f) rigid2d.velocity = new Vector2(2.5f, rigid2d.velocity.y);
        if (rigid2d.velocity.x <= -2.5f) rigid2d.velocity = new Vecotr2(-2.5f, rigid2d.velocity.y);
    }
}
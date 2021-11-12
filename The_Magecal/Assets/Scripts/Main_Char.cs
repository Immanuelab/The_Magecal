using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Char : MonoBehaviour
{
    // speed of character is set here
    public float movespeed = 1.5f;
    // jumping power for main character
    public float jumppower = 180;
    // call animator parameter of jump as false
    public bool input_jump = false;
    // calling animator
    Animator animator;

    Rigidbody2D rigid2d;
    BoxCollider2D col2d;
    CapsuleCollider2D capcol2d;
    // dynamic check whether character is moving or not
    // so it can play appropriate animation
    public bool input_right = false;
    public bool input_left = false;
    public int maxHP;
    public int nowHP;
    public int attk_dmg;
    public float attk_spd;
    public bool attacked = false;
    public Image nowHPbar;
    public Text HPstats;
    
    public bool ischardead = false;

    void Start()
    {
        
        // getting component of animoator to control animator in script
        rigid2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col2d = GetComponent<BoxCollider2D>();
        capcol2d = GetComponent<CapsuleCollider2D>();

        rigid2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        maxHP = 100;
        nowHP = 100;
        attk_dmg = 10;
        
        SetAttackSpeed(0.8f);
        StartCoroutine(CheckCharDeath());
    }

    
    // update is called once per frame
    void Update()
    {
        if(ischardead) return;
        nowHPbar.fillAmount = (float)nowHP / (float)maxHP;
        string _nowHP = nowHP.ToString();
        string _maxHP = maxHP.ToString();
        HPstats.text = _nowHP + "/" + _maxHP;
        // this set dynamic to false when user is not moving horizontally
        //if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        //{
        //    dynamic = false;
        //}
        // this moves character to left when a is pressed
        if (Input.GetKey(KeyCode.A))
        {
            //capcol2d.enabled = false;
            //attacked = false;
            Debug.Log("Left");
            input_left = true;
            // localscale changes direction of character
            transform.localScale = new Vector3(-1, 1, 1);
            // this moves a character to left
            // transform.Translate(Vector3.left * movespeed * Time.deltaTime);
            // set dynamic to true to play running animation
            //dynamic = true;
            animator.SetBool("move", true);
        }
        // this moves character to right when d is pressed
        else if (Input.GetKey(KeyCode.D))
        {
            //capcol2d.enabled = false;
            //attacked = false;
            Debug.Log("Right");
            input_right = true;
            // used localscale to change a direction of character to opposite direction of what was this looking at
            transform.localScale = new Vector3(1, 1, 1);
            // this moves character to right
            // transform.Translate(Vector3.right * movespeed * Time.deltaTime);
            // set dynamic to true to play running animation
            //dynamic = true;
            animator.SetBool("move", true);
        }
        else
        {
            animator.SetBool("move", false);
        }

        // this makes character jump when spacebar or w is pressed
        if (Input.GetKeyDown(KeyCode.Space) && !animator.GetBool("jump"))
        {
            //attacked = false;
            //capcol2d.enabled = false;
            Debug.Log("Space bar");
            input_jump = true;
        }
        
        // this let character attack when k is pressed
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Attack");
            animator.SetTrigger("attack");
            attacked = true;
            capcol2d.enabled = true;
        }
        else
        {
            attacked = false;
            capcol2d.enabled = false;
        }

        // when A or D is not pressed, dynamic is false so it changes animator to idle
        //if (dynamic == false) {
        //    animator.SetBool("run", false);
            // These two statment sets both boolean to false
        //    input_right = false;
        //    input_left = false;
        //}
        // when A or D is pressed dynamic get set to true so it changes animator to running
        //else {
        //    animator.SetBool("run", true);
        //}
        RaycastHit2D raycastHit = Physics2D.BoxCast(col2d.bounds.center, col2d.bounds.size, 0f, Vector2.down, 0.02f, LayerMask.GetMask("Ground"));
        if (raycastHit.collider != null)
        {
            animator.SetBool("jump", false);
        }
        else animator.SetBool("jump", true);
        //if(input_left) {
        //    input_left = false;
        //    rigid2d.AddForce(Vector2.left * movespeed * Time.deltaTime);
        //    Debug.Log("moved left");
        //}

        //if(input_right) {
        //    input_right = false;
        //    rigid2d.AddForce(Vector2.right * movespeed * Time.deltaTime);
        //}
        //if (rigid2d.velocity.x >= 1.5f) rigid2d.velocity = new Vector2(1.5f, rigid2d.velocity.y);
        //else if (rigid2d.velocity.x <= -1.5f) rigid2d.velocity = new Vector2(-1.5f, rigid2d.velocity.y);
        
        
    } 
    void FixedUpdate()
    {
        if(input_left) {
            input_left = false;
            //rigid2d.AddForce(Vector2.left * movespeed);
            transform.Translate(Vector2.left * movespeed * Time.deltaTime);
        }

        if(input_right) {
            input_right = false;
            //rigid2d.AddForce(Vector2.right * movespeed);
            transform.Translate(Vector2.right * movespeed * Time.deltaTime);
        }
        
        //if (rigid2d.velocity.x >= 2.5f) rigid2d.velocity = new Vector2(2.5f, rigid2d.velocity.y);
        //else if (rigid2d.velocity.x <= -2.5f) rigid2d.velocity = new Vector2(-2.5f, rigid2d.velocity.y);

        if(input_jump) 
        {
            input_jump = false;
            rigid2d.AddForce(Vector2.up * jumppower);
        }
    }

    void SetAttackSpeed(float speed)
    {
        animator.SetFloat("attk_spd", speed);
        attk_spd = speed;
    }

    public void Healing(int heal_amount)
    {
        //float newHP = nowHP + heal_amount;
        int currentHP = nowHP;
        nowHP = currentHP + heal_amount;
        if(nowHP>maxHP)
        {
            nowHP = maxHP;
        }
    }

    public void SetMoveSpeed(float speed)
    {
        movespeed = speed;
    }

    public float GetMoveSpeed()
    {
        return movespeed;
    }
    
    IEnumerator CheckCharDeath()
    {
        while(true)
        {
            // Create a temporary reference to the current scene.
            Scene Current_Scene = SceneManager.GetActiveScene ();
 
            // Retrieve the name of this scene.
            string Scene_Name = Current_Scene.name;
            if(Scene_Name == "Tutorial")
            {
                if(transform.position.y < -10)
                {
                    SceneManager.LoadScene("Tutorial");
                }
                if(nowHP <= 0)
                {
                    ischardead = true;
                    animator.SetTrigger("die");
                    yield return new WaitForSeconds(0.3f);
                    SceneManager.LoadScene("Tutorial");
                }
                yield return new WaitForEndOfFrame();
            }
            if(Scene_Name == "Game_Scene")
            {
                if(transform.position.y < -10)
                {
                    SceneManager.LoadScene("Game_Scene");
                }
                if(nowHP <= 0)
                {
                    ischardead = true;
                    animator.SetTrigger("die");
                    yield return new WaitForSeconds(0.3f);
                    SceneManager.LoadScene("Game_Scene");
                }
                yield return new WaitForEndOfFrame();
            }
            if(Scene_Name == "Game_Scene_2")
            {
                if(transform.position.y < -10)
                {
                    SceneManager.LoadScene("Game_Scene_2");
                }
                if(nowHP <= 0)
                {
                    ischardead = true;
                    animator.SetTrigger("die");
                    yield return new WaitForSeconds(0.3f);
                    SceneManager.LoadScene("Game_Scene_2");
                }
                yield return new WaitForEndOfFrame();
            }
            if(Scene_Name == "Game_Scene_3")
            {
                if(transform.position.y < -10)
                {
                    SceneManager.LoadScene("Game_Scene_3");
                }
                if(nowHP <= 0)
                {
                    ischardead = true;
                    animator.SetTrigger("die");
                    yield return new WaitForSeconds(0.3f);
                    SceneManager.LoadScene("Game_Scene_3");
                }
                yield return new WaitForEndOfFrame();
            }
            
        }
    }
}

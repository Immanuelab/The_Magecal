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

    //calling various components
    Rigidbody2D rigid2d;
    BoxCollider2D col2d;
    CapsuleCollider2D capcol2d;

    //call variables to use in code
    public bool input_right = false;
    public bool input_left = false;
    public int maxHP;
    public int nowHP;
    public int attk_dmg;
    public float attk_spd;
    public bool attacked = false;
    public Image nowHPbar;
    public Text HPstats;
    
    //this is for checking whether character died or not
    public bool ischardead = false;

    void Start()
    {
        
        // getting components to control in script
        rigid2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col2d = GetComponent<BoxCollider2D>();
        capcol2d = GetComponent<CapsuleCollider2D>();

        //it freeze the rotation of character when game has started
        rigid2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        //these are the stats of character
        maxHP = 50;
        nowHP = 50;
        attk_dmg = 10;
        
        //it sets attack speed
        SetAttackSpeed(0.8f);
        //play character death check function parallel by coroutine
        StartCoroutine(CheckCharDeath());
    }

    
    void Update()
    {
        //it let user move when character dies
        //game get restarted 0.3 seconds after character dies to play death animation therefore i need to block movement whilst
        if(ischardead) return;


        //it chages hp bar value
        nowHPbar.fillAmount = (float)nowHP / (float)maxHP;
        //converting float values to string to write as text
        string _nowHP = nowHP.ToString();
        string _maxHP = maxHP.ToString();
        //it shows hp in text above the hp bar picture
        HPstats.text = _nowHP + "/" + _maxHP;
        

        // this moves character to left when a is pressed
        if (Input.GetKey(KeyCode.A))
        {
            //actual movement get handeled in fixedupdate function so it returns input of left to true
            input_left = true;
            // localscale changes direction of character
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("move", true);
        }

        // this moves character to right when d is pressed
        else if (Input.GetKey(KeyCode.D))
        {
            //actual movement get handeled in fixedupdate function so it returns input of right to true
            input_right = true;
            // used localscale to change a direction of character to opposite direction of what was this looking at
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("move", true);
        }
        //when a or d is not pressed, it stops playing moving animation
        else
        {
            animator.SetBool("move", false);
        }

        // this makes character jump when spacebar is pressed while jump animation is not playing
        if (Input.GetKeyDown(KeyCode.Space) && !animator.GetBool("jump"))
        {
            //actual jump get handeled in fixedupdate function.
            input_jump = true;
        }
        
        // this let character attack when k is pressed
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("attack");
            //check whether it has been attacked
            attacked = true;
            //it enables capsule collider on head part to attack
            capcol2d.enabled = true;
        }
        else
        {
            //it stops character to damage when k is not pressed
            attacked = false;
            capcol2d.enabled = false;
        }

        //turn whole game off when esc is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        //it checks does bottom part of character is on the ground
        RaycastHit2D raycastHit = Physics2D.BoxCast(col2d.bounds.center, col2d.bounds.size, 0f, Vector2.down, 0.02f, LayerMask.GetMask("Ground"));
        if (raycastHit.collider != null)
        {
            //it stops from jumping multiple times
            animator.SetBool("jump", false);
        }
        else animator.SetBool("jump", true);       
    } 
    void FixedUpdate()
    {
        //it moves character to left with setted speed
        if(input_left) {
            input_left = false;
            transform.Translate(Vector2.left * movespeed * Time.deltaTime);
        }

        //it moves character to right with setted speed
        if(input_right) {
            input_right = false;
            transform.Translate(Vector2.right * movespeed * Time.deltaTime);
        }
        
        //it lets character jump upwards by accelerating upwards
        if(input_jump) 
        {
            input_jump = false;
            rigid2d.AddForce(Vector2.up * jumppower);
        }
    }

    //It sets attack speed of character
    void SetAttackSpeed(float speed)
    {
        animator.SetFloat("attk_spd", speed);
        attk_spd = speed;
    }

    //it heals character when apple has been consumed
    public void Healing(int heal_amount)
    {
        int currentHP = nowHP;
        nowHP = currentHP + heal_amount;
        if(nowHP>maxHP)
        {
            nowHP = maxHP;
        }
    }

    //it sets new movement speed when charcater consume kiwi fruit
    public void SetMoveSpeed(float speed)
    {
        movespeed = speed;
    }

    //it used to change movement speed back to normal
    public float GetMoveSpeed()
    {
        return movespeed;
    }
    
    //it checks whether character died or not
    IEnumerator CheckCharDeath()
    {
        //These restarts the scene when character go under certain y-coordinate or hp drop below 0
        while(true)
        {
            // Create a temporary reference to the current scene.
            Scene Current_Scene = SceneManager.GetActiveScene ();
 
            // Retrieve the name of this scene.
            string Scene_Name = Current_Scene.name;


            
            //this is for tutorial
            if(Scene_Name == "Tutorial")
            {
                //if character drops below -10 y-coordinate it loads tutorial again
                if(transform.position.y < -10)
                {
                    SceneManager.LoadScene("Tutorial");
                }
                if(nowHP <= 0)
                {
                    //when hp is below 0, plays death animation and restart the tutorial again after 0.3 seconds
                    ischardead = true;
                    animator.SetTrigger("die");
                    yield return new WaitForSeconds(0.3f);
                    SceneManager.LoadScene("Tutorial");
                }
                //it let this played in every end of each frame
                yield return new WaitForEndOfFrame();
            }

            //From here, it's basically same but different scenes
            //this is for first level
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
                //it let this played in every end of each frame
                yield return new WaitForEndOfFrame();
            }

            //this is for second level
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
                //it let this played in every end of each frame
                yield return new WaitForEndOfFrame();
            }

            //this is for third level
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
                //it let this played in every end of each frame
                yield return new WaitForEndOfFrame();
            }

            //this is for fourth level
            if(Scene_Name == "Final_Scene")
            {
                if(transform.position.y < -10)
                {
                    SceneManager.LoadScene("Final_Scene");
                }
                if(nowHP <= 0)
                {
                    ischardead = true;
                    animator.SetTrigger("die");
                    yield return new WaitForSeconds(0.3f);
                    SceneManager.LoadScene("Final_Scene");
                }
                //it let this played in every end of each frame
                yield return new WaitForEndOfFrame();
            }
            
        }
    }
}

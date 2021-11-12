using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //it let me decide canvas and hpbar in unity editor
    public GameObject prfHPBar;
    public GameObject canvas;

    RectTransform HPbar;
    Rigidbody2D rigid2d;
    public Animator enem_animator;

    //these make a variable of stats of enemy
    public float height = 0.15f;
    public string enemy_name;
    public int maxHP;
    public int nowHP;
    public int attk_dmg;
    public float attk_spd;
    public float attk_range;
    public float fieldOfVision;
    public float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        //getting components of various components
        rigid2d = GetComponent<Rigidbody2D>();
        enem_animator = GetComponent<Animator>();
        HPbar = Instantiate(prfHPBar, canvas.transform).GetComponent<RectTransform>();
        

        //These check the name of enemy and set values for each objects
        if (name.Equals("Turtle"))
        {
            SetEnemyStatus("Turtle", 80, 3, 3, 0.2f, 0.24f, 1);
        }
        if (name.Equals("Tutorial_Turtle"))
        {
            SetEnemyStatus("Tutorial_Turtle", 10, 1, 3, 0.2f, 0.24f, 1);
        }
        if (name.Equals("Snail"))
        {
            SetEnemyStatus("Snail", 40, 8, 5, 0.5f, 0.27f, 1);
        }
        //get hp bar from the child object as an image
        nowHPbar = HPbar.transform.GetChild(0).GetComponent<Image>();
        //sets attack speed
        SetAttackSpeed(attk_spd);
    }

    void Update()
    {
        //It changes system coordinate to UI coordinate.
        Vector3 HPbar_pos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        //It locates hp bar picture to the setted location
        HPbar.position = HPbar_pos;
        //It changes picture of hp bar
        nowHPbar.fillAmount = (float)nowHP / (float)maxHP;
    }

    //It sets status for different enemies.
    private void SetEnemyStatus(string _enemy_name, int _maxHP, int _attk_dmg, float _attk_spd, float _movespeed, float _attk_range, float _fieldOfVision)
    {
	    enemy_name = _enemy_name;
	    maxHP = _maxHP;
    	nowHP = _maxHP;
	    attk_dmg = _attk_dmg;
	    attk_spd = _attk_spd;
        movespeed = _movespeed;
        attk_range = _attk_range;
        fieldOfVision = _fieldOfVision;
    }

    public Main_Char character;
    Image nowHPbar;
    //It gets played when enemy collide with something
    private void OnTriggerEnter2D(Collider2D col)
    {
        //It character attacked, it deducts the current hp of enemy.
        if (col.CompareTag("Player"))
        {
            if (character.attacked)
            {
                nowHP -= character.attk_dmg;
                character.attacked = false;
                if (nowHP <= 0)
                {
                    Die();
                }
            }
        }
    }

    //This play death animation and deactivate AI and collider and gravity. 
    //Enemy gets deleted after 0.3 seconds because animation is 0.3 seconds long
    void Die()
    {
        enem_animator.SetTrigger("die");
        GetComponent<Enemy_AI>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(rigid2d);
        Destroy(gameObject, 0.3f);
        Destroy(HPbar.gameObject, 0.3f);
    }
    
    //It sets the attack speed of enemy
    void SetAttackSpeed(float speed)
    {
        enem_animator.SetFloat("attk_spd", speed);
    }
}


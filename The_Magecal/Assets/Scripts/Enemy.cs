using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject prfHPBar;
    public GameObject canvas;

    RectTransform HPbar;
    Rigidbody2D rigid2d;
    public Animator enem_animator;

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
        rigid2d = GetComponent<Rigidbody2D>();
        enem_animator = GetComponent<Animator>();
        HPbar = Instantiate(prfHPBar, canvas.transform).GetComponent<RectTransform>();
        

        if (name.Equals("Turtle_1"))
        {
            SetEnemyStatus("Turtle_1", 80, 3, 3, 0.2f, 0.22f, 1);
        }
        nowHPbar = HPbar.transform.GetChild(0).GetComponent<Image>();
        SetAttackSpeed(attk_spd);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 HPbar_pos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        HPbar.position = HPbar_pos;
        nowHPbar.fillAmount = (float)nowHP / (float)maxHP;
    }

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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (character.attacked)
            {
                nowHP -= character.attk_dmg;
                Debug.Log(nowHP);
                character.attacked = false;
                if (nowHP <= 0)
                {
                    Die();
                }
            }
        }
    }
    void Die()
    {
        enem_animator.SetTrigger("die");
        GetComponent<Enemy_AI>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(rigid2d);
        Destroy(gameObject, 0.3f);
        Destroy(HPbar.gameObject, 0.3f);
    }
    
    void SetAttackSpeed(float speed)
    {
        enem_animator.SetFloat("attk_spd", speed);
    }
}


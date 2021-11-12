using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    //Set the target variable
    public Transform target;

    //Sets attack delay
    float attk_del;

    //Sets enemy as 'enemy'
    Enemy enemy;

    //sets animator as 'enem_animator'
    Animator enem_animator;
    void Start()
    {
        //It brings components of enemy and set the name.
        enemy = GetComponent<Enemy>();
        enem_animator = enemy.enem_animator;
    }

    void Update()
    {
        //Attack delay for enemy
        attk_del -= Time.deltaTime;
        if (attk_del < 0) attk_del = 0;

        //Check distance between target and current object
        float distance = Vector3.Distance(transform.position, target.position);

        //It plays when delay is zero and in field of vision of enemy
        if (attk_del == 0 && distance <= enemy.fieldOfVision)
        {
            //Look target
            FaceTarget();

            //Attack when target is within the range
            if (distance <= enemy.attk_range)
            {
                AttackTarget();
            }
            //Chase the target when it's not attacking
            else
            {
                //Get animator information
                if (!enem_animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
                {
                    MoveToTarget();
                }
            }
        }
        //Play Idel animation when target is out of range of field of vision of enemy.
        else
        {
            enem_animator.SetBool("move", false);
        }
    }

    //It moves enemy to target
    void MoveToTarget()
    {
        float dir = target.position.x - transform.position.x;
        dir = (dir < 0) ? -1 : 1;
        transform.Translate(new Vector2(dir, 0) * enemy.movespeed * Time.deltaTime);
        enem_animator.SetBool("move", true);
    }

    //It face the target
    void FaceTarget()
    {
        //When target is on the left side
        if (target.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //When target is on the right side
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //It let enemy attacks the target
    void AttackTarget()
    {
        //It deducts character's hp
        target.GetComponent<Main_Char>().nowHP -= enemy.attk_dmg;
        enem_animator.SetTrigger("attack");
        //Reset the delay
        attk_del = enemy.attk_spd;
    }
}

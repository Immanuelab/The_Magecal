using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public Transform target;
    float attk_del;

    Enemy enemy;
    Animator enem_animator;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        enem_animator = enemy.enem_animator;
    }

    void Update()
    {
        attk_del -= Time.deltaTime;
        if (attk_del < 0) attk_del = 0;

        float distance = Vector3.Distance(transform.position, target.position);

        if (attk_del == 0 && distance <= enemy.fieldOfVision)
        {
            FaceTarget();

            if (distance <= enemy.attk_range)
            {
                AttackTarget();
            }
            else
            {
                if (!enem_animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
                {
                    MoveToTarget();
                }
            }
        }
        else
        {
            enem_animator.SetBool("move", false);
        }
    }

    void MoveToTarget()
    {
        float dir = target.position.x - transform.position.x;
        dir = (dir < 0) ? -1 : 1;
        transform.Translate(new Vector2(dir, 0) * enemy.movespeed * Time.deltaTime);
        enem_animator.SetBool("move", true);
    }

    void FaceTarget()
    {
        if (target.position.x - transform.position.x < 0) // 타겟이 왼쪽에 있을 때
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else // 타겟이 오른쪽에 있을 때
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void AttackTarget()
    {
        target.GetComponent<Main_Char>().nowHP -= enemy.attk_dmg;
        enem_animator.SetTrigger("attack"); // 공격 애니메이션 실행
        attk_del = enemy.attk_spd; // 딜레이 충전
    }
}

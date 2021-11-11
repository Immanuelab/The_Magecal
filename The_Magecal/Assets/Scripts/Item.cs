using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string item_name;
    public int data_type;
    public float data_num;

    Animator item_animator;
    //Main_Char character;
    //Collider2D col;
        

    // Start is called before the first frame update
    void Start()
    {
        item_animator = GetComponent<Animator>();
        //col = GetComponent<Collider2D>();
        //character = col.GetComponent<Main_Char>();
        if(name.Equals("Apple"))
        {
            SetItemSpecs("Apple", 1, 20);
        }
        if(name.Equals("Kiwi"))
        {
            SetItemSpecs("Kiwi", 2, 1.5f);
        }
    }
    
    private void SetItemSpecs(string _item_name, int _data_type, float _data_num)
    {
        item_name = _item_name;
        data_type = _data_type;
        data_num = _data_num;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(data_type==1)
        {
            if(col.CompareTag("Player"))
            {
                Main_Char character = col.GetComponent<Main_Char>();
                int heal_num = (int)data_num;
                character.Healing(heal_num);
                item_animator.SetTrigger("del");
                Destroy(gameObject, 0.25f);
            }
        }
        else if(data_type==2)
        {
            if(col.CompareTag("Player"))
            {
                Main_Char character = col.GetComponent<Main_Char>();
                StartCoroutine(IncreaseMoveSpeed(character));
                //item_animator.SetTrigger("del");
                //GetComponent<SpriteRenderer>().enabled = false;
                //GetComponent<Collider2D>().enabled = false;
            }
        }
    }
    IEnumerator IncreaseMoveSpeed(Main_Char character)
    {

        float movespeed = character.GetMoveSpeed();
        character.SetMoveSpeed(movespeed * data_num);
        item_animator.SetTrigger("del");
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(9.75f);

        character.SetMoveSpeed(movespeed);
        Destroy(gameObject);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //sets variables to use to set stats
    public string item_name;
    public int data_type;
    public float data_num;

    //sets animator as 'item_animator'
    Animator item_animator;
        

    void Start()
    {
        //gets component of animator and call it 'item_animator'
        item_animator = GetComponent<Animator>();
        //These check the name of object and set values for each objects
        if(name.Equals("Apple"))
        {
            SetItemSpecs("Apple", 1, 20);
        }
        if(name.Equals("Kiwi"))
        {
            SetItemSpecs("Kiwi", 2, 1.5f);
        }
    }
    
    //This sets the specs of item
    private void SetItemSpecs(string _item_name, int _data_type, float _data_num)
    {
        item_name = _item_name;
        data_type = _data_type;
        data_num = _data_num;
    }

    //When objects collide something, it play this.
    private void OnTriggerEnter2D(Collider2D col)
    {
        //type 1 is apple.
        if(data_type==1)
        {
            //it heals character and destory the game object after animation has been played when character collide
            if(col.CompareTag("Player"))
            {
                Main_Char character = col.GetComponent<Main_Char>();
                int heal_num = (int)data_num;
                character.Healing(heal_num);
                item_animator.SetTrigger("del");
                Destroy(gameObject, 0.25f);
            }
        }

        //type 2 is kiwi fruit
        else if(data_type==2)
        {   
            //start coroutine when it collide with player
            if(col.CompareTag("Player"))
            {
                Main_Char character = col.GetComponent<Main_Char>();
                StartCoroutine(IncreaseMoveSpeed(character));
                
            }
        }
    }

    //this function increases movement speed of character by 1.5 times for 10 seconds
    IEnumerator IncreaseMoveSpeed(Main_Char character)
    {

        float movespeed = character.GetMoveSpeed();
        //this change movement speed
        character.SetMoveSpeed(movespeed * data_num);

        //it plays removing animation
        item_animator.SetTrigger("del");
        //this let it waits for 0.25 seconds
        yield return new WaitForSeconds(0.25f);
        //make it invisible by disabling sprite renderer
        GetComponent<SpriteRenderer>().enabled = false;
        //it disable collider on kiwi fruit
        GetComponent<Collider2D>().enabled = false;

        //it let effect of kiwi fruit stays 9.75 seconds more.
        //it will be 10 seconds in total. 0.25 + 9.75 = 10
        yield return new WaitForSeconds(9.75f);

        //it changes back to normal speed and remove compleytely
        character.SetMoveSpeed(movespeed);
        Destroy(gameObject);

    }
}

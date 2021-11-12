using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial_Texts : MonoBehaviour
{
    //Call text object from unity editor
    public Text tut_text;

    //Set sign name
    public string sign_name;
    
    //Set data type
    public int data_type;


    void start()
    {
        //These check the name of object and set values for each objects
        if(name.Equals("Move_Sign"))
        {
            SetSignSpecs("Move_Sign", 1);
        }
        else if(name.Equals("Jump_Sign"))
        {
            SetSignSpecs("Jump_Sign", 2);
        }
        else if(name.Equals("Attack_Sign"))
        {
            SetSignSpecs("Attack_Sign", 3);
        }
        else if(name.Equals("Item_Sign"))
        {
            SetSignSpecs("Item_Sign", 4);
        }
        else if(name.Equals("Apple_Sign"))
        {
            SetSignSpecs("Apple_Sign", 5);
        }
        else if(name.Equals("Kiwi_Sign"))
        {
            SetSignSpecs("Kiwi_Sign", 6);
        }
        else if(name.Equals("Trap_Sign"))
        {
            SetSignSpecs("Trap_Sign", 7);
        }
        else if(name.Equals("Gem_Sign"))
        {
            SetSignSpecs("Gem_Sign", 8);
        }
        else if(name.Equals("ESC_Sign"))
        {
            SetSignSpecs("ESC_Sign", 9);
        }
    }

    //This sets the values for each traps
    private void SetSignSpecs(string _sign_name, int _data_type)
    {
        sign_name = _sign_name;
        data_type = _data_type;
    }

    //When objects collide something, it play this.
    void OnTriggerEnter2D(Collider2D col) 
    {
        //it checks what sign is it first
        if(data_type==1)
        {
            //it check whether the character has collided
            if(col.CompareTag("Player"))
            {
                //it update text attached and destroy it after 3 seconds
                tut_text.text = "A & D to move left and right!";
                Destroy(gameObject, 3);
            }
        }
        if(data_type==2)
        {
            if(col.CompareTag("Player"))
            {
                tut_text.text = "Press Spacebar to jump!";
                Destroy(gameObject, 3);
            }
        }
        if(data_type==3)
        {
            if(col.CompareTag("Player"))
            {
                tut_text.text = "Press K to attack!";
                Destroy(gameObject, 3);
            }
        }
        if(data_type==4)
        {
            if(col.CompareTag("Player"))
            {
                tut_text.text = "Eating a fruits makes you stronger!";
                Destroy(gameObject, 2);
            }
        }
        if(data_type==5)
        {
            if(col.CompareTag("Player"))
            {
                tut_text.text = "Apple heals you!";
                Destroy(gameObject, 2);
            }
        }
        if(data_type==6)
        {
            if(col.CompareTag("Player"))
            {
                tut_text.text = "Kiwi Makes you faster for 10 seconds!";
                Destroy(gameObject, 2);
            }
        }
        if(data_type==7)
        {
            if(col.CompareTag("Player"))
            {
                tut_text.text = "You get damage when you touch trap!";
                Destroy(gameObject, 3);
            }
        }
        if(data_type==8)
        {
            if(col.CompareTag("Player"))
            {
                tut_text.text = "Grab a gem, it will take you to the next level!";
                Destroy(gameObject, 3);
            }
        }
        if(data_type==9)
        {
            if(col.CompareTag("Player"))
            {
                tut_text.text = "Press the esc to turn the game off.";
                Destroy(gameObject, 3);
            }
        }
    }
}

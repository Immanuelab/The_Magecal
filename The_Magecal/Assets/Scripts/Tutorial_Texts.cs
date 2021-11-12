using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial_Texts : MonoBehaviour
{
    public Text tut_text;
    public string sign_name;
    public int data_type;
    void start()
    {
        if(name.Equals("Move_Sign"))
        {
            SetSignSpecs("Move_Sign", 1);
        }
        if(name.Equals("Jump_Sign"))
        {
            SetSignSpecs("Jump_Sign", 2);
        }
        if(name.Equals("Attack_Sign"))
        {
            SetSignSpecs("Attack_Sign", 3);
        }
        if(name.Equals("Item_Sign"))
        {
            SetSignSpecs("Item_Sign", 4);
        }
        if(name.Equals("Apple_Sign"))
        {
            SetSignSpecs("Apple_Sign", 5);
        }
        if(name.Equals("Kiwi_Sign"))
        {
            SetSignSpecs("Kiwi_Sign", 6);
        }
        if(name.Equals("Trap_Sign"))
        {
            SetSignSpecs("Trap_Sign", 7);
        }
        if(name.Equals("Gem_Sign"))
        {
            SetSignSpecs("Gem_Sign", 8);
        }
    }
    private void SetSignSpecs(string _sign_name, int _data_type)
    {
        sign_name = _sign_name;
        data_type = _data_type;
    }
    void OnTriggerEnter2D(Collider2D col) 
    {
        if(data_type==1)
        {
            if(col.CompareTag("Player"))
            {
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
                Destroy(gameObject, 3);
            }
        }
        if(data_type==5)
        {
            if(col.CompareTag("Player"))
            {
                tut_text.text = "Apple heals you!";
                Destroy(gameObject, 3);
            }
        }
        if(data_type==6)
        {
            if(col.CompareTag("Player"))
            {
                tut_text.text = "Kiwi Makes you faster!";
                Destroy(gameObject, 3);
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class End_Credit : MonoBehaviour
{
    //Call text object from unity editor
    public Text end_credit_text;

    //Set sign name
    public string sign_name;

    //Set data type
    public int data_type;

    
    void Start()
    {
        //These check the name of object and set values for each objects
        if(name.Equals("Main_Developer_Sign"))
        {
            SetSignSpecs("Main_Developer_Sign", 1);
        }
        else if(name.Equals("Co_Level_Designer_Sign"))
        {
            SetSignSpecs("Co_Level_Designer_Sign", 2);
        }
        else if(name.Equals("Tester_Sign"))
        {
            SetSignSpecs("Tester_Sign", 3);
        }
        else if(name.Equals("Last_Sign"))
        {
            SetSignSpecs("Last_Sign", 4);
        }
        else if(name.Equals("Exit_Sign"))
        {
            SetSignSpecs("Exit_Sign", 5);
        }
    }

    //This sets the values
    private void SetSignSpecs(string _sign_name, int _data_type)
    {
        sign_name = _sign_name;
        data_type = _data_type;
    }

    //When objects collide something, it play this.
    void OnTriggerEnter2D(Collider2D col) 
    {
        //These check where did it collided and which object was it. Then update the text and destory the object after 7 seconds
        if(data_type==1)
        {
            if(col.CompareTag("Player"))
            {
                end_credit_text.text = "Main Developer: Immanuel (Mingeon Cho)";
                Destroy(gameObject, 7);
            }
        }
        if(data_type==2)
        {
            if(col.CompareTag("Player"))
            {
                end_credit_text.text = "Co Level Designer: Acorn (Aiden Mabey)";
                Destroy(gameObject, 7);
            }
        }
        if(data_type==3)
        {
            if(col.CompareTag("Player"))
            {
                end_credit_text.text = "Tester: Acorn (Aiden Mabey)";
                Destroy(gameObject, 7);
            }
        }
        if(data_type==4)
        {
            if(col.CompareTag("Player"))
            {
                end_credit_text.text = "The Magecal by Immanuel & Acorn";
                Destroy(gameObject, 7);
            }
        }
        if(data_type==5)
        {
            if(col.CompareTag("Player"))
            {
                Application.Quit();
            }
        }
    }
}

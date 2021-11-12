using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    //sets variables to use to set stats
    public string trap_name;
    public int data_type;
    public int data_num;

    void Start()
    {
        //These check the name of traps and set values for each objects
        if(name.Equals("Saw_Trap"))
        {
            SetTrapSpecs("Saw_Trap", 1, 10);
        }
        if(name.Equals("Spike_Trap"))
        {
            SetTrapSpecs("Spike_Trap", 1, 5);
        }
        if(name.Equals("Fire_Trap"))
        {
            SetTrapSpecs("Fire_Trap", 1, 8);
        }
    }


    //This sets the specs of traps
    private void SetTrapSpecs(string _trap_name, int _data_type, int _data_num)
    {
        trap_name = _trap_name;
        data_type = _data_type;
        data_num = _data_num;
    }

    //When objects collide something, it play this.
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(data_type==1)
        {
            //if trap collide with character, it deducts hp of character.
            if (col.CompareTag("Player"))
            {
                Main_Char character = col.GetComponent<Main_Char>();
                character.nowHP -= data_num;
                if (character.nowHP < 0) character.nowHP = 0;
            }
        }
    }
}

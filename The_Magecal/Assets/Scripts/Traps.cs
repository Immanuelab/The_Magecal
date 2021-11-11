using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public string trap_name;
    public int data_type;
    public float data_num;
    // Start is called before the first frame update
    void Start()
    {
        if(name.Equals("Saw_Trap"))
        {
            SetTrapSpecs("Saw_Trap", 1, 10);
        }
    }

    private void SetTrapSpecs(string _trap_name, int _data_type, float _data_num)
    {
        trap_name = _trap_name;
        data_type = _data_type;
        data_num = _data_num;
    }
    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(data_type==1)
        {
            if (col.CompareTag("Player"))
            {
                Main_Char character = col.GetComponent<Main_Char>();
                character.nowHP -= 10;
                if (character.nowHP < 0) character.nowHP = 0;
            }
        }
    }
}

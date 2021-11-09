using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string item_name;
    public int data_type;
    public float data_num;

    Animator item_animator;

    // Start is called before the first frame update
    void Start()
    {
        item_animator = GetComponent<Animator>();
        if(name.Equals("Apple_1"))
        {
        SetItemSpecs("Apple_1", 1, 20);
        }
    }
    
    private void SetItemSpecs(string _item_name, int _data_type, float _data_num)
    {
        item_name = _item_name;
        data_type = _data_type;
        data_num = _data_num;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}

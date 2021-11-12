using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Transition : MonoBehaviour
{
    //sets variables to use to set stats
    public string gem_name;
    public int data_type;



    void Start()
    {
        //These check the name of gems and set values for each objects
        if(name.Equals("Red_Gem"))
        {
            SetGemSpecs("Red_Gem", 1);
        }
        if(name.Equals("Green_Gem"))
        {
            SetGemSpecs("Green_Gem", 2);
        }
        if(name.Equals("Blue_Gem"))
        {
            SetGemSpecs("Blue_Gem", 3);
        }
        if(name.Equals("Final_Flag"))
        {
            SetGemSpecs("Final_Flag", 4);
        }
        
    }

    //This sets the values
    private void SetGemSpecs(string _gem_name, int _data_type)
    {
        gem_name = _gem_name;
        data_type = _data_type;
    }

    //This get played when gem collide something
    private void OnTriggerEnter2D(Collider2D col)
    {
        //goes to first level
        if(data_type==1)
        {
            SceneManager.LoadScene("Game_Scene");
        }
        //goes to second level
        if(data_type==2)
        {
            SceneManager.LoadScene("Game_Scene_2");
        }
        //goes to third level
        if(data_type==3)
        {
            SceneManager.LoadScene("Game_Scene_3");
        }
        //goes to final level
        if(data_type==4)
        {
            SceneManager.LoadScene("Final_Scene");
        }
    }
}

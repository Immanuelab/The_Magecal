using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Transition : MonoBehaviour
{
    public string gem_name;
    public int data_type;
    // Start is called before the first frame update
    void Start()
    {
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
        
    }
    private void SetGemSpecs(string _gem_name, int _data_type)
    {
        gem_name = _gem_name;
        data_type = _data_type;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(data_type==1)
        {
            SceneManager.LoadScene("Game_Scene");
        }
        if(data_type==2)
        {
            SceneManager.LoadScene("Game_Scene_2");
        }
        if(data_type==3)
        {
            SceneManager.LoadScene("Game_Scene_3");
        }
    }
}

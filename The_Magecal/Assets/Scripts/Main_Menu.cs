using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    public void LoadingGameScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadingOptionScene()
    {
        SceneManager.LoadScene("Option_Menu");
    }
    public void LoadingMainScene()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}

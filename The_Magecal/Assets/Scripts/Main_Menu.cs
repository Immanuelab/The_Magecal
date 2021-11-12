using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    //it turns game off when quit button is pressed
    public void QuitButton()
    {
        Application.Quit();
    }

    //it loads tutorial
    public void LoadingGameScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    //it loads option menu
    public void LoadingOptionScene()
    {
        SceneManager.LoadScene("Option_Menu");
    }

    //it loads main menu
    public void LoadingMainScene()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    //it loads first level
    public void LoadingGameScene_1()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    //it loads second level
    public void LoadingGameScene_2()
    {
        SceneManager.LoadScene("Game_Scene_2");
    }

    //it loads third level
    public void LoadingGameScene_3()
    {
        SceneManager.LoadScene("Game_Scene_3");
    }

    //it loads fourth level
    public void LoadingFinalScene()
    {
        SceneManager.LoadScene("Final_Scene");
    }
}

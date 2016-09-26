using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Canvas CanvasMenu;

    public void LoadScene1()
    {

        SceneManager.LoadScene("MiniGame");
    
    }

    public void LoadScene2()
    {

        SceneManager.LoadScene ("Second Game");

    }
    public void LoadScene0()
    {

        SceneManager.LoadScene("Title Menu");

    }
}

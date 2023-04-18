using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonFunctions : MonoBehaviour
{
    public void LoadScene(int numberScene) 
    { 
        SceneManager.LoadScene(numberScene);
        Time.timeScale = 1.0f;
    }

    public void ExitGame() 
    { 
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

    public void DisableObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void ActivateObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    
    public void PauseGame(float time)
    {
        Time.timeScale = time;
    }
}

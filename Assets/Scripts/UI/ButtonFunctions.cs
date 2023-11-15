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
        //gameObject.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete();
        gameObject.SetActive(false);
    }

    public void ActivateObject(GameObject gameObject)
    {

        gameObject.SetActive(true);        
        gameObject.transform.localPosition = new Vector2(0,-Screen.height);
        gameObject.LeanMoveLocalY(0, 0.5f).setEaseOutExpo();
    }

    public void ActivatePause(GameObject gameObject)
    {
        gameObject.SetActive(true);
        gameObject.transform.localPosition = new Vector2(0, -Screen.height);
        gameObject.LeanMoveLocalY(0, 0.1f).setEaseOutExpo().setOnComplete(PauseGame);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}

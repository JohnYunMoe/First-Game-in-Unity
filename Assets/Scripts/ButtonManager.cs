using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    bool gameIsPaused;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void PauseGame()
    {
        if (gameIsPaused == false)
        {
            Time.timeScale = 0;
            gameIsPaused = true; 
        }
        else
        {
            Time.timeScale = 1;
            gameIsPaused = false;
        }
    }
   
}

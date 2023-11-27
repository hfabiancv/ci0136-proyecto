using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private bool keyPress = false;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !keyPress)
        {
            keyPress = true;
            Pause();
        } else if (Input.GetKeyDown(KeyCode.Escape) && keyPress)
        {
            keyPress = false;
            Resume();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Load()
    {
        
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

}

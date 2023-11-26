using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public int gameStartScene;

    // Update is called once per frame
    public void SelectScene()
    {
        Debug.Log("Scene changed!");
        SceneManager.LoadScene(gameStartScene);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
}

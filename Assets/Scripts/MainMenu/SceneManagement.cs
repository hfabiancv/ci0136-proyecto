using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public int gameStartScene;

    [SerializeField] GameObject MainMenu;

    // Update is called once per frame
    public void SelectScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Scene changed!");
        MainMenu.SetActive(false);
        SceneManager.UnloadSceneAsync(sceneIndex);
        SceneManager.LoadScene(gameStartScene);
        if (gameStartScene != 1)
        {
            Cursor.visible = true;
        } else {
            Cursor.visible = false;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
}

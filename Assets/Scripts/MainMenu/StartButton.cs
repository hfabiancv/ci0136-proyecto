using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public int gameStartScene;

    // Update is called once per frame
    public void StartGame()
    {
        Debug.Log("Game Start!");
        SceneManager.LoadScene(gameStartScene);
    }
}

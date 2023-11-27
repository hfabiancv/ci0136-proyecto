using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] private ColliderTrigger colliderTrigger;

    private void Awake()
    {
        colliderTrigger.OnPlayerEnterTrigger += LevelChange;
    }

    private void LevelChange(object sender, EventArgs e)
    {
        Debug.Log("Level Finished!");
        SceneManager.LoadScene(3);
        Cursor.visible = true;
    }
}

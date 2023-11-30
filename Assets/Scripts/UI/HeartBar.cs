using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] Player player;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    public int numOfHearts;

    
    void Start()
    {
        for (int i = 1; i <= player.maxHealth; i++)
        {
            numOfHearts++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int heartsToShow = Mathf.CeilToInt((float)player.health);

        // Disable all hearts
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = true;
            hearts[i].sprite = emptyHearts;
        }

        // Enable the required number of hearts
        for (int i = 0; i < Mathf.Min(heartsToShow, hearts.Length); i++)
        {
            hearts[i].enabled = true;
            hearts[i].sprite = fullHearts;
        }
    }
}

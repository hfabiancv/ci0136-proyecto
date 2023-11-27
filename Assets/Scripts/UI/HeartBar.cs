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
        int counter = 1;
        for (int i = 1; i <= player.maxHealth; i++)
        {
            if (counter == 20)
            {
                counter = 1;
                numOfHearts++;
            }
            counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int heartsToShow = Mathf.CeilToInt((float)player.health / 20);

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

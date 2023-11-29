using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public int increaseHealth = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Heart Spawned!");
            GameObject player = collision.gameObject;
            Player playerScript = player.GetComponent<Player>();

            if (playerScript && playerScript.health < playerScript.maxHealth)
            {
                if ((playerScript.maxHealth - playerScript.health) < increaseHealth)
                {
                    playerScript.health = playerScript.maxHealth;
                }
                else
                {
                    playerScript.health += increaseHealth;
                }
            }
            Debug.Log("Player Healed!");
            Destroy(gameObject);
        }
    }
}

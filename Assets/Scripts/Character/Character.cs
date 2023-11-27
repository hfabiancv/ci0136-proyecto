using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public int damage = 10;
    public string id = "";

    public event EventHandler OnCharacterDied;

    protected virtual void ReceiveDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log("Character died.");
        signalDeath();
        Destroy(gameObject);
        Debug.Log("Death registered, changing scene!");
        Cursor.visible = true;
        SceneManager.LoadScene(2);
    }

    protected void signalDeath()
    {
        OnCharacterDied?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Character")
        {
            Character character = coll.gameObject.GetComponent<Character>();
            if (character != null)
            {
                character.ReceiveDamage(damage);
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Character")
        {
            Character character = coll.gameObject.GetComponent<Character>();
            if (character != null)
            {
                character.ReceiveDamage(damage);
            }
        }
    }

    public virtual void Test()
    {
        Debug.Log("Test");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    public string id = "";

    public void ReceiveDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Character died.");
        Destroy(gameObject);
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
}

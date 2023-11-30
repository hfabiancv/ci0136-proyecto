using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using static UnityEditor.Progress;

public class CrateStats : MonoBehaviour
{
    private int randomNumber;
    [SerializeField] public GameObject item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Crate hit!");
            Destroy(gameObject);
            randomNumber = Random.Range(0, 5);
            Debug.Log("RandomNumber is: " + randomNumber);
            if (randomNumber == 0)
            {
                Instantiate(item, transform.position, item.transform.rotation);
            }
        }
    }
}

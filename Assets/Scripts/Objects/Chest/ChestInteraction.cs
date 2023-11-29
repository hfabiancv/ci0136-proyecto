using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public GameObject item;
    private bool triggerStatus = false;
    private int randomNumber;

    private bool stop = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Entered chest area!");
            triggerStatus = true;
        }
    }

    private void Update()
    {
        if (triggerStatus && Input.GetKey(KeyCode.E) && !stop)
        {
            Debug.Log("Opening Chest!");
            animator.SetBool("Open", true);
            stop = true;
            Debug.Log("Chest Opened!");
            randomNumber = Random.Range(0, 5);
            Debug.Log("RandomNumber is: " + randomNumber);
            if (randomNumber == 0)
            {
                Instantiate(item, transform.position, item.transform.rotation);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Left chest area!");
            triggerStatus = false;
        }
    }
}

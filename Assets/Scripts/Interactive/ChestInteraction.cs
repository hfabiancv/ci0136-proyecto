using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public Animator animator;
    private bool triggerStatus = false;
    private bool Open = false;
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
            Open = true;
            stop = true;
            Debug.Log("Chest Opened!");
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

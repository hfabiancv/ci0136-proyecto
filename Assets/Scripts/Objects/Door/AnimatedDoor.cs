using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedDoor : MonoBehaviour
{
    public GameObject[] doorSides;

    new private Collider2D collider2D;
//
    // Start is called before the first frame update
    private void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        collider2D.enabled = false;
    }

    public void Open()
    {
        // disable collider 2d
        collider2D.enabled = false;
        Debug.Log("Door Open");
        // set animator for door sides
        foreach (GameObject doorSide in doorSides)
        {
             Debug.Log("Door side opened");
            doorSide.GetComponent<Animator>().SetTrigger("Open");
        }
    }

    public void Close()
    {
        // enable collider 2d
        collider2D.enabled = true;
        foreach (GameObject doorSide in doorSides)
        {
            Debug.Log("Door side closed");
            doorSide.GetComponent<Animator>().SetTrigger("Close");
        }
    }
}

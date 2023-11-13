using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    public GameObject pivot;
    private PivotRotation rotationScript;

    void Start()
    {
        // Reference to the pivot rotation script
        rotationScript = pivot.GetComponent<PivotRotation>();
    }

    void FixedUpdate()
    {
        // Flip player
        if (rotationScript.rotationAngle < -90 || rotationScript.rotationAngle > 90)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}

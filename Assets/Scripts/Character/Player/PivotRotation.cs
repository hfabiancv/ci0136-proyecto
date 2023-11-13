using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotRotation : MonoBehaviour
{
    public GameObject player;
    public float rotationAngle;

    // player crosshair
    public GameObject crosshair;

    public void Start()
    {
        Cursor.visible = false;
    }


    private void FixedUpdate()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // make the crosshair follow the mouse
        crosshair.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - transform.position;
        difference.Normalize();

        rotationAngle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);

        if (rotationAngle < -90 || rotationAngle > 90)
        {
            if(player.transform.eulerAngles.y <= 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationAngle);

            } else if (player.transform.eulerAngles.y >= 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationAngle);
            }

        }

        // make the crosshair follow the mouse


    }
}

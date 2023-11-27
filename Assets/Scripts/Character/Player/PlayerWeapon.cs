using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerWeapon : MonoBehaviour
{
    public Weapon currentWeapon;

    void Update()
    {
        // Check if the player is firing
        CheckFiring();
    }

    private void CheckFiring()
    {
        // Check if the player is firing
        if (Input.GetMouseButtonDown(0))
        {
            // Call the Shoot method of the current weapon
            currentWeapon.Shoot();
        }
    }
}


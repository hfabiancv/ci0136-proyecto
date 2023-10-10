using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerWeapon : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public new Camera camera;

    // Reference to the player's transform
    public Transform playerTransform;
    // Reference to the weapon's transform
    public Transform spawner;
    // Reference to the bullet prefab
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the angle to point the weapon towards the mouse cursor
        float angle = pointWeaponToMouse();

        // Flip the player horizontally when aiming left or right
        spriteRenderer.flipY = angle > 90 || angle < -90;

        // Check if the player is firing
        checkFiring();
    }

    // Points the player weapon towards the mouse cursor
    private float pointWeaponToMouse()
    {
        // Get the position of the mouse cursor in the game world
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the weapon to the mouse cursor
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle in radians instead of degrees
        float angleRadians = Mathf.Atan2(direction.y, direction.x);

        // Convert the angle to degrees
        float angleDegrees = angleRadians * Mathf.Rad2Deg;

        // Set the Z rotation of the weapon to zero to prevent accumulation
        RotateWeapon(angleDegrees, 0);

        // Scale the weapon horizontally according to the player's scale
        Vector3 characterScale = playerTransform.localScale;
        transform.localScale = new Vector3(characterScale.x, 1, 1);

        // Return the angle in degrees to be used in flipping the player horizontally
        return angleDegrees;
    }

    // Flips the player horizontally based on the angle
    private bool FlipPlayerHorizontally(float angle)
    {
        return angle > 90 || angle < -90;
    }

    // Rotates the weapon sprite based on the angle and offset
    private void RotateWeapon(float angle, float offset)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle + offset);
    }

    // Spawns a bullet at the weapon's spawner if the player is firing
    private void checkFiring()
    {
        // Check if the player is firing
        if (Input.GetMouseButtonDown(0))
        {
            // Spawn a bullet at the spawner
            GameObject bullet = Instantiate(bulletPrefab, spawner.position, transform.rotation);;
            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2f);
        }
    }


}


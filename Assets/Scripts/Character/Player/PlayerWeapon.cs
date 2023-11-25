using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerWeapon : MonoBehaviour
{
    // Reference to the weapon's spawner
    public Transform spawner;
    // Reference to the bullet prefab
    public GameObject bulletPrefab;
    // Reference to the animator component
    public Animator animator;

    [SerializeField] private AudioClip shootSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is firing
        checkFiring();
    }

    // Spawns a bullet at the weapon's spawner if the player is firing
    private void checkFiring()
    {
        // Check if the player is firing
        if (Input.GetMouseButtonDown(0))
        {
            // Spawn a bullet at the spawner
            GameObject bullet = Instantiate(bulletPrefab, spawner.position, transform.rotation);
            // Start shooting animation
            animator.SetTrigger("Shoot");
            SoundController.instance.ExecuteSound(shootSound);
            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2f);
        }
    }


}


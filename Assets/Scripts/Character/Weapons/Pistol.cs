using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public int damage = 10;
    public float bulletSpeed = 10f;
    public float timeBetweenShots = 0.2f;  

    private float lastShotTime = 0f;

    public override void Shoot()
    {
        if (Time.time - lastShotTime >= timeBetweenShots)
        {
            GameObject bullet = Instantiate(bulletPrefab, spawner.position, transform.rotation);
            bullet.GetComponent<Bullet>().SetDamage(damage);
            bullet.GetComponent<Bullet>().SetSpeed(bulletSpeed);
            // Start shooting animation
            animator.SetTrigger("Shoot");
            SoundController.instance.ExecuteSound(shootSound);

            // Updates the last shot time
            lastShotTime = Time.time;
        }
    }
}

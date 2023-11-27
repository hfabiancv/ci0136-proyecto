using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform spawner;
    public GameObject bulletPrefab;
    public Animator animator;
    public AudioClip shootSound;

    public virtual void Shoot()
    {
        // Implementación base para el disparo
    }
}

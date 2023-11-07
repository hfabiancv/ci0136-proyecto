using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    // create array of collisions
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        // get box collider
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        // get all collisions
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            // if collision is not null
            if (hits[i] == null)
                continue;
            // Debug.Log(hits[i].name);

            // if collision is not a collidable
            if (hits[i].gameObject == gameObject)
                continue;

            // // if collision is a collidable
            // OnCollide(hits[i]);

            // reset collision
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        // Debug.Log(coll.name);
    }
}

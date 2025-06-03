using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float pushForce = 10f;
    public Vector2 direction = Vector2.up;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDirection = transform.up.normalized;
                rb.AddForce(forceDirection * pushForce);
            }
        }
    }
}

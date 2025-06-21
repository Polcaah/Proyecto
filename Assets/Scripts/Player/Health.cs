using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Transform currentCheckpoint;
    [SerializeField] private float startingHealth;
    private float currentHealth;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth > 0)
        {

        }
        else
        {
            if (!dead)
            {
                GetComponent<PlayerController>().enabled = false;
                dead = true;

                Invoke("Respawn", 0.3f);
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        dead = false;
        GetComponent<PlayerController>().enabled = true;
        if (GameManager.instance != null)
            GameManager.instance.AddScore(-20);
        AddHealth(startingHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}

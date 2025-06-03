using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Health : MonoBehaviour
{
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
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;

                Invoke("RespawnPlayer", 0.3f);
            }
        }
    }

    private void RespawnPlayer()
    {
        GetComponent<PlayerRespawn>().Respawn();
        GetComponent<PlayerMovement>().enabled = true;
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
    }
}

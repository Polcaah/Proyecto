using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private float Speed;

    private void Update()
    {
        transform.Translate(Time.deltaTime * Speed * Vector2.right);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(Damage);
            Destroy(gameObject);
        }
        if(collision.tag == "Wall") { Destroy(gameObject); }
    }
}

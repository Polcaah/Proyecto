using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform shootController;
    public float lineDistance;
    public LayerMask playerLayer;
    public bool playerInRange;
    public GameObject enemyBullet;
    public float timeBetween;
    public float timeLastShot;
    public float timeWaitShot;

    private void Update()
    {
        playerInRange = Physics2D.Raycast(shootController.position, transform.right, lineDistance, playerLayer);
        if (playerInRange)
        {
            if(Time.time > timeBetween + timeLastShot)
            {
                timeLastShot = Time.time;
                Invoke(nameof(Shoot), timeWaitShot);
            }
        }
    }

    private void Shoot()
    {
        Instantiate(enemyBullet, shootController.position, shootController.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(shootController.position, shootController.position + transform.right * lineDistance);
    }
}

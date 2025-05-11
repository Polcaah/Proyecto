using System.Collections;
using UnityEngine;

public class CheckpointReach : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Animator>().enabled = true;
        }
    }
}

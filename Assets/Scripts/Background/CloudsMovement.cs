using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovement : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.1f;
    private Vector2 startPos;
    private float newPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        newPos = Mathf.Repeat(Time.time * scrollSpeed, 4);
        transform.position = startPos + Vector2.left * newPos;
    }
}

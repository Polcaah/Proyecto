using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] controllers;

    private int i;
    void Start()
    {
        transform.position = controllers[startingPoint].position;
    }
    void Update()
    {
        if(Vector2.Distance(transform.position, controllers[i].position) < 0.02f)
        {
            i++;
            if(i == controllers.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, controllers[i].position, speed * Time.deltaTime);
    }
}

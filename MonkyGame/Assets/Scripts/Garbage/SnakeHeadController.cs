using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadController : MonoBehaviour
{
    //states
    public bool idle;
    public bool extending;
    public bool retracting;
    public bool attached;
    public GameObject Player;

    public float speed = 50f;

    private Vector3 target;

    void Start()
    {
        idle = true;
        extending = false;
        retracting = false;
        attached = false;

        transform.position = Player.transform.position;
        target = transform.position;
    }

    void FixedUpdate()
    {
        if (idle)
        {
            transform.position = Player.transform.position;
        }
    }

    void Extend()
    {
        idle = false;
        retracting = false;
        extending = true;
        attached = false;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void Retract()
    {
        retracting = true;
        extending = false;
        idle = false;
        attached = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        attached = true;
    }
}

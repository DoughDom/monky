using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public enum State
    {
        Attached,
        Extending,
        Retracting,
        Idle
    }
    public State state = State.Attached;

    public GameObject Player;
    public float speed = 40f;
    private Vector3 target;
    public bool attached;
    public bool extending;
    public bool retracting;
    public bool idle;

    // Start is called before the first frame update
    void Start()
    {
        target = Player.transform.position;
        extending = false;
        retracting = false;
        attached = false;
        idle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            extending = true;
            retracting = false;
            idle = false;
        }

        else if((Input.GetMouseButtonUp(0)) || (!attached && transform.position == target))
        {
            target = Player.transform.position;
            attached = false;
            extending = false;
            retracting = true;
            idle = false;
        }
        
        if(retracting)
        {
            target = Player.transform.position;
            if (transform.position == Player.transform.position)
            {
                idle = true;
                retracting = false;
            }
        }

        if(!idle)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Player.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(extending || attached)
        {
            attached = true;
            retracting = false;
            extending = false;
            idle = false;
            target = transform.position;
        }
    }
}

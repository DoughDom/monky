using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTravel : MonoBehaviour
{
    public float speed = 50f;
    public bool isExtended;
    public bool isAttached;
    public Collider2D PlayerCollider;
    //public DistanceJoint2D distanceJoint;
    public LineRenderer lineRenderer;
    private Vector3 target;
    //private Rigidbody2D rb;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        //distanceJoint.enabled = false;
        isAttached = false;
        isExtended = false;
        transform.position = Player.transform.position;
        target = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttached)
        {
            if (transform.position == Player.transform.position)
            {
                isExtended = false;
                lineRenderer.enabled = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isExtended = true;
                lineRenderer.enabled = true;
            }

            else if (Input.GetMouseButtonUp(0))
            {
                target = Player.transform.position;
            }
            target.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        if (isAttached)
        {
            if(Input.GetMouseButtonUp(0))
            {
                isAttached = false;
            }
        }
        
        lineRenderer.SetPosition(0, target);
        lineRenderer.SetPosition(1, transform.position);
        transform.LookAt(Player.transform);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != PlayerCollider)
        {
            isAttached = true;
        }
    }
}

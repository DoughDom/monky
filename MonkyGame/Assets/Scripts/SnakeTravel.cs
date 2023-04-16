using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTravel : MonoBehaviour
{
    public float speed;
    public bool isExtended;
    public bool isAttached;
    public float rotationOffset;
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
            if(!Input.GetMouseButton(0))
            {
                isAttached = false;
            }
        }
        
        lineRenderer.SetPosition(0, Player.transform.position);
        Vector3 pos = transform.position;
        pos.z = -0.3f;
        lineRenderer.SetPosition(1, pos);


        Vector3 vectorToTarget = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationOffset;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.GetMouseButton(0))
        {
            isAttached = true;
        }
    }
}
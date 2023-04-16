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
    private int velocity;
    
    //public DistanceJoint2D distanceJoint;
    public LineRenderer lineRenderer;
    private Vector3 target;
    //private Rigidbody2D rb;
    private GameObject Player;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        //distanceJoint.enabled = false;\
        rb2d = GetComponent<Rigidbody2D>();
        isAttached = false;
        isExtended = false;
        transform.position = Player.transform.position;
        target = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorToTarget = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationOffset;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

        if (Input.GetMouseButton(0))
        {
            velocity += 10;
        }
        else if (!Input.GetMouseButton(0))
        {
            rb2d.AddForce((Vector2)vectorToTarget, ForceMode2D.Impulse);
        }
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

            else if (!Input.GetMouseButton(0))
            {
                target = Player.transform.position;
            }
            target.z = transform.position.z;
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
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);



    }


}
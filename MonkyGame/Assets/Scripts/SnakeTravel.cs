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
    public Rigidbody2D rb;    
    public SpringJoint2D springJoint;
    public LineRenderer lineRenderer;
    private Vector3 target;
    //private Rigidbody2D rb;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        //distanceJoint.enabled = false;
        springJoint.enabled = false;
        isExtended = false;
        transform.position = Player.transform.position;
        target = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SetGrapplePoint();
        }
        else if(Input.GetMouseButton(0))
        {
            if(transform.position == target)
            {
                isAttached = true;
                SetRope();
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isAttached = false;
            target = Player.transform.position;
            springJoint.enabled = false;
            rb.gravityScale = 1;
        }
        lineRenderer.SetPosition(0, Player.transform.position);
        Vector3 pos = transform.position;
        pos.z = -0.3f;
        lineRenderer.SetPosition(1, pos);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);


        Vector3 vectorToTarget = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationOffset;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }
    
    void SetGrapplePoint()
    {
        Vector2 distanceVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RaycastHit2D _hit = Physics2D.Raycast(transform.position, distanceVector.normalized);
        isExtended = true;
        if (Vector2.Distance(_hit.point, transform.position) <= 100)
        {
            target = _hit.point;
            isExtended = true;
        }
    }
    void SetRope()
    {
        springJoint.autoConfigureDistance = true;
        springJoint.frequency = 0;

        springJoint.connectedAnchor = target;
        springJoint.enabled = true;
    }
}



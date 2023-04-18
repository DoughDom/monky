using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    public DistanceJoint2D distanceJoint2D;
    public SnakeController snake;

    // Start is called before the first frame update
    void Start()
    {
        distanceJoint2D.enabled = false;
        distanceJoint2D.maxDistanceOnly = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (snake.currentState == snake.attached)
        {
            Vector2 snakePos = (Vector2)snake.transform.position;
            distanceJoint2D.connectedAnchor = snakePos;
            distanceJoint2D.enabled = true;
            distanceJoint2D.distance = snake.originalDistance;
        }
        else
        {
            distanceJoint2D.enabled = false;
        }
    }
}

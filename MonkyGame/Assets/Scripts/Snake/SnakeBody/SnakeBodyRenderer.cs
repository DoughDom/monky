using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyRenderer : MonoBehaviour
{
    public PlayerController player;
    public SnakeController snake;

    private LineRenderer lineRenderer;
    private DistanceJoint2D distanceJoint2D;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 snakePos = snake.transform.position;

        playerPos.z = transform.position.z;
        snakePos.z = transform.position.z;

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, snakePos);
        lineRenderer.SetPosition(1, playerPos);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private SnakeController snake;

    private float horizontalInput;
    private float speed;

    void Awake()
    {
        speed = 4f;
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }
    
    void FixedUpdate()
    {
        if(snake.currentState == snake.attached)
        {
            player.Swing(horizontalInput, speed, snake.transform.position);
        }
    }
}

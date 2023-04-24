using UnityEngine;

public class SnakeRetractingState : SnakeState
{
    private Vector3 target;
    private bool extendBuffer;

    public override void EnterState(SnakeController snake)
    {
        snake.speed = 40f;
        snake.state = SnakeController.State.Retracting;
        target = snake.Player.transform.position;
        snake.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        extendBuffer = false;
        if (snake.GetComponent<Collider2D>().IsTouchingLayers(128))
        {
            snake.SwitchState(snake.idle);
        }
    }

    public override void UpdateState(SnakeController snake)
    {
        snake.RotateTowards(snake.Player.transform.position, 0);
        if(Input.GetMouseButtonDown(0))
        {
            extendBuffer = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            extendBuffer = false;
        }
    }

    public override void FixedUpdateState(SnakeController snake)
    {
        if(snake.transform.position == snake.Player.transform.position)
        {
            snake.SwitchState(snake.idle);
        }
        else
        {
            target = snake.Player.transform.position;
            snake.transform.position = Vector3.MoveTowards(snake.transform.position, target, snake.speed * Time.deltaTime);
            
        }
    }

    public override void OnTriggerEnter2D(SnakeController snake, Collider2D other)
    {
        if(other.gameObject == snake.Player)
        {
            if(extendBuffer)
            {
                snake.SwitchState(snake.extending);
            }
            else
            {
                snake.SwitchState(snake.idle);
            }
            
        }
    }

    public override void ExitState(SnakeController snake)
    {
        return;
    }
}

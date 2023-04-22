using UnityEngine;

public class SnakeAttachedState : SnakeState
{
    Vector3 originalPosition;
    public override void EnterState(SnakeController snake)
    {
        snake.originalDistance = Vector3.Distance(snake.transform.position, snake.Player.transform.position);
        snake.state = SnakeController.State.Attached;
        originalPosition = snake.transform.position;
    }

    public override void UpdateState(SnakeController snake)
    {
        snake.RotateTowards(snake.Player, 0);
    }

    public override void FixedUpdateState(SnakeController snake)
    {
        if(!Input.GetMouseButton(0))
        {
            snake.SwitchState(snake.retracting);
        }
        else
        {
            snake.transform.position = originalPosition;
        }
        snake.originalDistance = Mathf.Min(snake.originalDistance, snake.length);
        
        if(snake.length < 0.7f)
        {
            snake.SwitchState(snake.retracting);
        }

        if(Input.GetMouseButton(1))
        {
            snake.originalDistance -= 0.08f;
        }
        else
        {
            snake.originalDistance -= 0.01f;
        }
    }

    public override void OnTriggerEnter2D(SnakeController snake, Collider2D other)
    {
        return;
    }

    public override void ExitState(SnakeController snake)
    {
        return;
    }
}

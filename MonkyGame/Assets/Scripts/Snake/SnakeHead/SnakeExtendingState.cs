using UnityEngine;

public class SnakeExtendingState : SnakeState
{
    private Vector2 target;
    
    public override void EnterState(SnakeController snake)
    {
        snake.state = SnakeController.State.Extending;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    public override void UpdateState(SnakeController snake)
    {
        snake.RotateTowards(snake.Player, 0);
        snake.transform.position = Vector2.MoveTowards(snake.transform.position, target, snake.speed * Time.deltaTime);
    }

    public override void FixedUpdateState(SnakeController snake)
    {
        if((!Input.GetMouseButton(0)) || ((Vector2)snake.transform.position == target) || (Vector2.Distance(snake.transform.position, snake.Player.transform.position) >= snake.maxRange))
        {
            snake.SwitchState(snake.retracting);
        }
    }

    public override void OnTriggerEnter2D(SnakeController snake, Collider2D other)
    {
        if(other.gameObject.CompareTag("Bitable"))
        {
            while(other.OverlapPoint(snake.transform.position))
            {
                snake.transform.position = Vector2.Lerp(snake.transform.position, snake.Player.transform.position, 0.1f);
            }
            snake.SwitchState(snake.attached);
        }
        else if(other.gameObject != snake.Player)
        {
            snake.SwitchState(snake.retracting);
        }
    }

    public override void ExitState(SnakeController snake)
    {
        return;
    }
}

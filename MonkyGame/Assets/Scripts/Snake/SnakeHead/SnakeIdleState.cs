using UnityEngine;

public class SnakeIdleState : SnakeState
{
    public override void EnterState(SnakeController snake)
    {
        snake.state = SnakeController.State.Idle;
        snake.transform.position = snake.Player.transform.position;     
    }
    public override void UpdateState(SnakeController snake)
    {
        if(Input.GetMouseButtonDown(0))
        {
            snake.SwitchState(snake.extending);
        }
        else
        {
            snake.transform.position = snake.Player.transform.position;
        }
    }
    public override void OnTriggerEnter2D(SnakeController snake, Collider2D other)
    {
        return;
    }
}

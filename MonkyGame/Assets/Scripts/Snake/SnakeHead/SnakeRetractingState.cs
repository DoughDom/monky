using UnityEngine;

public class SnakeRetractingState : SnakeState
{
    private Vector3 target;

    public override void EnterState(SnakeController snake)
    {
        snake.state = SnakeController.State.Retracting;
        target = snake.Player.transform.position;
    }
    public override void UpdateState(SnakeController snake)
    {
        snake.RotateTowards(snake.Player, 0);
        if(Input.GetMouseButtonDown(0))
        {
            snake.SwitchState(snake.extending);
        }
        else if(snake.transform.position == snake.Player.transform.position)
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
            snake.SwitchState(snake.idle);
        }
    }
}

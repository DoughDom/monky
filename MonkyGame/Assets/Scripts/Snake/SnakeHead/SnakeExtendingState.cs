using UnityEngine;

public class SnakeExtendingState : SnakeState
{
    private Vector3 target;
    
    public override void EnterState(SnakeController snake)
    {
        snake.state = SnakeController.State.Extending;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = snake.transform.position.z;
    }
    public override void UpdateState(SnakeController snake)
    {
        snake.RotateTowards(snake.Player, 0);
        if((Input.GetMouseButtonUp(0)) || (snake.transform.position == target) || (Vector3.Distance(snake.transform.position, snake.Player.transform.position) >= snake.maxRange))
        {
            snake.SwitchState(snake.retracting);
        }
        else
        {
            snake.transform.position = Vector3.MoveTowards(snake.transform.position, target, snake.speed * Time.deltaTime);
        }
    }
    public override void OnTriggerEnter2D(SnakeController snake, Collider2D other)
    {
        if(other.gameObject.CompareTag("Bitable"))
        {
            snake.SwitchState(snake.attached);
        }
        else if(other.gameObject != snake.Player)
        {
            snake.SwitchState(snake.retracting);
        }
    }
}

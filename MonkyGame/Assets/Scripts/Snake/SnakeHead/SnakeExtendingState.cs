using UnityEngine;

public class SnakeExtendingState : SnakeState
{
    private Vector2 target;
    private Vector2 firePos;
    
    public override void EnterState(SnakeController snake)
    {
        snake.state = SnakeController.State.Extending;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        firePos = snake.transform.position;
        if (snake.GetComponent<Collider2D>().IsTouchingLayers(snake.whatIsBitable))
        {
            snake.SwitchState(snake.attached);
        }
    }
    
    public override void UpdateState(SnakeController snake)
    {
        snake.RotateTowards(snake.Player, 0);
        
    }

    public override void FixedUpdateState(SnakeController snake)
    {
        snake.transform.position = Vector2.MoveTowards(snake.transform.position, target, snake.speed * Time.deltaTime);
        if((!Input.GetMouseButton(0)) || ((Vector2)snake.transform.position == target) || (snake.length >= snake.maxRange))
        {
            snake.SwitchState(snake.retracting);
        }
    }

    public override void OnTriggerEnter2D(SnakeController snake, Collider2D other)
    {
        if(other.gameObject.CompareTag("Bitable"))
        {
            
            Vector2 distanceVector1 =  (Vector2)snake.transform.position - firePos;
            RaycastHit2D hit = Physics2D.Raycast(firePos, distanceVector1.normalized, snake.length + 1.5f, snake.whatIsBitable);
            if(hit)
            {
                snake.transform.position = hit.point;
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

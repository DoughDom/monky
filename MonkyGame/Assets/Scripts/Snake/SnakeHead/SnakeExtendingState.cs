using UnityEngine;

public class SnakeExtendingState : SnakeState
{
    private Vector2 target;
    private Vector2 firePos;
    private Vector2 targetDistance;
    
    public override void EnterState(SnakeController snake)
    {
        snake.speed = 20f;
        snake.state = SnakeController.State.Extending;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        firePos = snake.transform.position;
        targetDistance = target - firePos;
        //targetDistance.x = targetDistance.x / Mathf.Abs(targetDistance.x) * snake.speed;
        //targetDistance.y = targetDistance.y / Mathf.Abs(targetDistance.y) * snake.speed;
        Debug.Log(targetDistance.x);
        Debug.Log(targetDistance.y);
        snake.GetComponent<Rigidbody2D>().AddForce(targetDistance.normalized * snake.speed, ForceMode2D.Impulse);
        if (snake.GetComponent<Collider2D>().IsTouchingLayers(snake.whatIsBitable))
        {
            snake.SwitchState(snake.attached);
        }
    }
    
    public override void UpdateState(SnakeController snake)
    {
        snake.RotateTowards(snake.Player.transform.position, 0);
    }

    public override void FixedUpdateState(SnakeController snake)
    {
        //  || ((Vector2)snake.transform.position == target)
        //snake.transform.position = Vector2.MoveTowards(snake.transform.position, target, snake.speed * Time.deltaTime);

        
        if((!Input.GetMouseButton(0)) || (snake.length >= snake.maxRange))
        {
            //snake.GetComponent<Rigidbody2D>().AddForce(-(snake.GetComponent<Rigidbody2D>().velocity) * snake.speed);
            snake.SwitchState(snake.retracting);
        }
    }

    public override void OnTriggerEnter2D(SnakeController snake, Collider2D other)
    {
        if(other.gameObject.CompareTag("Bitable"))
        {
            
            //snake.GetComponent<Rigidbody2D>().AddForce((targetDistance) * 0, ForceMode2D.Impulse);
            snake.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Vector2 distanceVector1 =  (Vector2)snake.transform.position - firePos;
            RaycastHit2D hit = Physics2D.Raycast(firePos, distanceVector1.normalized, snake.length + 1.5f, snake.whatIsBitable);
            if(hit)
            {
                snake.transform.position = hit.point;
            }
            Debug.Log(snake.GetComponent<Rigidbody2D>().velocity);
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

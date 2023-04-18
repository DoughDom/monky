using UnityEngine;

public abstract class SnakeState
{
    public abstract void EnterState(SnakeController snake);

    public abstract void UpdateState(SnakeController snake);
    
    public abstract void OnTriggerEnter2D(SnakeController snake, Collider2D other);
}

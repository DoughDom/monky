using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls all movement and behavior of snake

public class SnakeController : MonoBehaviour
{
    public enum State
    {
        Attached,
        Extending,
        Retracting,
        Idle
    }
    public State state;

    public SnakeState currentState;

    // Creates an instance of all 4 states of snake movement

    public SnakeIdleState idle = new SnakeIdleState();
    public SnakeExtendingState extending = new SnakeExtendingState();
    public SnakeRetractingState retracting = new SnakeRetractingState();
    public SnakeAttachedState attached = new SnakeAttachedState();

    public float originalDistance;
    public GameObject Player;
    public float speed;
    public float length;
    public float maxRange;
    

    public LayerMask whatIsBitable;


    [HideInInspector]public SpriteRenderer spriteRenderer;

    void Awake()
    {
        speed = 40f;
        maxRange = 8f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentState = idle;
        currentState.EnterState(this);
    }   

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    void FixedUpdate()
    {
        length = Vector2.Distance(transform.position, Player.transform.position);
        currentState.FixedUpdateState(this);
    }
    
    // On collision pass object in collision and snake obeject to OnTriggerEnter2D of current snake state
    void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter2D(this, other);
    }

    // When SwitchState is called take in new snake state and change the state to that new state
    public void SwitchState(SnakeState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }

    // When RotateTowards is called take in targeted object and offset and changes direction of snake away from player
    public void RotateTowards(GameObject targetObject, float offset)
    {
        Vector3 vectorToTarget = targetObject.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - (-90 + offset);
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = q;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public SnakeIdleState idle = new SnakeIdleState();
    public SnakeExtendingState extending = new SnakeExtendingState();
    public SnakeRetractingState retracting = new SnakeRetractingState();
    public SnakeAttachedState attached = new SnakeAttachedState();

    public float originalDistance;
    public GameObject Player;
    public float speed;
    public float maxRange;

    void Start()
    {
        speed = 40f;
        maxRange = 9f;
        currentState = idle;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter2D(this, other);
    }

    public void SwitchState(SnakeState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void RotateTowards(GameObject targetObject, float offset)
    {
        Vector3 vectorToTarget = targetObject.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - (-90 + offset);
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = q;
    }
}

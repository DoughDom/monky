using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;

    [SerializeField] private LayerMask whatIsGround;
	[SerializeField] private Transform groundCheck;
    const float groundedRadius = .2f;
	public bool grounded;

    public UnityEvent OnLandEvent;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        speed = 10;

		if (OnLandEvent == null)
        {
			OnLandEvent = new UnityEvent();
        }
    }

    void FixedUpdate()
	{
		bool wasGrounded = grounded;
		grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

	public void Swing(float horizontalInput, float speed, Vector2 anchorPoint)
	{
		if(!grounded)
		{
			Vector2 vectorFromTarget = (Vector2)transform.position - anchorPoint;
			Vector2 perpVector = Vector2.Perpendicular(vectorFromTarget).normalized;
			rb2d.AddForce(perpVector * speed * horizontalInput);
		}
		else
		{
			rb2d.AddForce(Vector2.right * speed * horizontalInput);
		}
	}
	
}

/// This script moves the character controller forward 
/// and sideways based on the arrow keys.
/// Make sure to attach a character controller to the same game object.
/// It is recommended that you make only one call to Move or SimpleMove per frame.	

using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	public float speed = 10.0f;
	float jumpSpeed = 8.0f;
//	float gravity = 20.0f;
	public float MAX_SPEED = 40.0f;
	float MAX_JUMP_SPEED = 15.0f;
	public Rigidbody2D rigidBody;
	public float friction = 0.2f;
	Vector2 originalPosition;

	private Animator animator;

	private Vector2 moveDirection = Vector2.zero;

	// Use this for initialization
	void Start () 
	{
		this.animator = this.GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();
		originalPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
		applyFriction();

		if(Input.GetKey(KeyCode.D))
		{
			animator.SetInteger("state", 1);
			moveDirection.x += speed;
		}
		else if(Input.GetKey(KeyCode.A))
		{
			animator.SetInteger("state", 1);
			moveDirection.x -= speed;
		}
		else if(Input.GetKey(KeyCode.W))
		{
			animator.SetInteger("state", 1);
			moveDirection.y = jumpSpeed;
		}else{
			animator.SetInteger("state", 0);
		}
		//Apply gravity
//		moveDirection.y -= gravity * Time.deltaTime;
//
//		Debug.Log("moveDirection.y : " + moveDirection.y);
//		Debug.Log ("originalpostion.y : " + originalPosition.y);

		clampSpeed();
		// Move the rigid body
		rigidBody.velocity = moveDirection * Time.deltaTime;
	}
	void clampSpeed()
	{
		if(moveDirection.x > MAX_SPEED)
		{
			moveDirection.x = MAX_SPEED;
		}
		else if(moveDirection.x < -MAX_SPEED)
		{
			moveDirection.x = -MAX_SPEED;
		}

		if(moveDirection.y > MAX_JUMP_SPEED)
		{
			moveDirection.y = MAX_JUMP_SPEED;
		}
		else if(moveDirection.y < -MAX_JUMP_SPEED)
		{
			moveDirection.y = -MAX_JUMP_SPEED;
		}
	}

	void applyFriction()
	{
		if(moveDirection.x > 0)
		{
			moveDirection.x -= friction;
			if(moveDirection.x < 0)
			{
				moveDirection.x = 0;
			}
		}
		else if(moveDirection.x < 0)
		{
			moveDirection.x += friction;
			if(moveDirection.x > 0)
			{
				moveDirection.x = 0;
			}
		}
	}

	void onColliderEnter(Collider other)
	{
		if(other.tag == "Log")
		{
			rigidBody.velocity = Vector2.zero;
		}
	}
}

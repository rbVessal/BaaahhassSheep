
/// This script moves the character controller forward 
/// and sideways based on the arrow keys.
/// Make sure to attach a character controller to the same game object.
/// It is recommended that you make only one call to Move or SimpleMove per frame.	

using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	float speed = 2.0f;
	float jumpSpeed = 8.0f;
//	float gravity = 20.0f;
	float MAX_SPEED = 10.0f;
	float MAX_JUMP_SPEED = 15.0f;
	public Rigidbody2D rigidBody;
	float friction = 0.2f;
	Vector2 originalPosition;

	private Vector2 moveDirection = Vector2.zero;

	// Use this for initialization
	void Start () 
	{
		rigidBody = GetComponent<Rigidbody2D>();
		originalPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
		applyFriction();

		if(Input.GetKey(KeyCode.D))
		{
			moveDirection.x += speed;
		}
		else if(Input.GetKey(KeyCode.A))
		{
			moveDirection.x -= speed;
		}
		else if(Input.GetKey(KeyCode.W))
		{
			moveDirection.y = jumpSpeed;
		}
		//Apply gravity
//		moveDirection.y -= gravity * Time.deltaTime;
//
//		Debug.Log("moveDirection.y : " + moveDirection.y);
//		Debug.Log ("originalpostion.y : " + originalPosition.y);

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
}


/// This script moves the character controller forward 
/// and sideways based on the arrow keys.
/// Make sure to attach a character controller to the same game object.
/// It is recommended that you make only one call to Move or SimpleMove per frame.	

using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	bool isAccelerating = false;
	bool isJumping = false;
	public float speedEasing = 0.3f;
	//float jumpSpeed = 8.0f;
	//	float gravity = 20.0f;
	public float MAX_SPEED = 20.0f;
	float MAX_JUMP_SPEED = 1200.0f;
	public float DASH_SPEED;
	public Rigidbody2D rigidBody;
	public float friction = 0.2f;
	Vector2 originalPosition;
	public float gravityStrength = 20.0f;
	
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
	void FixedUpdate () 
	{
		
		
		applyFriction();
		
		applyGravity ();
		
		applyInputMovement ();
		//Debug.Log (moveDirection.x);
	}

	//applies the wasd and space button inputs
	void applyInputMovement(){

		isAccelerating = false; //false by default. change to true below if we have 'A' or 'D' input
		isJumping = false; //same for jumping
		
		if (Input.GetKey (KeyCode.D)) {
			animator.SetInteger ("state", 1);
			isAccelerating = true;
			moveDirection.x += (MAX_SPEED-moveDirection.x)*speedEasing*Time.deltaTime;
		} else if (Input.GetKey (KeyCode.A)) {
			animator.SetInteger ("state", 1);
			isAccelerating = true;
			moveDirection.x += (-MAX_SPEED + moveDirection.x)*speedEasing*Time.deltaTime;

		} else{
			animator.SetInteger("state", 0);
		}

		if ((Input.GetKey (KeyCode.W) || Input.GetKey(KeyCode.Space)) && checkGrounded ()) {
			jump ();
			isJumping = true;

		}
		//Apply gravity
		//		moveDirection.y -= gravity * Time.deltaTime;
		//
		//		Debug.Log("moveDirection.y : " + moveDirection.y);
		//		Debug.Log ("originalpostion.y : " + originalPosition.y);
		
		clampSpeed();

		//dash goes above clamped speed ;)
		if (Input.GetKey (KeyCode.S)) {
			dash();
		}
		// Move the rigid body
		rigidBody.velocity = moveDirection * Time.deltaTime;


	}

	void jump(){
			moveDirection.y = MAX_JUMP_SPEED;
	}

	void dash(){
		moveDirection.x = DASH_SPEED;
	}

	bool checkGrounded(){
		
		float radius = GetComponent<CircleCollider2D> ().radius;
		
		RaycastHit2D hit = Physics2D.Raycast (new Vector2(transform.position.x,
		                                                  transform.position.y - radius*2.001f)
		                                      			, -Vector2.up, 0.01f);
		
		
		//Debug.Log (hit.collider.name);//hit.collider
		
		if (hit.collider != null) {
			Debug.DrawLine(new Vector3(hit.point.x, hit.point.y, -9), new Vector3(transform.position.x, transform.position.y, -9), Color.green);
			
			return true;
			
			
		} else {
			return false;
		}
	}
	
	void applyGravity(){
		if (checkGrounded () == false) {
			moveDirection.y -= gravityStrength;
		}
		
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
		if (isAccelerating) {
			return; //if we are accelerating, don't apply the friction
		}
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
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Log")
		{
			rigidBody.velocity = Vector2.zero;
		}
		else if(other.gameObject.tag == "Wolf")
		{

		}
	}
}

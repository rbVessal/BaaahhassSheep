using UnityEngine;
using System.Collections;

public class wolfScript : MonoBehaviour 
{

	GameObject player;
	float DISTANCE_THRESHOLD_TO_PLAYER = 20f;
	Vector2 runningVelocity = new Vector2(-20, 0);
	string state = "idle";
	Rigidbody2D rigidbody;
	bool collisionOccurred;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		rigidbody = GetComponent<Rigidbody2D>();
		collisionOccurred = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (distanceToPlayer() < DISTANCE_THRESHOLD_TO_PLAYER)
		{
			if(!collisionOccurred)
			{
				rigidbody.velocity = runningVelocity;
			}
			else
			{
				rigidbody.velocity = new Vector2(-runningVelocity.x, -runningVelocity.y);
			}

			GetComponent<Animator>().SetInteger("state", 1);
		}
	}

	float distanceToPlayer()
	{
		return this.transform.position.x - player.transform.position.x ;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			Debug.Log(collision.relativeVelocity);
			rigidbody.velocity = new Vector2(-collision.relativeVelocity.x, 
			                                 -collision.relativeVelocity.y);
			collisionOccurred = true;
		}
	}
}

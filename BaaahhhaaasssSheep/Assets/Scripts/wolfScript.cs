using UnityEngine;
using System.Collections;

public class wolfScript : MonoBehaviour 
{

	GameObject player;
	float DISTANCE_THRESHOLD_TO_PLAYER = 20f;
	Vector2 runningVelocity = new Vector2(-20, 0);
	string state = "idle";
	Rigidbody2D rigidbody;
	BoxCollider2D collider;
	bool collisionOccurred = false;
	bool firstCollisionDidOccur = false;
	Camera camera;
	public GameObject deathEffect;

	int lifePoints = 2;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D>();
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (distanceToPlayer() < DISTANCE_THRESHOLD_TO_PLAYER)
		{
			if(!collisionOccurred)
			{
				run();
			}
			else
			{
				runAway();
			}
			GetComponent<Animator>().SetInteger("state", 1);
		}
		else
		{
			if(!collisionOccurred)
			{
				if(firstCollisionDidOccur)
				{
					run ();
				}
			}
			else
			{
				runAway();
			}
		}
	}

	void run()
	{
		rigidbody.velocity = runningVelocity;
	}

	void runAway()
	{
//			float rightSidePositionX = (camera.pixelWidth + (collider.size.x/2));
//			float runAwayVelocityX = ((rigidbody.velocity.x + runningVelocity.x + 
//			                           rigidbody.position.x + (collider.size.x/2)));
		float rightSidePositionX = (collider.size.x/2) + rigidbody.position.x;
		//Debug.Log ("right: " + rigidbody.position.x);
		//Debug.Log ("right side: " + rightSidePositionX);
		//			Debug.Log ("runaway velocity x: " + runAwayVelocityX);
		if(rightSidePositionX > 50)
		{
			this.transform.localScale = new Vector3(this.transform.localScale.x * -1, 
			                                          this.transform.localScale.y, 
			                                          this.transform.localScale.z);				
			collisionOccurred = false;
			//Debug.Log("reset");
		}
		else
		{
			rigidbody.velocity = new Vector2(-runningVelocity.x, 0);
		}
	}

	float distanceToPlayer()
	{
		return this.transform.position.x - player.transform.position.x ;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Player")
		{
//			rigidbody.velocity = new Vector2(-collision.relativeVelocity.x, 
//			                                 0);
			collisionOccurred = true;
			firstCollisionDidOccur = true;
			this.transform.localScale = new Vector3(this.transform.localScale.x * -1, 
			                                          this.transform.localScale.y, 
			                                          this.transform.localScale.z);
		}
	}
	public void Hit(){
		lifePoints--;
		if (lifePoints == 0){
			GameObject go = (GameObject) Instantiate(deathEffect, this.transform.position, Quaternion.identity);
			go.transform.Rotate(0, 180, 0);
			GameObject.Destroy(this.gameObject);
		}
	}
}

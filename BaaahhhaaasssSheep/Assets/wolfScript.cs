using UnityEngine;
using System.Collections;

public class wolfScript : MonoBehaviour {

	GameObject player;

	Vector2 runningVelocity = new Vector2(-20, 0);
	string state = "idle";
	Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (distanceToPlayer() < 20){
			rigidbody.velocity = runningVelocity;
			GetComponent<Animator>().SetInteger("state", 1);
		}
	}

	float distanceToPlayer(){
		return this.transform.position.x - player.transform.position.x ;
	}
}

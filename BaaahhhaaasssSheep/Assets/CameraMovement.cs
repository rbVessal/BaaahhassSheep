using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	GameObject player;
	float xoffset;

	float yorigin;
	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		xoffset = player.transform.position.x - transform.position.x;
		yorigin = this.transform.position.y;
		Debug.Log (xoffset);
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = new Vector3 (player.transform.position.x - xoffset, 
		                                       (player.transform.position.y + yorigin)/2, 
		                                       this.transform.position.z); 
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxScrolling : MonoBehaviour {

	Character character;
	Environment grass;
	Environment grass2;
	Environment currentGrass;
	Camera camera;
	List<Environment>grasses;

	// Use this for initialization
	void Start () 
	{
		grasses = new List<Environment>();
		character = GameObject.Find("Baahdass").GetComponent<Character>();
		grass = GameObject.Find("Grass").GetComponent<Environment>();
		grass2 = GameObject.Find("Grass2").GetComponent<Environment>();

		grasses.Add(grass2);
		grasses.Add(grass);
		currentGrass = grass;
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () 
	{
//		float characterVelocityX = character.controller.velocity.x;
//		float currentGrassPositionAtOrigin = currentGrass.transform.position.x + currentGrass.spriteRenderer.bounds.size.x/2;
//
//		if(characterVelocityX != 0)
//		{
//			currentGrass.transform.position = new Vector3(currentGrass.transform.position.x - characterVelocityX/2,
//			                                                currentGrass.transform.position.y,
//			                                                0);
//			Debug.Log(Screen.width);
//			if(currentGrassPositionAtOrigin < 0)
//			{
//				currentGrass = grasses[0];
//				Environment grass = grasses[0];
//				grasses.Remove(grass);
//				grasses.Add(grass);
//			}
//		}
	}
}

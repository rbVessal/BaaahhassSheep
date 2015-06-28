using UnityEngine;
using System.Collections;

//game controller class for NightmareWarrior
//contact: jordanjalles at gmail dot com


/*if iterated, this class will need to break into
 *two classes, the GameController class:
 *		start - startscreen - stop - (un)pause - gameOver - update
 * 
 * and a Level class:
 * 		boss - enemyController - player - stopAll - startAll
 * 
 * for this prototype we are keeping this class as one for simplicities sake
 * 
 * */

public class GameController : MonoBehaviour {


	public Canvas startScreen;

	string state = "StartScreen";

	Character player;
	GameObject enemyController;
	GameObject boss;
	FadeOverLay fadeOverlay;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Character>();
		fadeOverlay = GameObject.FindGameObjectWithTag("FadeOverlay").GetComponent<FadeOverLay>();
	}

	void Update() {
		if (state == "StartScreen") {
			if (Input.GetKey(KeyCode.Space)){
				StartGame ();
			}
		}

		if (state == "Playing") {
			if (Input.GetKey(KeyCode.P)) {
				PauseGame ();
			}
			if(player.isDead)
			{
				
			}
			else
			{
				if(player.gotHit())
				{
					fadeOverlay.fade();
				}
			}
		}
		if (state == "Paused") {
			if (Input.GetKey(KeyCode.P)) {
				UnPauseGame ();
			}
		}
	}
	
	void StartGame(){
		state = "Playing";
		//remove gui and intro screen
		//spawn sheep and world
		//start the timer
	}
	
	void PauseGame(){
		state = "Paused";
		StopAll ();

	}

	void UnPauseGame(){
		state = "Playing";
		StartAll();
	}

	void GameOver(){
		state = "GameOver";
		StopAll ();

	}

	void StartScreen(){
		//display gui
		state = "StartScreen";
	}

	void StopAll(){
		//tell Baahdass to stop moving
		//tell wolves to stop moving
		//tell werewolve to stop moving

	}

	void StartAll(){
		//tell Baahdass to start moving
		//tell wolves to start moving
		//tell werewolve to start moving
		
	}

}

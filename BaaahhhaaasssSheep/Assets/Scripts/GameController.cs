using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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



	string state = "StartScreen";

	Character player;
	FadeOverLay fadeOverlay;
	GameObject enemyController;
	GameObject boss;
	GameObject startScreen;

	public Text gameOverText;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Character>();
		fadeOverlay = GameObject.FindGameObjectWithTag ("FadeOverlay").GetComponent<FadeOverLay>();
		startScreen = GameObject.FindGameObjectWithTag ("StartScreen");
		gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();
		StartScreen();
		Debug.Log(gameOverText.text);
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

			if(player.isDead())
			{
				fadeOverlay.fade();
				GameOver();
			}
			else if(player.gotHit())
			{
				fadeOverlay.fade();
				player.isHit = false;
			}
//			Debug.Log ("got hit: " + player.gotHit());

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
		GameObject.Destroy (startScreen);

		//start sheep and world
		player.SendMessage ("play");


		//start the boss chase
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
		gameOverText.text = "GAME OVER";
//		gameOverText.SetActive(true);
		StopAll ();
	}

	void StartScreen(){
		//display gui
		state = "StartScreen";
//		gameOverText.text = "Press [SPACE] to play!";
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

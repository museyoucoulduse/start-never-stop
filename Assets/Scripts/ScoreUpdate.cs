using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {

	TriangleMovement triangle;
	StartGame game;
	int prevHighScore;
	Animator anim;
	bool warmup;
	float loops;

	// Use this for initialization
	void Start () {
		game = FindObjectOfType<StartGame> ();
		anim = GetComponent<Animator> ();
		warmup = true;
		prevHighScore = 0;
		loops = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		triangle = FindObjectOfType<TriangleMovement> ();
		print (game.highScore + " " + prevHighScore);
//		print (anim.GetCurrentAnimatorStateInfo (0).shortNameHash == (Animator.StringToHash("HighScoreAnimation")));

		if (game.gameStarted && triangle != null && 
			anim.GetBool("highScore") == true && !warmup &&
			loops + 3f < anim.GetCurrentAnimatorStateInfo (0).normalizedTime) {
			print ("Norm time " + anim.GetCurrentAnimatorStateInfo (0).normalizedTime + " length " + anim.GetCurrentAnimatorStateInfo (0).length);
			GetComponent<Text> ().text = "" + triangle.score;
			anim.SetBool ("highScore", false);
		} else if (game.gameStarted && triangle != null && warmup) {
			GetComponent<Text> ().text = "" + triangle.score;
			anim.SetBool ("highScore", false);
			warmup = false;
		} else if (game.highScore > prevHighScore && !warmup) {
			print ("High Score!");
			GetComponent<Text> ().text = "High Score " + game.highScore + "! +" + (game.highScore - prevHighScore);
			prevHighScore = game.highScore;
			anim.SetBool ("highScore", true);
			loops = Mathf.Ceil (anim.GetCurrentAnimatorStateInfo (0).normalizedTime);
		}
		else if (game.gameStarted && triangle != null && !warmup && anim.GetBool("highScore") == false) {
			GetComponent<Text> ().text = "" + triangle.score;
		} 
		else if (!game.gameStarted) {
			GetComponent<Text> ().text = "High Score " + game.highScore + "!";
			anim.SetBool ("highScore", true);
		}
	}
}

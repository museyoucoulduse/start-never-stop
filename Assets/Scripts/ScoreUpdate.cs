using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {

	TriangleMovement triangle;
	GameManager game;
	int prevHighScore;
	Animator anim;
	bool warmup;
	float loops;
	int combo;

	// Use this for initialization
	void Start () {
		game = FindObjectOfType<GameManager> ();
		anim = GetComponent<Animator> ();
		warmup = true;
		prevHighScore = 0;
		loops = 0f;
		combo = 0;
	}
	
	// Update is called once per frame
	void Update () {
		triangle = FindObjectOfType<TriangleMovement> ();
//		print (game.highScore + " " + prevHighScore);
//		print (anim.GetCurrentAnimatorStateInfo (0).shortNameHash == (Animator.StringToHash("HighScoreAnimation")));

		if (game.gameStarted && triangle != null && 
			anim.GetBool("highScore") == true && !warmup &&
			loops + 3f < anim.GetCurrentAnimatorStateInfo (0).normalizedTime) {
			GetComponent<Text> ().text = "" + triangle.score;
			anim.SetBool ("highScore", false);
			combo = 0;
		} else if (game.gameStarted && triangle != null && warmup) {
			GetComponent<Text> ().text = "" + triangle.score;
			anim.SetBool ("highScore", false);
			warmup = false;
		} else if (game.gameStarted && game.highScore > prevHighScore && !warmup) {
			print ("High Score!");
			int highScoreDelta = game.highScore - prevHighScore;
			string highScoreSuffix;
			if (highScoreDelta == game.highScore) {
				highScoreSuffix = "";	
			} else {
				combo += highScoreDelta;
				highScoreSuffix = " +" + combo;
			}
			GetComponent<Text> ().text = "High Score " + game.highScore + "!" + highScoreSuffix;
			prevHighScore = game.highScore;
			anim.SetBool ("highScore", true);
			loops = Mathf.Ceil (anim.GetCurrentAnimatorStateInfo (0).normalizedTime);
		}
		else if (game.gameStarted && triangle != null && !warmup && anim.GetBool("highScore") == false) {
			GetComponent<Text> ().text = "" + triangle.score;
			combo = 0;
		} 
		else if (!game.gameStarted) {
			GetComponent<Text> ().text = "High Score " + game.highScore + "!";
			anim.SetBool ("highScore", true);
		}
	}
}

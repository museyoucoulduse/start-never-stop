using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedUpdate : MonoBehaviour {

	TriangleMovement triangle;
	StartGame game;

	// Use this for initialization
	void Start () {
		game = GameObject.FindObjectOfType<StartGame> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (game.gameStarted) {
			triangle = FindObjectOfType<TriangleMovement> ();
			GetComponent<Text> ().text = "Speed " + (triangle.Speed - 15) + " 0:0" + (10f - Time.time % 10);
		} else {
			GetComponent<Text> ().text = "";
		}

	}
}

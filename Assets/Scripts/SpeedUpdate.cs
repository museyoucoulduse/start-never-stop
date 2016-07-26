using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedUpdate : MonoBehaviour {

	TriangleMovement triangle;
	GameManager game;
	const int _speedDiff = 0;

	// Use this for initialization
	void Start () {
		game = GameObject.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (game.gameStarted) {
			triangle = FindObjectOfType<TriangleMovement> ();
			GetComponent<Text> ().text = "Speed " + Mathf.Floor(triangle.Speed - _speedDiff) + " Reset in 0:0" + Mathf.Floor(10f - Time.time % 10);
		} else {
			GetComponent<Text> ().text = "";
		}

	}
}

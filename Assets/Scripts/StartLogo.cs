using UnityEngine;
using System.Collections;

public class StartLogo : MonoBehaviour {

	static StartLogo instance = null;

	GameManager gameManager;

	void Awake() {
		if (instance == null) {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.gameStarted) {
			this.transform.position = new Vector3 (0f, 0f, 0f);
		}
	}
}

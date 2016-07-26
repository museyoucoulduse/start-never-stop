using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

	string lastPlayer;
	public bool continuation;

	static PlayerManager instance = null;

	void Awake() {
		if (instance == null) {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	public void LastPlayer () {
		Debug.Log ("Player " + lastPlayer + " want to continue her last game.");
		LevelManager levelManager = GameObject.FindObjectOfType<LevelManager> ();
		levelManager.LoadLevel ("Game");
		continuation = true;
	}

	public void NewPlayer() {
		Debug.Log ("New Player want to start new game. Let her choose name.");
		GameObject.Find ("/Canvas/Panel/AskForName/OK").SetActive (true);
		GameObject.Find ("/Canvas/Panel/AskForName/PlayerName").SetActive (true);
		GameObject.Find ("/Canvas/Panel/AskForName").SetActive (true);
		GameObject.Find ("/Canvas/Panel/Menu").SetActive (false);
	}

	public void SubmitNewPlayer(Text nicknameText) {
		string nickname = nicknameText.text;
		if (nickname == "") {
			return;
		}
		Debug.Log ("I want to set my nickname...");
		PlayerPrefs.SetString ("LastPlayer", nickname);
		if (nickname == "Katy Perry") {
			Debug.Log("I'm that stupid to actually fall in love with you, Katy.");
		}
		Debug.Log ("Starting game for " + nickname);
		LevelManager levelManager = new LevelManager();
		continuation = false;
		levelManager.LoadLevel("Game");
	}

	public void SetGender(int genderNumber) {
		PlayerPrefs.SetInt ("Gender", genderNumber);
	}

	// Use this for initialization
	void Start () {
		lastPlayer = PlayerPrefs.GetString ("LastPlayer");
		if (PlayerPrefs.GetString ("LastPlayer") == "") {
			GameObject.Find ("/Canvas/Panel/Menu/Continue").GetComponent<Button> ().interactable = false;
		} else {
			Debug.Log ("Last Player was " + lastPlayer);
		}

		continuation = false;
	}

	// Update is called once per frame
	void Update () {
	
	}
}

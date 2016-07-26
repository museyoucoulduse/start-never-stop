using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		
		Debug.Log ("Please load scene " + name);

		SceneManager.LoadSceneAsync (name);
	}

	public void Quit() {
		Debug.Log ("Bye, bye");
		Application.Quit ();
	}
}

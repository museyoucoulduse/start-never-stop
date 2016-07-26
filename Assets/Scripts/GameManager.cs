using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public bool gameStarted;
	public GameObject trianglePrefab;
	public int highScore;

	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt("Player Score");
		if (SceneManager.GetActiveScene().name != "Menu") {
			System.Guid myGUID = System.Guid.NewGuid();
			Random.seed = myGUID.GetHashCode();
			gameStarted = true;
			GameObject triangle = (GameObject)Instantiate (trianglePrefab, new Vector3 (-8f, 0f, 0f), Quaternion.identity);
			SpriteRenderer renderer = triangle.GetComponent<SpriteRenderer> ();
			renderer.color = Random.ColorHSV ();
			Transform form = triangle.GetComponent<Transform> ();
			float scale = -0.1f;
			form.localScale += new Vector3 (scale, scale, scale);
			gameStarted = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		highScore = PlayerPrefs.GetInt("Player Score");
	}
}

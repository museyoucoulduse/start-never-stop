using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

	public GameObject femaleBackground;
	public GameObject maleBackground;
	public GameObject transgenderBackground;
	public GameObject neuterBackground;
	public GameObject asexualityBackground;

	public Sprite female;
	public Sprite male;
	public Sprite transgender;
	public Sprite neuter;
	public Sprite asexuality;

	const float xBackground = -0.007f;
	const float yBackground = 0.326f;
	const float zBackground = 0f;

	public void SetBackground2 ()
	{
//		GameObject tmp = null;
//		int gender = PlayerPrefs.GetInt ("Gender");
//		if (gender == 0) {
//			tmp = (GameObject)Instantiate (femaleBackground, new Vector3 (xBackground, yBackground, zBackground), Quaternion.identity);
//		} else if (gender == 1) {
//			tmp = (GameObject)Instantiate (maleBackground, new Vector3 (xBackground, yBackground, zBackground), Quaternion.identity);
//		} else if (gender == 2) {
//			tmp = (GameObject)Instantiate (transgenderBackground, new Vector3 (xBackground, yBackground, zBackground), Quaternion.identity);
//		} else if (gender == 3) {
//			tmp = (GameObject)Instantiate (neuterBackground, new Vector3 (xBackground, yBackground, zBackground), Quaternion.identity);
//		} else if (gender == 4) {
//			tmp = (GameObject)Instantiate (asexualityBackground, new Vector3 (xBackground, yBackground, zBackground), Quaternion.identity);
//		}
	}

	public void SetBackground() {
		int gender = PlayerPrefs.GetInt ("Gender");
		GameObject background = GameObject.Find ("/BackgroundImage");
		switch (gender) {
		case 0:
			background.GetComponent<SpriteRenderer> ().sprite = female;
			break;
		case 1:
			background.GetComponent<SpriteRenderer> ().sprite = male;
			break;
		case 2:
			background.GetComponent<SpriteRenderer> ().sprite = transgender;
			break;
		case 3:
			background.GetComponent<SpriteRenderer> ().sprite = neuter;
			break;
		case 4:
			background.GetComponent<SpriteRenderer> ().sprite = asexuality;
			break;
		default:
			break;
		}
	}

	// Use this for initialization
	void Start () {
		SetBackground ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

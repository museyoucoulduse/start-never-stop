using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

//	Animator anim;
//	AnimatorStateInfo stateInfo;
//	bool prewarm = false;
//	public int highScore;
//	public bool gameStarted = false;
//	float time = 99999999999f;
//
//	public GameObject trianglePrefab;

	// Use this for initialization
	void Start () {
//		anim = GetComponent<Animator>();
//		highScore = PlayerPrefs.GetInt("Player Score");
	}
	
	// Update is called once per frame
	void Update () {
//		highScore = PlayerPrefs.GetInt("Player Score");
//		stateInfo = anim.GetCurrentAnimatorStateInfo (0);
//		if (stateInfo.IsName ("PanelAnimation") && time > 99999999f) {
//			time = Time.time;
//			print (time);
//			prewarm = true;
//		}
//		if (Time.time > time + 6f && prewarm) {
//			System.Guid myGUID = System.Guid.NewGuid();
//			Random.seed = myGUID.GetHashCode();
//			gameStarted = true;
//			float y = Random.Range (5f, -5f);
//			GameObject triangle = (GameObject)Instantiate (trianglePrefab, new Vector3 (-8f, y, 0f), Quaternion.identity);
//			SpriteRenderer renderer = triangle.GetComponent<SpriteRenderer> ();
//			renderer.color = Random.ColorHSV ();
//			Transform form = triangle.GetComponent<Transform> ();
//			float scale = -0.1f;
//			form.localScale += new Vector3 (scale, scale, scale);
//			prewarm = false;
//		}
//		if (Input.anyKeyDown) {
//			//anim.SetBool ("isGameStarted", true);
//		}
	}
}
using UnityEngine;
using System.Collections;

public class TriangleMovement : MonoBehaviour {

	public int score;
	int prevScore = 0;

	public float Speed = 10f;
	private float movex = 0f;
	private float movey = 0f;

	Rigidbody2D body;

	GameObject[] squares;
	GameObject[] bubbles;

	public GameObject squarePrefab;
	public GameObject bubblePrefab;

	const float xNewPosition = 10;
	const float minSpeed = 3f;
	const int maxSquares = 3;
	const int maxBubbles = 2;
	const int resetBuffs = 10;

	AudioClip bubble;
	AudioClip square;

	Animator anim;

	float time;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();

		System.Guid myGUID = System.Guid.NewGuid();
		Random.seed = myGUID.GetHashCode();
		float howManySquares = Mathf.Ceil(Mathf.Abs(Random.value * maxSquares));

		for (int i = 0; i < howManySquares; i++) {
			CreateRandomSquare ();
		}

		CreateRandomBubble ();

		PlayerManager pm = GameObject.FindObjectOfType<PlayerManager> ();
		if (pm.continuation) {
			score = PlayerPrefs.GetInt ("Player Score");
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		movex = Input.GetAxis ("Horizontal");
		movey = Input.GetAxis ("Vertical");
		//body.MovePosition(body.position + new Vector2 (movex * Speed, movey * Speed) * Time.deltaTime);
		body.velocity = new Vector2 (movex * Speed, movey * Speed);// * Time.deltaTime;

		float x = body.position.x;
		float y = body.position.y;

		if (y > 5) {
			body.MovePosition (new Vector2 (x, -4.9f));
		} else if (y < -5) {
			body.MovePosition (new Vector2 (x, 4.9f));
		} else if (x > 9.5) {
			body.MovePosition (new Vector2 (-9.4f, y));
		} else if (x < -9.5) {
			body.MovePosition (new Vector2 (9.4f, y));
		}

		squares = GameObject.FindGameObjectsWithTag ("square");
		bubbles = GameObject.FindGameObjectsWithTag ("bubble");

		if (squares.Length < maxSquares) {
			CreateRandomSquare ();
		}

		if (bubbles.Length < maxBubbles) {
			CreateRandomBubble ();
		}

		if ((int)Time.time % resetBuffs == 0) {
			Speed = 16;
		}

		if (prevScore != score) {
			if (score - prevScore > 0) {
				gameObject.GetComponentInChildren<TextMesh>().text = "+" + (score - prevScore);
				GameObject.FindObjectOfType<SquareMovement> ().gameObject.GetComponent<AudioSource> ().Play ();
			} else {
				gameObject.GetComponentInChildren<TextMesh>().text = "-" + (prevScore - score);
				GameObject.FindObjectOfType<BubbleMovement> ().gameObject.GetComponent<AudioSource> ().Play ();
			} 
			anim.SetBool ("scoreChange", true);
			time = Time.time;
		}
		prevScore = score;

		PlayerPrefs.SetInt ("Player Score", Mathf.Max (score, PlayerPrefs.GetInt ("Player Score")));


		if (Time.time > time + anim.GetCurrentAnimatorStateInfo(0).length) {
			GetComponentInChildren<TextMesh>().text = "";
			anim.SetBool ("scoreChange", false);
		}
	}

	void CreateRandomSquare() {
		System.Guid myGUID = System.Guid.NewGuid();
		Random.seed = myGUID.GetHashCode();
		float y = Random.Range (5f, -5f);
		GameObject square = (GameObject)Instantiate(squarePrefab, new Vector3(xNewPosition, y, 0), Quaternion.identity);
		SpriteRenderer renderer = square.GetComponent<SpriteRenderer> ();
		renderer.color = Random.ColorHSV ();
		float speed = square.GetComponent<SquareMovement> ().Speed = -Mathf.Max(minSpeed, (Mathf.Abs (Random.value * 20)));
		square.GetComponent<SquareMovement> ().pointValue = Mathf.FloorToInt(-speed);
		Transform form = square.GetComponent<Transform> ();
		float scale = Random.value / 2f;
		form.localScale -= new Vector3(scale, scale, scale);
	}

	void CreateRandomBubble() {
		System.Guid myGUID = System.Guid.NewGuid();
		Random.seed = myGUID.GetHashCode();
		float y = Random.Range (5f, -5f);
		GameObject bubble = (GameObject)Instantiate(bubblePrefab, new Vector3(xNewPosition, y, 0), Quaternion.identity);
		SpriteRenderer renderer = bubble.GetComponent<SpriteRenderer> ();
		renderer.color = Random.ColorHSV ();
		bubble.GetComponent<BubbleMovement> ().Speed = -Mathf.Max(minSpeed, (Mathf.Abs (Random.value * 30)));
		Transform form = bubble.GetComponent<Transform> ();
		float scale = Random.value / 2f;
		form.localScale -= new Vector3(scale, scale, scale);
	}
}
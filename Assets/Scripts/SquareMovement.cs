using UnityEngine;
using System.Collections;

public class SquareMovement : MonoBehaviour {

	public float Speed = -3f;
	Rigidbody2D body;
	public int pointValue = 0;

	TriangleMovement triangle;

	Animator anim;

	bool isCollected = false;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		triangle = FindObjectOfType<TriangleMovement> ();
		anim = GetComponent<Animator> ();
	}


	// Update is called once per frame
	void FixedUpdate () {

//		body.MovePosition(body.position + new Vector2 (Speed, 0) * Time.deltaTime);
		body.velocity = new Vector2 (Speed, 0);

		float x = body.position.x;
		float y = body.position.y;

		if (y > 5) {
			body.MovePosition (new Vector2 (x, -4.9f));
		} else if (y < -5) {
			body.MovePosition (new Vector2 (x, 4.9f));
		}

		if (body.position.x < -10) {
			Destroy (gameObject);
		} else if (body.position.y > 5 || body.position.y < -5) {
			Destroy (gameObject);
		}

		if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == Animator.StringToHash("SquarePoofAnimation")) {
			isCollected = true;
			Destroy (gameObject);
		}
		if (isCollected && anim.GetCurrentAnimatorStateInfo(0).shortNameHash != Animator.StringToHash("SquarePoofAnimation")) {
			isCollected = false;

		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			print ("+" + pointValue);
			triangle.score += pointValue;
			triangle.Speed += 1;
			anim.SetBool ("collected", true);
//			body.velocity.Set(0, 0);
		}
	}
}
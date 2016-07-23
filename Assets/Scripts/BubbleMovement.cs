using UnityEngine;
using System.Collections;

public class BubbleMovement : MonoBehaviour {

	public float Speed = -10f;
	Rigidbody2D body;

	TriangleMovement triangle;

	Animator hitAnim;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		triangle = FindObjectOfType<TriangleMovement> ();


	}


	// Update is called once per frame
	void FixedUpdate () {
//		body.MovePosition(body.position + new Vector2 (Speed, 0) * Time.deltaTime);
		body.velocity = new Vector2 (Speed, 0);
		if (body.position.x < -10) {
			Destroy (gameObject);
		}
		float x = body.position.x;
		float y = body.position.y;

		if (y > 5) {
			body.MovePosition (new Vector2 (x, -4.9f));
		} else if (y < -5) {
			body.MovePosition (new Vector2 (x, 4.9f));
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		GameObject[] gameObj = GameObject.FindGameObjectsWithTag ("Player");
		foreach (var gObj in gameObj) {
			if (gObj.name == "Hit") {
				hitAnim = gObj.GetComponent<Animator> ();
			}
		}

		if (hitAnim.GetCurrentAnimatorStateInfo(0).shortNameHash != Animator.StringToHash("BubbleHitAnimation") && 
			hitAnim.GetBool("bubbleHit")) {
			hitAnim.SetBool ("bubbleHit", false);
		}
		if (other.tag == "Player") {
			print ("0");
			triangle.score = 0;
			triangle.Speed -= 4;
			if (hitAnim.GetCurrentAnimatorStateInfo(0).shortNameHash != Animator.StringToHash("BubbleHitAnimation")) {
				hitAnim.SetBool ("bubbleHit", true);

			}
			Destroy(gameObject);
		}
	}
}
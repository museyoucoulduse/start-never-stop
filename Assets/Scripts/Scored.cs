using UnityEngine;
using System.Collections;

public class Scored : MonoBehaviour {

	public bool didScore = false;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (didScore) {
			didScore = false;
			anim.SetBool ("scored", true);
		}
	}
}

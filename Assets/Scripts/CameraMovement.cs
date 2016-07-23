using UnityEngine;
using System.Collections;

public class CameraMovement: MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
		transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
	}
}

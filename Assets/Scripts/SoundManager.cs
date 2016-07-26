using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

	AudioSource[] soundSources;
	public GameObject muteButton;
	public GameObject unmuteButton;

	// Use this for initialization
	void Start () {
		soundSources = GameObject.FindObjectsOfType<AudioSource> ();
		int sound = PlayerPrefs.GetInt ("Sound");
		if (sound == 0) {
			enableSound ();
		} else {
			disableSound();
		}

	}
	
	// Update is called once per frame
	void Update () {
		int sound = PlayerPrefs.GetInt ("Sound");
		soundSources = GameObject.FindObjectsOfType<AudioSource> ();
		if (sound == 0) {
			enableSound ();
		} else {
			disableSound ();
		}
	}

	public void disableSound() {
		foreach (var clip in soundSources) {
			clip.volume = 0;
		}
		muteButton.SetActive(true);
		unmuteButton.SetActive(false);
		PlayerPrefs.SetInt ("Sound", 1);
	}

	public void enableSound() {
		foreach (var clip in soundSources) {
			clip.volume = 1;
		}
		muteButton.SetActive(false);
		unmuteButton.SetActive(true);
		PlayerPrefs.SetInt ("Sound", 0);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

	public AudioClip leadIn;
	public AudioClip loop;

	public AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		Music ();
	}

	void Music()
	{
		if (!audio.isPlaying) {
			audio.clip = loop;
			audio.loop = true;
			audio.Play ();
		}
	}
}

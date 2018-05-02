using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

	public AudioClip leadIn;
	public AudioClip loop;

	public AudioSource audio;

	public static Audio music;

	void Awake()
	{
		if (music == null) {
			music = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy (this.gameObject);
		}
	}

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

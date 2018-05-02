using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreeen : MonoBehaviour {

	public GameObject win;
	public GameObject lose;

	public Button playagainL;

	// Use this for initialization
	void Start () {
		if (GameManager.manager.end == -1) {
			lose.gameObject.SetActive (true);
		} else if (GameManager.manager.end == 1) {
			win.gameObject.SetActive (true);
		}

		playagainL.onClick.AddListener (PlayAgain);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayAgain()
	{
		SceneManager.LoadScene ("Battle", LoadSceneMode.Single);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwapButton : MonoBehaviour {

	public int bNum;
	public Button but;

	public GameObject swapper;

	// Use this for initialization
	void Start () {
		but = this.GetComponent<Button>();
		but.onClick.AddListener(SwapCharacter);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SwapCharacter()
	{
		switch (bNum) {
		case 1:
			GameManager.manager.activeDuo [swapper.GetComponent<CharacterSwitch> ().charToSwap] = GameManager.manager.team [0];
			return;
		case 2:
			GameManager.manager.activeDuo [swapper.GetComponent<CharacterSwitch> ().charToSwap] = GameManager.manager.team [1];
			return;
		case 3:
			GameManager.manager.activeDuo [swapper.GetComponent<CharacterSwitch> ().charToSwap] = GameManager.manager.team [2];
			return;
		case 4:
			GameManager.manager.activeDuo [swapper.GetComponent<CharacterSwitch> ().charToSwap] = GameManager.manager.team [3];
			return;
		default:
			return;
		}
	}
}

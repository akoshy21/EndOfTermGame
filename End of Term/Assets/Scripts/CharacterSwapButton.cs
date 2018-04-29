using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwapButton : MonoBehaviour {

	// button number, set through inspector
	public int bNum;
	// button gameobject
	public Button but;

	// character switch game object, used to reference character switch script
	public GameObject swapper;

	// Use this for initialization
	void Start () {
		// add listener to this button
		but = this.GetComponent<Button>();
		but.onClick.AddListener(SwapCharacter);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SwapCharacter()
	{
		// switch statement - set the active duo member depending on which button this is.
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour {

	public int selectedMove;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActivateMove(){
		// come up with code to do the highlighting and stuff
		// add code to select enemies / teammates for move effects
	}

	public void MoveResults()
	{
		if (GameManager.manager.activeDuo[GameManager.manager.activePlayer].moveSet[selectedMove].isAttack) {
			// do damage here to selected enemies
		} else if (!GameManager.manager.activeDuo[GameManager.manager.activePlayer].moveSet[selectedMove].isAttack) {
			// do healing here to selected teammate (self, or other, or both)
		}
	}
}

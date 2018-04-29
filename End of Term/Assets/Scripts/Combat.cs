using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour {

	public int moveIndex;
	public Move selectedMove;

	public static Combat combat;

	// Use this for initialization
	void Awake () {
		if (combat == null) {
			combat = this;
		}
	}

	public void RunCombat(int moveClicked)
	{
		moveIndex = moveClicked - 1;

		selectedMove = GameManager.manager.activeDuo [GameManager.manager.activePlayer].moveSet [moveIndex];
	}

	public void TargetPeople()
	{
		if(selectedMove.targetCount == 1)
	}

	public void ActivateMove()
	{
		// come up with code to do the highlighting and stuff
		// add code to select enemies / teammates for move effects
	}

	public void MoveResults()
	{
		if (selectedMove.isAttack) {
			// do damage here to selected enemies
		} 
		else if (!selectedMove.isAttack) 
		{
			// do healing here to selected teammate (self, or other, or both)
		}
	}
}

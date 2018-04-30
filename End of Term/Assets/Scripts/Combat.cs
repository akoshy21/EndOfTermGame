using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Combat : MonoBehaviour {

	public Move selectedMoveP0;
	public Move selectedMoveP1;
	public Move selectedMoveE0;
	public Move selectedMoveE1;
	public Move selectedMoveE2;

	public Move currentMove;

	public int damageMultiplier;

	public static Combat combat;

	public Character[] combatOrder;
	public SortStuff speedSort;

	public int target = 0;

	public Button bP0, bP1, bE0, bE1, bE2;
	public int buttonNum;

	// Use this for initialization
	void Awake () {
		if (combat == null) {
			combat = this;
		}
	}

	void Start()
	{
		combatOrder = new Character[5];
		speedSort = new SortStuff();

		bP0.onClick.AddListener(TargetPeople);
		bP1.onClick.AddListener(TargetPeople);
		bE0.onClick.AddListener(TargetPeople);
		bE1.onClick.AddListener(TargetPeople);
		bE2.onClick.AddListener(TargetPeople);
	}

	void TestMove(int clicked)
	{
		// add similar script to whats below
	}

	public void AddMoves(int moveClicked)
	{
		target = 0;

		switch (GameManager.manager.curTurn) {
		case GameManager.CurrentTurn.ActiveDuo0:
			selectedMoveP0 = GameManager.manager.activeDuo [0].moveSet [moveClicked - 1];
			return;
		case GameManager.CurrentTurn.ActiveDuo1:
			selectedMoveP1 = GameManager.manager.activeDuo [1].moveSet [moveClicked - 1];
			return;
		case GameManager.CurrentTurn.Enemy0:
			selectedMoveE0 = GameManager.manager.enemies [0].moveSet [moveClicked - 1];
			return;
		case GameManager.CurrentTurn.Enemy1:
			selectedMoveE1 = GameManager.manager.enemies [1].moveSet [moveClicked - 1];
			return;
		case GameManager.CurrentTurn.Enemy2:
			selectedMoveE2 = GameManager.manager.enemies [2].moveSet [moveClicked - 1];
			return;
		default:
			return;
		}
	}

	public void TargetPeople()
	{
		target++;

		switch (buttonNum) {
		case 1:
			
			return;
		default:
			return;
		}
	}

	public void ActivateMove()
	{
		// come up with code to do the highlighting and stuff
		// add code to select enemies / teammates for move effects
	}

	public void ActivateTargeting()
	{
		Debug.Log (currentMove.isAttack);
		if (currentMove.isAttack == true) {
			bP0.gameObject.SetActive (false);
			bP1.gameObject.SetActive (false);
			bE0.gameObject.SetActive (true);
			bE1.gameObject.SetActive (true);
			bE2.gameObject.SetActive (true);
		} else if (currentMove.isAttack == false) {
			bP0.gameObject.SetActive (true);
			bP1.gameObject.SetActive (true);
			bE0.gameObject.SetActive (false);
			bE1.gameObject.SetActive (false);
			bE2.gameObject.SetActive (false);
		}
	}

	public void MoveResults()
	{

			// do healing here to selected teammate (self, or other, or both)
	}

	public void HealOrHurt()
	{
		//		damage = ((GameManager.manager.activeDuo [GameManager.manager.activePlayer].attack * selectedMove.power) / (target.defense * 4)) * damageMultiplier;
	}

	public void SortSpeeds()
	{
		combatOrder [0] = GameManager.manager.activeDuo [0];
		combatOrder [1] = GameManager.manager.activeDuo [1];
		combatOrder [2] = GameManager.manager.enemies [0];
		combatOrder [3] = GameManager.manager.enemies [1];
		combatOrder [4] = GameManager.manager.enemies [2];

		Array.Sort (combatOrder, speedSort);

		for(int j = 0; j < combatOrder.Length; j++)
		{
			Debug.Log(combatOrder[j].characterName + " " + combatOrder[j].speed + " " + j);
		}
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Combat : MonoBehaviour {


	public Move[] selectedMove;

	public Move currentMove;

	public int damageMultiplier;

	public static Combat combat;

	public Character[] combatOrder;
	public SortStuff speedSort;
	public SortMoves sortM;

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
		selectedMove = new Move[5];

		sortM = new SortMoves ();
		speedSort = new SortStuff();

		for (int i = 0; i < 5; i++) {
			selectedMove [i] = new Move ("", "", 0, false, 0, 0, false, InitScript.roster.characters [0]);
		}

		bP0.onClick.AddListener (delegate{TargetPeople(0, bP0);});
		bP1.onClick.AddListener (delegate{TargetPeople(1, bP1);});
		bE0.onClick.AddListener (delegate{TargetPeople(0, bE0);});
		bE1.onClick.AddListener (delegate{TargetPeople(1, bE1);});
		bE2.onClick.AddListener (delegate{TargetPeople(2, bE2);});
	}

	public void AddMoves(int moveClicked)
	{
		switch (GameManager.manager.curTurn) {
		case GameManager.CurrentTurn.ActiveDuo0:
			selectedMove[0] = GameManager.manager.activeDuo [0].moveSet [moveClicked - 1];
			if (Combat.combat.currentMove.targetCount == 2 && Combat.combat.currentMove.isAttack == false) {
				selectedMove[0].target [0] = GameManager.manager.activeDuo[0];
				selectedMove[0].target [1] = GameManager.manager.activeDuo[1];

			}
			else if (Combat.combat.currentMove.targetCount == 3 && Combat.combat.currentMove.isAttack == true) {
				selectedMove[0].target [0] = GameManager.manager.enemies[0];
				selectedMove[0].target [1] = GameManager.manager.enemies[1];
				selectedMove[0].target [2] = GameManager.manager.enemies[2];

			}
			return;
		case GameManager.CurrentTurn.ActiveDuo1:
			selectedMove [1] = GameManager.manager.activeDuo [1].moveSet [moveClicked - 1];
			if (Combat.combat.currentMove.targetCount == 2 && Combat.combat.currentMove.isAttack == false) {
				selectedMove[1].target [0] = GameManager.manager.activeDuo[0];
				selectedMove[1].target [1] = GameManager.manager.activeDuo[1];
				}
			else if (Combat.combat.currentMove.targetCount == 3 && Combat.combat.currentMove.isAttack == true) {
				selectedMove[1].target [0] = GameManager.manager.enemies[0];
				selectedMove[1].target [1] = GameManager.manager.enemies[1];
				selectedMove[1].target [2] = GameManager.manager.enemies[2];
				}
			return;
		case GameManager.CurrentTurn.Enemy0:
			selectedMove[2] = GameManager.manager.enemies [0].moveSet [moveClicked - 1];
			return;
		case GameManager.CurrentTurn.Enemy1:
			selectedMove[3] = GameManager.manager.enemies [1].moveSet [moveClicked - 1];
			return;
		case GameManager.CurrentTurn.Enemy2:
			selectedMove[4] = GameManager.manager.enemies [2].moveSet [moveClicked - 1];
			return;
		default:
			return;
		}
	}

	public void TargetPeople(int bNum, Button bt)
	{
		target++;

		switch (GameManager.manager.curTurn) {
		case GameManager.CurrentTurn.ActiveDuo0:
			if (selectedMove [0].isAttack) {
				selectedMove [0].target [target-1] = GameManager.manager.enemies [bNum];
				Debug.Log (target);
			}
			bt.interactable = false;
			break;
		case GameManager.CurrentTurn.ActiveDuo1:
			if (selectedMove [1].isAttack) {
				selectedMove [1].target [target-1] = GameManager.manager.enemies [bNum];
			}
			Debug.Log (selectedMove [1].target [target-1].characterName);
			bt.interactable = false;
			break;
		default:
			break;
		}

		if (target == currentMove.targetCount) {
			switch (GameManager.manager.curTurn) {
			case GameManager.CurrentTurn.ActiveDuo0:
				GameManager.manager.curTurn = GameManager.CurrentTurn.ActiveDuo1;
				ResetState ();
				return;
			case GameManager.CurrentTurn.ActiveDuo1:
				GameManager.manager.curTurn = GameManager.CurrentTurn.Enemy0;
				ResetState ();
				return;
			default:
				return;
			}
		}
	}

	public void ActivateMove()
	{
		// come up with code to do the highlighting and stuff
		// add code to select enemies / teammates for move effects
	}

	public void ActivateTargeting()
	{
		//Debug.Log (currentMove.isAttack);
		if (currentMove.isAttack == true) {
			bP0.gameObject.SetActive (false);
			bP1.gameObject.SetActive (false);
			bE0.gameObject.SetActive (true);
			bE1.gameObject.SetActive (true);
			bE2.gameObject.SetActive (true);
			bE0.interactable = true;
			bE1.interactable = true;
			bE2.interactable = true;
		} else if (currentMove.isAttack == false) {
			bP0.gameObject.SetActive (true);
			bP1.gameObject.SetActive (true);
			bP0.interactable = true;
			bP1.interactable = true;
			bE0.gameObject.SetActive (false);
			bE1.gameObject.SetActive (false);
			bE2.gameObject.SetActive (false);
		}
	}

	public void ResetState()
	{
		target = 0;
		GameManager.manager.turnstate = GameManager.TurnState.Menu;
	}

	public void MoveResults()
	{
		SortMoveSpeeds();

		for(int i = 0; i < 5; i++)
		{
			if (selectedMove [i].isAttack) {
				if (selectedMove [i].isPhysical) {
					for (int j = 0; j < selectedMove [i].targetCount; j++) {
						// rilee fix the math
						selectedMove [i].target [j].currentHealth -= (selectedMove [i].caster.attack * selectedMove [i].power) / (selectedMove [i].target [j].defense * 4);
						Debug.Log (selectedMove [i].target [j].currentHealth);
						UpdateCharStatus (selectedMove [i].target [j]);
						Debug.Log (i + ": " + GameManager.manager.enemies [j].characterName);
					}
				} else if (!selectedMove [i].isPhysical) {
					for (int j = 0; j < selectedMove [i].targetCount; j++) {
						selectedMove [i].target [j].currentHealth -= (selectedMove [i].caster.spAttack * selectedMove [i].power) / (selectedMove [i].target [j].spDefense * 4);
						UpdateCharStatus (selectedMove [i].target [j]);
					}
				}
			} else if (selectedMove [i].effectIndex != 0 && selectedMove[i].isAttack == false) {
				for (int j = 0; j < selectedMove [i].targetCount; j++) {
					selectedMove [i].target [j].currentHealth += selectedMove [i].caster.spAttack * (selectedMove [i].power / 100);
				}
			}
		}
	}

	public void UpdateCharStatus(Character c)
	{
		if (c.isEnemy == true) {
			for (int i = 0; i < 3; i++) {
				if (c.RID == GameManager.manager.enemies [i].RID) {
					GameManager.manager.enemies [i] = c;
				}
			}
		} else {
			for (int i = 0; i < 2; i++) {
				if (c.RID == GameManager.manager.activeDuo [i].RID) {
					GameManager.manager.activeDuo [i] = c;
				}
			}
		}
	}

	public void SortCharSpeeds()
	{
		combatOrder [0] = GameManager.manager.activeDuo [0];
		combatOrder [1] = GameManager.manager.activeDuo [1];
		combatOrder [2] = GameManager.manager.enemies [0];
		combatOrder [3] = GameManager.manager.enemies [1];
		combatOrder [4] = GameManager.manager.enemies [2];

		Array.Sort (combatOrder, speedSort);

//		for(int j = 0; j < combatOrder.Length; j++)
//		{
//			Debug.Log(combatOrder[j].characterName + " " + combatOrder[j].speed + " " + j);
//		}
	}

	public void SortMoveSpeeds()
	{
		Array.Sort (selectedMove, sortM);

//		for(int k = 0; k < selectedMove.Length; k++)
//		{
//			Debug.Log(selectedMove[k].description);
//		}
	}
}
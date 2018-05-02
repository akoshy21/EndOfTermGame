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
			Debug.Log (i);
		}

		bP0.onClick.AddListener (delegate{TargetPeople(0, bP0);});
		bP1.onClick.AddListener (delegate{TargetPeople(1, bP1);});
		bE0.onClick.AddListener (delegate{TargetPeople(0, bE0);});
		bE1.onClick.AddListener (delegate{TargetPeople(1, bE1);});
		bE2.onClick.AddListener (delegate{TargetPeople(2, bE2);});
	}

	void Update()
	{
		Debug.Log (selectedMove.Length);
		for (int i = 0; i < 5; i++) {
			Debug.Log (selectedMove .Length);
		}
		EnemyTurns ();
	}

	public void AddMoves(int moveClicked)
	{

        switch (GameManager.manager.curTurn) {
		case GameManager.CurrentTurn.ActiveDuo0:
			selectedMove[0] = GameManager.manager.activeDuo [0].moveSet [moveClicked - 1];
                if (Combat.combat.currentMove.targetCount == 2 && Combat.combat.currentMove.isAttack == false)
                {
                    selectedMove[0].target[0] = GameManager.manager.activeDuo[0];
                    selectedMove[0].target[1] = GameManager.manager.activeDuo[1];
                    GameManager.manager.activeDuo[0].currentMP -= selectedMove[0].cost;

                }
                else if (Combat.combat.currentMove.targetCount == 3 && Combat.combat.currentMove.isAttack == true)
                {
                    selectedMove[0].target[0] = GameManager.manager.enemies[0];
                    selectedMove[0].target[1] = GameManager.manager.enemies[1];
                    selectedMove[0].target[2] = GameManager.manager.enemies[2];
                    GameManager.manager.activeDuo[0].currentMP -= selectedMove[0].cost;

                }
                else if (Combat.combat.currentMove.targetCount == 0)
                {
                    selectedMove[0].target[0] = GameManager.manager.activeDuo[0];
                    GameManager.manager.activeDuo[0].currentMP -= selectedMove[0].cost;
                }
			return;
		case GameManager.CurrentTurn.ActiveDuo1:
			selectedMove [1] = GameManager.manager.activeDuo [1].moveSet [moveClicked - 1];
			if (Combat.combat.currentMove.targetCount == 2 && Combat.combat.currentMove.isAttack == false) {
				selectedMove[1].target [0] = GameManager.manager.activeDuo[0];
				selectedMove[1].target [1] = GameManager.manager.activeDuo[1];
                GameManager.manager.activeDuo[1].currentMP -= selectedMove[1].cost;
                }
			else if (Combat.combat.currentMove.targetCount == 3 && Combat.combat.currentMove.isAttack == true) {
				selectedMove[1].target [0] = GameManager.manager.enemies[0];
				selectedMove[1].target [1] = GameManager.manager.enemies[1];
				selectedMove[1].target [2] = GameManager.manager.enemies[2];
                GameManager.manager.activeDuo [1].currentMP -= selectedMove [1].cost;
				}
                else if (Combat.combat.currentMove.targetCount == 0)
                {
                    selectedMove[1].target[0] = GameManager.manager.activeDuo[1];
                    GameManager.manager.activeDuo[1].currentMP -= selectedMove[1].cost;
                }
                return;
            default:
			return;
		}
	}

	void EnemyTurns()
	{
		Debug.Log (GameManager.manager.curTurn);
		switch (GameManager.manager.curTurn) {
		case GameManager.CurrentTurn.Enemy0:
				EnemyAI.enemyai.gordon = true;
				EnemyAI.enemyai.burgess = false;
			return;
		case GameManager.CurrentTurn.Enemy1:
				EnemyAI.enemyai.gordon = false;
				EnemyAI.enemyai.burgess = true;
			return;
		case GameManager.CurrentTurn.Enemy2:
				EnemyAI.enemyai.gordon = true;
				EnemyAI.enemyai.burgess = false;
			return;
		default:
                EnemyAI.enemyai.gordon = false;
                EnemyAI.enemyai.burgess = false;
                return;
		}
	}

	public void TargetPeople(int bNum, Button bt)
	{
		target++;
            switch (GameManager.manager.curTurn)
            {
                case GameManager.CurrentTurn.ActiveDuo0:
                    if (selectedMove[0].isAttack)
                    {
                        selectedMove[0].target[target - 1] = GameManager.manager.enemies[bNum];
                        Debug.Log(target);
                    }
                    else if (!selectedMove[0].isAttack)
                    {
                        selectedMove[0].target[target - 1] = GameManager.manager.activeDuo[bNum];
                    }
                    bt.interactable = false;
                    break;
                case GameManager.CurrentTurn.ActiveDuo1:
                    if (selectedMove[1].isAttack)
                    {
                        selectedMove[1].target[target - 1] = GameManager.manager.enemies[bNum];
                    }
                    else if (!selectedMove[1].isAttack)
                    {
                        selectedMove[1].target[target - 1] = GameManager.manager.activeDuo[bNum];
                    }
                    // Debug.Log (selectedMove [1].target [target-1].characterName);
                    bt.interactable = false;
                    break;
                default:
                    break;
            }

		switch (GameManager.manager.curTurn) {
		case GameManager.CurrentTurn.ActiveDuo0:
			if (selectedMove [0].isAttack) {
				selectedMove [0].target [target - 1] = GameManager.manager.enemies [bNum];
				Debug.Log (target);
			} else if (!selectedMove [0].isAttack) {
				selectedMove [0].target [target - 1] = GameManager.manager.activeDuo [bNum];
			}
			bt.interactable = false;
			break;
		case GameManager.CurrentTurn.ActiveDuo1:
			if (selectedMove [1].isAttack) {
				selectedMove [1].target [target-1] = GameManager.manager.enemies [bNum];
			} else if (!selectedMove [1].isAttack) {
				selectedMove [1].target [target - 1] = GameManager.manager.activeDuo [bNum];
			}
			// Debug.Log (selectedMove [1].target [target-1].characterName);
			bt.interactable = false;
			break;
		default:
			break;
		}

		if (target == currentMove.targetCount) {
			switch (GameManager.manager.curTurn) {
			case GameManager.CurrentTurn.ActiveDuo0:
				GameManager.manager.activeDuo [0].currentMP -= selectedMove [0].cost;
				GameManager.manager.TurnEnd ("C, 191");
				return;
			case GameManager.CurrentTurn.ActiveDuo1:
				GameManager.manager.activeDuo [1].currentMP -= selectedMove [1].cost;
				GameManager.manager.TurnEnd ("C, 195");
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
						Debug.Log (i + ": " + GameManager.manager.enemies [j].characterName);

						selectedMove [i].target [j].currentHealth -= (selectedMove [i].caster.attack * selectedMove [i].power) / (selectedMove [i].target [j].defense * 4);
						Debug.Log (selectedMove [i].target [j].currentHealth);
						UpdateCharStatus (selectedMove [i].target [j]);
					}
				} else if (!selectedMove [i].isPhysical) {
					for (int j = 0; j < selectedMove [i].targetCount; j++) {
						selectedMove [i].target [j].currentHealth -= (selectedMove [i].caster.spAttack * selectedMove [i].power) / (selectedMove [i].target [j].spDefense * 4);
						UpdateCharStatus (selectedMove [i].target [j]);
					}
				}
			} else if (selectedMove [i].effectIndex == 1) {
				for (int j = 0; j < selectedMove [i].targetCount; j++) {
					Debug.Log ("HI " + selectedMove[i].target[j].characterName);
					selectedMove [i].target [j].currentHealth += selectedMove [i].caster.spAttack * (selectedMove [i].power / 100);
					if (selectedMove [i].target [j].currentHealth >= selectedMove [i].target [j].maxHealth) {
						selectedMove [i].target [j].currentHealth = selectedMove [i].target [j].maxHealth;
					}
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
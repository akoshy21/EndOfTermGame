using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.manager.curTurn == GameManager.CurrentTurn.Enemy0) {
			Debug.Log ("HERE");

			Combat.combat.selectedMove [2] = Combat.combat.selectedMove [1];
			Combat.combat.selectedMove [3] = Combat.combat.selectedMove [1];
			Combat.combat.selectedMove [4] = Combat.combat.selectedMove [1];

			GameManager.manager.TurnEnd ();
		}
	}
}

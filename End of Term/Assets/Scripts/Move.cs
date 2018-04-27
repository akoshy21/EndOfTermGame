using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move {

	public int targetCount;
	public bool targetIsEnemy;
	public int power;
	public int cost;

	public bool isAttack;

	public string description;
	public string name;

	// possible animation set here.
	// possible voice line

	// make spells range of damage/heal

	public Move(string attackName, string desc, int targetNum, bool hitsEnemy, int pow, int manaCost, bool attack)
	{
		name = attackName;
		targetCount = targetNum;
		targetIsEnemy = hitsEnemy;
		power = pow;
		cost = manaCost;
		description = desc;
		isAttack = attack;
	}
}

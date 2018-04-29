using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move {

	public int targetCount;
	public int power;
	public int cost;

	public bool isAttack;

	public string description;
	public string name;

	// possible animation set here.
	// possible voice line

	// make spells range of damage/heal

	public Move(string attackName, string desc, int targetNum, bool boolIsAttack, int pow, int manaCost)
	{
		name = attackName;
		targetCount = targetNum;
		isAttack = boolIsAttack;
		power = pow;
		cost = manaCost;
		description = desc;
	}
}

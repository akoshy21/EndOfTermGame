using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move {

	public int targetCount;
	public int power;
	public int cost;

	public bool isAttack;
	public bool isPhysical;

	public string description;
	public string name;

	public Character[] target = new Character[3];

	public int effectIndex;

	public Character caster;

	// possible animation set here.
	// possible voice line

	// make spells range of damage/heal

	public Move(string attackName, string desc, int targetNum, bool boolIsAttack, int pow, int manaCost, bool isPhys, Character cast, int eI = 1)
	{
		name = attackName;
		targetCount = targetNum;
		isAttack = boolIsAttack;
		power = pow;
		cost = manaCost;
		description = desc;
		caster = cast;

		isPhysical = isPhys;

		effectIndex = eI;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifiers {

	public int speedMod;
	public int damageMod;

	public int shield;

	public bool stunned;
	public bool shielded;

	public Modifiers(bool stun, bool shieldBool, int shieldInt = 0, int damage = 0, int speed = 0)
	{
		speedMod = speed;
		damageMod = damage;

		shield = shieldInt;

		stunned = stun;
		shielded = shieldBool;
	}
}

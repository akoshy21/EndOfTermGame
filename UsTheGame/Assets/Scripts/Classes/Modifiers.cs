using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifiers {

	public float speedMod;
	public float damageMod;

	public int shield;

	public bool stunned;
	public bool shielded;

	public string modDesc;

	public int timer;

	public Modifiers(bool stun, bool shieldBool, int shieldInt = 0, float damage = 0, float speed = 0, int time = 1, string description = null)
	{
		speedMod = speed;
		damageMod = damage;

		shield = shieldInt;

		stunned = stun;
		shielded = shieldBool;
	
		timer = time;

		modDesc = description;
	}

}

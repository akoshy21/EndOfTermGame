using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character {

	public string characterName;

	// stats
	public int attack;
	public int defense;
	public int spAttack;
	public int spDefense;

	public int maxHealth;
	public int currentHealth;

	public int maxMP;
	public int currentMP;

	public int speed;

	public Sprite portrait;
	public Sprite charSprite;

	public Move[] moveSet = new Move[4];

	public Modifiers[] mods = new Modifiers[10];

	public Character (Sprite p = null, Sprite cs = null, string cn = null, int a = 0, int d = 0, int sa = 0, int sd = 0, int s = 10)
	{
		attack = a;
		defense = d;
		spAttack = sa;
		spDefense = sd;

		characterName = cn;

		portrait = p;
		charSprite = cs;

		speed = s;

		maxHealth = (defense*spDefense)/10;
		maxMP = (attack*spAttack)/10;
	}
}

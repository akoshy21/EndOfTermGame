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

	public int RID;

	public bool isEnemy;

	public int shield;
	public int shieldMax;

	public Sprite portrait;
	public Sprite charSprite;

	public Move[] moveSet = new Move[4];

	public Modifiers[] mods = new Modifiers[4];

	public Character (Sprite p = null, Sprite cs = null, string cn = null, int a = 0, int d = 0, int sa = 0, int sd = 0, int s = 10, bool isEn = false, int sh = 0)
	{
		attack = a;
		defense = d;
		spAttack = sa;
		spDefense = sd;

		characterName = cn;

		portrait = p;
		charSprite = cs;

		speed = s;

		shield = sh;

		maxHealth = (defense*spDefense)/10;
		currentHealth = maxHealth;
		maxMP = (spDefense*spAttack)/10;
		currentMP = maxMP;

		isEnemy = isEn;

		RID = GameManager.manager.charID;
		GameManager.manager.charID++;
	}

	public Character(Character copy)
	{

		attack = copy.attack;
		defense = copy.defense;
		spAttack = copy.spAttack;
		spDefense = copy.spDefense;

		characterName = copy.characterName;

		portrait = copy.portrait;
		charSprite = copy.charSprite;

		speed = copy.speed;

		maxHealth = copy.maxHealth;
		currentHealth = copy.maxHealth;
		maxMP = copy.currentMP;
		currentMP = copy.maxMP;

		isEnemy = copy.isEnemy;

		mods = copy.mods;
		moveSet = copy.moveSet;

		shield = copy.shield;

		RID = GameManager.manager.charID;
		GameManager.manager.charID++;
	}
}

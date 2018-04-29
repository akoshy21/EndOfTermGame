﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitScript : MonoBehaviour {

	public static InitScript roster;

	public Sprite anna;
	public Sprite annaSp;

	public Sprite cindy;
	public Sprite cindySp;

	public Sprite rilee;
	public Sprite rileeSp;

	public Sprite luke;
	public Sprite lukeSp;

	public Sprite burgessSp;
	public Sprite gordonSp;

	public Character[] characters;

	// Use this for initialization
	void Awake () {
		// make this static script if there isnt one already
		if (roster == null) {
			roster = this;
		}

		// create character array
		characters = new Character[6];


		// create characters and movesets
		characters [0] = new Character (anna, annaSp, "Annamaria", 12, 10, 20, 15);
		characters [0].moveSet [0] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, false);

		characters [1] = new Character (cindy, cindySp, "Cindy", 10, 17, 13, 17);

		characters [2] = new Character (luke, lukeSp, "Luke", 17, 13, 17, 10);

		characters [3] = new Character (rilee, rileeSp, "Rilee", 10, 12, 20, 15);

		characters [4] = new Character (null, burgessSp, "Burgess", 10, 12, 20, 15);

		characters [5] = new Character (null, gordonSp, "Gordon", 10, 12, 20, 15);

		GameManager.manager.MakeTheTeam ();
	}
	
	// Update is called once per frame
	void Start () {
		
	}

		
	void Update()
	{
	}
}

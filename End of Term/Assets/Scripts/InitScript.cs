using System.Collections;
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
		MakeCharacters ();

	}
	
	void MakeCharacters()
	{
		// create character array
		characters = new Character[6];
		Effects.index.InitializeIndex ();

        //string attackName, string desc, int targetNum, bool boolIsAttack, int pow, int manaCost, bool isPhys, Character cast, int eI = 1, bool buff = false
        // create characters and movesets
        characters[0] = new Character (anna, annaSp, "Annamaria", 14, 10, 20, 15, 14);
        characters[0].maxHealth *= 2;
        characters[0].currentHealth = characters[0].maxHealth;
        characters [0].moveSet [0] = new Move ("Hack()", "blah blah", 1, true, 15, 0, true, characters [0]);
		characters [0].moveSet [1] = new Move ("Restore()", "blah blah", 1, false, 50, 4, false, characters [0],1);
		characters [0].moveSet [2] = new Move ("Soft_Reset()", "blah blah", 1, false, 0, 3, false, characters [0], 2, true);
		characters [0].moveSet [3] = new Move ("Upgrade()", "blah blah", 2, false, 0, 6, false, characters[0], 3, true);
		for (int i = 0; i < 4; i++) {
			characters [0].mods [i] = Effects.index.effectIndex [0];
		}

		characters [1] = new Character (cindy, cindySp, "Cindy", 13, 17, 10, 17, 10);
        characters[1].maxHealth *= 2;
        characters[1].currentHealth = characters[1].maxHealth;
        characters [1].moveSet [0] = new Move ("Slam", "blah blah", 1, true, 25, 0, true, characters [1]);
		characters [1].moveSet [1] = new Move ("Charge", "blah blah", 3, true, 20, 1, true, characters[1]);
		characters [1].moveSet [2] = new Move ("Shield", "blah blah", 0, false, 0, 4, false, characters[1], 4, true);
		characters [1].moveSet [3] = new Move ("Intervene", "blah blah", 1, false, 0, 2, false, characters[1], 5, true);
		for (int i = 0; i < 4; i++) {
			characters [1].mods [i] = Effects.index.effectIndex [0];
		}

		characters [2] = new Character (luke, lukeSp, "Luke", 18, 13, 12, 10, 17);
        characters[2].maxHealth *= 2;
        characters[2].currentHealth = characters[2].maxHealth;
        characters [2].moveSet [0] = new Move ("Smash", "blah blah", 1, true, 30, 0, true, characters [2]);
		characters [2].moveSet [1] = new Move ("Self-Inspire", "blah blah", 0, false, 0, 2, false, characters[2], 6, true);
		characters [2].moveSet [2] = new Move ("Chord of Shards", "blah blah", 3, true, 50, 10, false, characters[2]);
		characters [2].moveSet [3] = new Move ("Deafen", "blah blah", 1, true, 10, 0, true, characters[2], 7, true);
		for (int i = 0; i < 4; i++) {
			characters [2].mods [i] = Effects.index.effectIndex [0];
		}

		characters [3] = new Character (rilee, rileeSp, "Rilee", 14, 12, 18, 15, 14);
        characters[3].maxHealth *= 2;
        characters[3].currentHealth = characters[3].maxHealth;
        characters [3].moveSet [0] = new Move ("Firebolt", "blah blah", 1, true, 40, 4, false, characters[3]);
        characters [3].moveSet [1] = new Move ("Drain", "blah blah", 1, true, 0, -4, false, characters[3], 8);
        characters [3].moveSet [2] = new Move("Petrify", "blah blah", 1, true, 0, 8, false, characters[3], 9, true);
        characters [3].moveSet [3] = new Move("Mana Exchange", "blah blah", 1, false, 0, 4, false, characters[3], 10);
		for (int i = 0; i < 4; i++) {
			characters [3].mods [i] = Effects.index.effectIndex [0];
		}

		characters [4] = new Character (null, burgessSp, "Burgess", 10, 15, 20, 17, 18, true);
        characters[4].maxHealth *= 3;
        characters[4].currentHealth = characters[4].maxHealth;
        characters [4].moveSet [0] = new Move ("Default Attack", "blah blah", 1, true, 30, 0, true, characters[4]);
		characters [4].moveSet [1] = new Move ("NoPlaceSwap", "blah blah", 1, true, 0, 5, false, characters[4], 11);
		characters [4].moveSet [2] = new Move ("Shield", "blah blah", 0, false, 0, 15, false, characters[4], 12, true);
		characters [4].moveSet [3] = new Move ("Juice", "blah blah", 2, true, 15, 3, false, characters[4]);
		for (int i = 0; i < 4; i++) {
			characters [4].mods [i] = Effects.index.effectIndex [0];
		}

		characters [5] = new Character (null, gordonSp, "Gordon", 16, 12, 14, 15, 13, true);
		characters [5].moveSet [0] = new Move ("Default Attack", "blah blah", 1, true, 15, 0, false, characters[5]);
		characters [5].moveSet [1] = new Move ("Restore()", "blah blah", 1, false, 50, 4, false, characters[0], 1);
		characters [5].moveSet [2] = new Move ("Fuel Mana", "blah blah", 1, false, 0, 4, false, characters[5], 8);
		characters [5].moveSet [3] = new Move ("Sacrifice", "blah blah", 2, true, 40, 0, true, characters[5], 13);
		for (int i = 0; i < 4; i++) {
			characters [5].mods [i] = Effects.index.effectIndex [0];
		}

		GameManager.manager.MakeTheTeam ();
	}
}
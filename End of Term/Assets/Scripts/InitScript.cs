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
	public Modifiers[] modifiers;

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


		// create characters and movesets
		characters [0] = new Character (anna, annaSp, "Annamaria", 14, 10, 20, 15, 14);
		characters [0].moveSet [0] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [0].moveSet [1] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [0].moveSet [2] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [0].moveSet [3] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);

		characters [1] = new Character (cindy, cindySp, "Cindy", 13, 17, 10, 17, 10);
		characters [1].moveSet [0] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [1].moveSet [1] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [1].moveSet [2] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [1].moveSet [3] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);

		characters [2] = new Character (luke, lukeSp, "Luke", 18, 13, 12, 10, 17);
		characters [2].moveSet [0] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [2].moveSet [1] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [2].moveSet [2] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [2].moveSet [3] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);

		characters [3] = new Character (rilee, rileeSp, "Rilee", 14, 12, 18, 15, 14);
		characters [3].moveSet [0] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [3].moveSet [1] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [3].moveSet [2] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [3].moveSet [3] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);

		characters [4] = new Character (null, burgessSp, "Burgess", 10, 12, 20, 15, 18);
		characters [4].moveSet [0] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [4].moveSet [1] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [4].moveSet [2] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [4].moveSet [3] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);

		characters [5] = new Character (null, gordonSp, "Gordon", 10, 12, 20, 15, 13);
		characters [5].moveSet [0] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [5].moveSet [1] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [5].moveSet [2] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);
		characters [5].moveSet [3] = new Move ("Multi-Heal", "blah blah", 2, false, 3, 3, characters[0].speed);

		GameManager.manager.MakeTheTeam ();
	}

	void MakeMods()
	{
		modifiers = new Modifiers[20];

		modifiers[0] = new Modifiers(false, false);
	}
}

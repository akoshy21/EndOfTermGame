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


		// create characters and movesets
		characters [0] = new Character (anna, annaSp, "Annamaria", 14, 10, 20, 15, 14);
		characters [0].moveSet [0] = new Move ("Hack()", "blah blah", 1, true, 40, 0, true, characters [0].speed, 0);
		characters [0].moveSet [1] = new Move ("Restore()", "blah blah", 1, false, 50, 4, false, characters[0].speed, 0);
		characters [0].moveSet [2] = new Move ("Soft_Reset()", "blah blah", 1, false, 0, 3, false, characters[0].speed, 1);
		characters [0].moveSet [3] = new Move ("Upgrade()", "blah blah", 2, false, 0, 6, false, characters[0].speed, 2);

		characters [1] = new Character (cindy, cindySp, "Cindy", 13, 17, 10, 17, 10);
		characters [0].moveSet [0] = new Move ("Hack()", "blah blah", 1, true, 40, 0, true, characters [0].speed, 0);
		characters [0].moveSet [1] = new Move ("Restore()", "blah blah", 1, false, 50, 4, false, characters[0].speed, 0);
		characters [0].moveSet [2] = new Move ("Soft_Reset()", "blah blah", 1, false, 0, 3, false, characters[0].speed, 1);
		characters [0].moveSet [3] = new Move ("Upgrade()", "blah blah", 2, false, 0, 6, false, characters[0].speed, 2);

		characters [2] = new Character (luke, lukeSp, "Luke", 18, 13, 12, 10, 17);
		characters [0].moveSet [0] = new Move ("Hack()", "blah blah", 1, true, 40, 0, true, characters [0].speed, 0);
		characters [0].moveSet [1] = new Move ("Restore()", "blah blah", 1, false, 50, 4, false, characters[0].speed, 0);
		characters [0].moveSet [2] = new Move ("Soft_Reset()", "blah blah", 1, false, 0, 3, false, characters[0].speed, 1);
		characters [0].moveSet [3] = new Move ("Upgrade()", "blah blah", 2, false, 0, 6, false, characters[0].speed, 2);

		characters [3] = new Character (rilee, rileeSp, "Rilee", 14, 12, 18, 15, 14);
		characters [0].moveSet [0] = new Move ("Hack()", "blah blah", 1, true, 40, 0, true, characters [0].speed, 0);
		characters [0].moveSet [1] = new Move ("Restore()", "blah blah", 1, false, 50, 4, false, characters[0].speed, 0);
		characters [0].moveSet [2] = new Move ("Soft_Reset()", "blah blah", 1, false, 0, 3, false, characters[0].speed, 1);
		characters [0].moveSet [3] = new Move ("Upgrade()", "blah blah", 2, false, 0, 6, false, characters[0].speed, 2);

		characters [4] = new Character (null, burgessSp, "Burgess", 10, 12, 20, 15, 18);
		characters [0].moveSet [0] = new Move ("Hack()", "blah blah", 1, true, 40, 0, true, characters [0].speed, 0);
		characters [0].moveSet [1] = new Move ("Restore()", "blah blah", 1, false, 50, 4, false, characters[0].speed, 0);
		characters [0].moveSet [2] = new Move ("Soft_Reset()", "blah blah", 1, false, 0, 3, false, characters[0].speed, 1);
		characters [0].moveSet [3] = new Move ("Upgrade()", "blah blah", 2, false, 0, 6, false, characters[0].speed, 2);

		characters [5] = new Character (null, gordonSp, "Gordon", 10, 12, 20, 15, 13);
		characters [0].moveSet [0] = new Move ("Hack()", "blah blah", 1, true, 40, 0, true, characters [0].speed, 0);
		characters [0].moveSet [1] = new Move ("Restore()", "blah blah", 1, false, 50, 4, false, characters[0].speed, 0);
		characters [0].moveSet [2] = new Move ("Soft_Reset()", "blah blah", 1, false, 0, 3, false, characters[0].speed, 1);
		characters [0].moveSet [3] = new Move ("Upgrade()", "blah blah", 2, false, 0, 6, false, characters[0].speed, 2);

		GameManager.manager.MakeTheTeam ();
	}

}
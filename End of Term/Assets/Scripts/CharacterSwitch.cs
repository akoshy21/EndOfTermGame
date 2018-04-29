using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitch : MonoBehaviour {

	// character name text objects
	public Text Char1;
	public Text Char2;
	public Text Char3;
	public Text Char4;

	// character stats text objects
	public Text Char1stats;
	public Text Char2stats;
	public Text Char3stats;
	public Text Char4stats;

	// character portrait images
	public Image char1portrait;
	public Image char2portrait;
	public Image char3portrait;
	public Image char4portrait;

	// character selected images (the red squares)
	public GameObject selected1;
	public GameObject selected2;
	public GameObject selected3;
	public GameObject selected4;

	// character select buttons
	public Button b1;
	public Button b2;
	public Button b3;
	public Button b4;

	// Use this for initialization
	void Start () {

		// set the characters' name field to their name
		Char1.text = GameManager.manager.team [0].characterName;
		Char2.text = GameManager.manager.team [1].characterName;
		Char3.text = GameManager.manager.team [2].characterName;
		Char4.text = GameManager.manager.team [3].characterName;

		// fills the character description
		Char1stats.text = FillDescription(GameManager.manager.team [0].attack, GameManager.manager.team [0].defense,GameManager.manager.team [0].spAttack, GameManager.manager.team [0].spDefense);
		Char2stats.text = FillDescription(GameManager.manager.team [1].attack, GameManager.manager.team [1].defense,GameManager.manager.team [1].spAttack, GameManager.manager.team [1].spDefense);
		Char3stats.text = FillDescription(GameManager.manager.team [2].attack, GameManager.manager.team [2].defense,GameManager.manager.team [2].spAttack, GameManager.manager.team [2].spDefense);
		Char4stats.text = FillDescription(GameManager.manager.team [3].attack, GameManager.manager.team [3].defense,GameManager.manager.team [3].spAttack, GameManager.manager.team [3].spDefense);
		}
	
	// Update is called once per frame
	void Update () {
		// run the select heroes function
		SelectedHeroes ();
	}

	string FillDescription(int attack, int defense, int specialA, int specialD)
	{
        // return this string to fill in character stats
        return "Attack: " + attack + "\nDefense: " + defense + "\nSpecial Attack: " + specialA + "\nSpecial Defense: " + specialD;
	}

	void SelectedHeroes(){
        // set the character to swap depending on turnstate.
        if (GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo0)
        {
			GameManager.manager.activePlayer = 0;
        }
        if (GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo1)
        {
			GameManager.manager.activePlayer = 1;
        }

        for (int i = 0; i < 4; i++) {
			// Debug.Log (i);

			// if either of the active duo members is equal to the team member at index 'i', mark the button text for that member as selected.
			if (GameManager.manager.activeDuo [0] == GameManager.manager.team [i] || GameManager.manager.activeDuo [1] == GameManager.manager.team [i]) {
				if (i == 0) {
					// set the red box to true
					selected1.gameObject.SetActive (true);
					// set the button text to selected
					b1.GetComponentInChildren<Text> ().text = "SELECTED";
				}
				if (i == 1) {
					selected2.gameObject.SetActive (true);
					b2.GetComponentInChildren<Text> ().text = "SELECTED";
				}
				if (i == 2) {
					selected3.gameObject.SetActive (true);
					b3.GetComponentInChildren<Text> ().text = "SELECTED";
				}
				if (i == 3) {
					selected4.gameObject.SetActive (true);
					b4.GetComponentInChildren<Text> ().text = "SELECTED";
				}

			}
			else
			{
				// if the active duo is not equal to team member i then do this
				if (i == 0) {
					// deactivate red box
					selected1.gameObject.SetActive (false);
					// set button text to deselected
					b1.GetComponentInChildren<Text> ().text = "deselected";
				}
				if (i == 1) {
					selected2.gameObject.SetActive (false);
					b2.GetComponentInChildren<Text> ().text = "deselected";
				}
				if (i == 2) {
					selected3.gameObject.SetActive (false);
					b3.GetComponentInChildren<Text> ().text = "deselected";
				}
				if (i == 3) {
					selected4.gameObject.SetActive (false);
					b4.GetComponentInChildren<Text> ().text = "deselected";
				}
			}
		}       
    }
}

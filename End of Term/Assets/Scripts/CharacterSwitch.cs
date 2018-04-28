using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitch : MonoBehaviour {

	public Text Char1;
	public Text Char2;
	public Text Char3;
	public Text Char4;

	public Text Char1stats;
	public Text Char2stats;
	public Text Char3stats;
	public Text Char4stats;

	public Image char1portrait;
	public Image char2portrait;
	public Image char3portrait;
	public Image char4portrait;

	public GameObject selected1;
	public GameObject selected2;
	public GameObject selected3;
	public GameObject selected4;

	public Button b1;
	public Button b2;
	public Button b3;
	public Button b4;

	public int charToSwap = 0;

	// Use this for initialization
	void Start () {

		Char1.text = GameManager.manager.team [0].characterName;
		Char2.text = GameManager.manager.team [1].characterName;
		Char3.text = GameManager.manager.team [2].characterName;
		Char4.text = GameManager.manager.team [3].characterName;


		Char1stats.text = FillDescription(GameManager.manager.team [0].attack, GameManager.manager.team [0].defense,GameManager.manager.team [0].spAttack, GameManager.manager.team [0].spDefense);
		Char2stats.text = FillDescription(GameManager.manager.team [1].attack, GameManager.manager.team [1].defense,GameManager.manager.team [1].spAttack, GameManager.manager.team [1].spDefense);
		Char3stats.text = FillDescription(GameManager.manager.team [2].attack, GameManager.manager.team [2].defense,GameManager.manager.team [2].spAttack, GameManager.manager.team [2].spDefense);
		Char4stats.text = FillDescription(GameManager.manager.team [3].attack, GameManager.manager.team [3].defense,GameManager.manager.team [3].spAttack, GameManager.manager.team [3].spDefense);
		}
	
	// Update is called once per frame
	void Update () {
		SelectedHeroes ();

	}

	string FillDescription(int attack, int defense, int specialA, int specialD)
	{
		return "Attack: " + attack + "\nDefense: " + defense + "\nSpecial Attack: " + specialA + "\nSpecial Defense: " + specialD;
		Debug.Log ("Filled");
	}

	void SelectedHeroes(){
		for (int i = 0; i < 4; i++) {
			Debug.Log (i);
			if (GameManager.manager.activeDuo [0] == GameManager.manager.team [i] || GameManager.manager.activeDuo [1] == GameManager.manager.team [i]) {
				Debug.Log ("checK");
				if (i == 0) {
					selected1.gameObject.SetActive (true);
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
				Debug.Log ("checKed");
				if (i == 0) {
					selected1.gameObject.SetActive (false);
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

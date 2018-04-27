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

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		Char1.text = GameManager.manager.team [0].characterName;
		Char2.text = GameManager.manager.team [1].characterName;
		Char3.text = GameManager.manager.team [2].characterName;
		Char4.text = GameManager.manager.team [3].characterName;


		Char1stats.text = FillDescription(GameManager.manager.team [0].attack, GameManager.manager.team [0].defense,GameManager.manager.team [0].spAttack, GameManager.manager.team [0].spDefense);
		Char2stats.text = FillDescription(GameManager.manager.team [1].attack, GameManager.manager.team [1].defense,GameManager.manager.team [1].spAttack, GameManager.manager.team [1].spDefense);
		Char3stats.text = FillDescription(GameManager.manager.team [2].attack, GameManager.manager.team [2].defense,GameManager.manager.team [2].spAttack, GameManager.manager.team [2].spDefense);
		Char4stats.text = FillDescription(GameManager.manager.team [3].attack, GameManager.manager.team [3].defense,GameManager.manager.team [3].spAttack, GameManager.manager.team [3].spDefense);

	}

	string FillDescription(int attack, int defense, int specialA, int specialD)
	{
		return "Attack: " + attack + "\n\nDefense: " + defense + "\n\nSpecial Attack: " + specialA + "\n\nSpecial Defense: " + specialD;
		Debug.Log ("Filled");
	}
}

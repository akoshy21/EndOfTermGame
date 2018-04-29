using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject active0;
    public GameObject active1;
    public GameObject enemy0;
    public GameObject enemy1;
    public GameObject enemy2;

    public static GameManager manager;

    public enum TurnState { Menu, Attacks, CharacterSwap, Stats }
    public TurnState turnstate;

    public enum CurrentTurn { ActiveDuo0, ActiveDuo1, Enemy0, Enemy1, Enemy2}
    public CurrentTurn curTurn;

    public GameObject CharacterSwapPanel;

	public Character[] team;
	public Character[] activeDuo;

    void Awake () {
        GameManagerSetup();
	}

    void Start()
    {
        turnstate = TurnState.Menu;
        curTurn = CurrentTurn.ActiveDuo0;
    }


    void Update () {
        PanelManager();
        LightChange();
        Debug.Log(activeDuo[0].characterName);
	}

    void GameManagerSetup()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }

    void PanelManager()
    {
        if(turnstate == TurnState.CharacterSwap)
        {
            CharacterSwapPanel.SetActive(true);
        }
        else
        {
            CharacterSwapPanel.SetActive(false);
        }
    }

	public void MakeTheTeam()
	{
		team = new Character[4];
		team [0] = InitScript.roster.characters [0];
		team [1] = InitScript.roster.characters [1];
		team [2] = InitScript.roster.characters [2];
		team [3] = InitScript.roster.characters [3];

		activeDuo = new Character[2];
		activeDuo[0] = team [0];
		activeDuo[1] = team [1];
	}

    void LightChange()
    {
        Debug.Log(curTurn);
        switch (curTurn)
        {
            case CurrentTurn.ActiveDuo0:
                enemy2.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                active0.GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);
                return;
            case CurrentTurn.ActiveDuo1:
                active0.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                active1.GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);
                return;
            case CurrentTurn.Enemy0:
                active1.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                enemy0.GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);
                return;
            case CurrentTurn.Enemy1:
                enemy0.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                enemy1.GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);
                return;
            case CurrentTurn.Enemy2:
                enemy1.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                enemy2.GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);
                return;
            default:
                return;
        }
    }
}

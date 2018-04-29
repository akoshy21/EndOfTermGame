using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

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
}

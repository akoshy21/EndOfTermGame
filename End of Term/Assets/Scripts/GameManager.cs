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
	public Character[] enemies;

	public int activePlayer = 0;

    // debug shit
    int help;
    public bool end = false;

    void Awake () {
        GameManagerSetup();
	}

    void Start()
    {
        turnstate = TurnState.Menu;
        curTurn = CurrentTurn.ActiveDuo0;
		SetupSprites ();

    }


    void Update () {
        PanelManager();
        LightChange();

		SetupSprites ();

        EndTurn();

        Debug.Log(help);
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

	// called in InitScript (make the team and enemies)
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

		enemies = new Character[3];
		enemies [0] = InitScript.roster.characters [5];
		enemies [1] = InitScript.roster.characters [4];
		enemies [2] = InitScript.roster.characters [5];
	}

	void SetupSprites()
	{
		active0.GetComponent<SpriteRenderer> ().sprite = activeDuo [0].charSprite;
		active1.GetComponent<SpriteRenderer> ().sprite = activeDuo [1].charSprite;

		enemy0.GetComponent<SpriteRenderer> ().sprite = enemies [0].charSprite;
		enemy1.GetComponent<SpriteRenderer> ().sprite = enemies [1].charSprite;
		enemy2.GetComponent<SpriteRenderer> ().sprite = enemies [2].charSprite;

	}

    void LightChange()
    {
        // Debug.Log(curTurn);
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

    public void EndTurn()
    {
        if (end == true)
        {
            help++;

            if (curTurn == CurrentTurn.ActiveDuo1)
            {
                curTurn = CurrentTurn.Enemy0;
            }
            if (curTurn == CurrentTurn.ActiveDuo0)
            {
                curTurn = CurrentTurn.ActiveDuo1;
            }
            end = false;
        }
    }
}

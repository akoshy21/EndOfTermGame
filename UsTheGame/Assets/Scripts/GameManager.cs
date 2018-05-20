using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject active0;
    public GameObject active1;
    public GameObject enemy0;
    public GameObject enemy1;
    public GameObject enemy2;

    public static GameManager manager;

	public GameObject music;

	public int charID;

    public enum TurnState { Menu, Attacks, CharacterSwap, Stats, Target }
    public TurnState turnstate;

    public enum CurrentTurn { ActiveDuo0, ActiveDuo1, Enemy0, Enemy1, Enemy2, ExecuteMoves}
    public CurrentTurn curTurn;

    public GameObject CharacterSwapPanel;

	public Character[] team;
	public Character[] activeDuo;
	public Character[] enemies;

	public GameObject targeting;

	public int activePlayer = 0;

    // debug shit
    int help;
    public bool end = false;
    public int gameEnd;

    void Awake () {
        GameManagerSetup();
	}

    void Start()
    {
        turnstate = TurnState.Menu;
        curTurn = CurrentTurn.ActiveDuo0;
		SetupAnimators ();

		music.gameObject.SetActive (true);

    }


    void Update () {

        PanelManager();
        LightChange();

		ConditionalObjects ();
        EndGame();

		SetupAnimators ();
        //Debug.Log(curTurn);
        //Debug.Log("is 1 Dead? " + activeDuo[0].dead);
        //Debug.Log("is 2 Dead? " + activeDuo[1].dead);
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
		activeDuo[1] = team [2];

		enemies = new Character[3];
		enemies [0] = InitScript.roster.characters [5];
		enemies [1] = InitScript.roster.characters [4];
		enemies [2] = new Character(InitScript.roster.characters [5]);
	}

	void SetupAnimators()
	{
		active0.GetComponent<Animator> ().runtimeAnimatorController = activeDuo [0].animator;
		active1.GetComponent<Animator> ().runtimeAnimatorController = activeDuo [1].animator;

        enemy0.GetComponent<Animator>().runtimeAnimatorController = enemies[0].animator;
        enemy1.GetComponent<Animator>().runtimeAnimatorController = enemies[1].animator;
        enemy2.GetComponent<Animator>().runtimeAnimatorController = enemies[2].animator;

    }

    void LightChange()
    {
        // Debug.Log(curTurn);
		// Debug.Log(turnstate);

        switch (curTurn)
        {
            case CurrentTurn.ActiveDuo0:
                active0.GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);
                active1.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                if (activeDuo[0].dead)
                    turnstate = TurnState.CharacterSwap;
                return;
			case CurrentTurn.ActiveDuo1:
				active0.GetComponent<Transform> ().GetChild (0).gameObject.SetActive (false);
				active1.GetComponent<Transform> ().GetChild (0).gameObject.SetActive (true);
                if (activeDuo[1].dead)
                    turnstate = TurnState.CharacterSwap;
                return;
			case CurrentTurn.ExecuteMoves:
                Combat.combat.MoveResults();
				TurnEnd ("GM, 138");
				return;
			default:	
                return;
        }
    }

	void ConditionalObjects()
	{
		switch (turnstate)
		{
		case TurnState.Menu:
                targeting.gameObject.SetActive (false);
			return;
		case TurnState.Stats:
			targeting.gameObject.SetActive (false);
			return;
		case TurnState.Attacks:
			targeting.gameObject.SetActive (false);
			return;
		case TurnState.CharacterSwap:
			targeting.gameObject.SetActive (false);
			return;
		case TurnState.Target:
			targeting.gameObject.SetActive (true);
			Combat.combat.ActivateTargeting ();
			return;
		default:
			return;
		}
	}
		

	public void TurnEnd(string source = null)
	{
		//Debug.Log (source);
			switch (curTurn) {
			case CurrentTurn.ActiveDuo0:
				for (int i = 0; i < activeDuo [0].mods.Length; i++) {
					activeDuo [0].mods [i].timer--;
					// keep working
					if (activeDuo [0].mods [i].timer == 0) {
						activeDuo [0].mods [i] = InitScript.roster.effectIndex [0];
					}
				}
				Combat.combat.ResetState ();
				curTurn = CurrentTurn.ActiveDuo1;
				return;
			case CurrentTurn.ActiveDuo1:
				for (int i = 0; i < activeDuo [1].mods.Length; i++) {
					activeDuo [1].mods [i].timer--;
					// keep working
					if (activeDuo [1].mods [i].timer == 0) {
						activeDuo [1].mods [i] = InitScript.roster.effectIndex [0];
					}
				}
				curTurn = CurrentTurn.Enemy0;
				Combat.combat.ResetState ();
				return;
			case CurrentTurn.Enemy0:
				for (int i = 0; i < enemies [0].mods.Length; i++) {
					enemies [0].mods [i].timer--;
					// keep working
					if (enemies [0].mods [i].timer == 0) {
						enemies [0].mods [i] = InitScript.roster.effectIndex [0];
					}
				}
				Combat.combat.ResetState ();
				curTurn = CurrentTurn.Enemy1;
				return;
			case CurrentTurn.Enemy1:
				for (int i = 0; i < enemies [1].mods.Length; i++) {
					enemies [1].mods [i].timer--;
					// keep working
					if (enemies [1].mods [i].timer == 0) {
						enemies [1].mods [i] = InitScript.roster.effectIndex [0];
					}
				}
				Combat.combat.ResetState ();
				curTurn = CurrentTurn.Enemy2;
				return;
			case CurrentTurn.Enemy2:
				for (int i = 0; i < enemies [2].mods.Length; i++) {
					enemies [2].mods [i].timer--;
					// keep working
					if (enemies [2].mods [i].timer == 0) {
						enemies [2].mods [i] = InitScript.roster.effectIndex [0];
					}
				}
				curTurn = CurrentTurn.ExecuteMoves;
				Combat.combat.ResetState ();
				return;
			case CurrentTurn.ExecuteMoves:
				curTurn = CurrentTurn.ActiveDuo0;
				return;
			default:
				return;
			}
		}

    public void EndGame()
    {
        if (enemies[0].dead && enemies[1].dead && enemies[2].dead)
        {
            gameEnd = -1;
            SceneManager.LoadScene("End", LoadSceneMode.Single);
        }
        if (team[0].dead && team[1].dead && team[2].dead && team[3].dead)
        {
            gameEnd = 1;
            SceneManager.LoadScene("End", LoadSceneMode.Single);
        }
    }

	}

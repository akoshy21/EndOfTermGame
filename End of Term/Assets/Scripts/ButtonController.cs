using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour {

    public int button;
    public Button but;

	void Start () {
        but = this.GetComponent<Button>();
        but.onClick.AddListener(TaskOnClick);
	}

	void Update () {
        UpdateText();
	}

    void UpdateText()
    {

		if (button != 5 && (GameManager.manager.turnstate == GameManager.TurnState.CharacterSwap || GameManager.manager.turnstate == GameManager.TurnState.Target))
		{
			ButtonActivate(false);
		}

        switch (button)
        {
            case 1:
                if (GameManager.manager.turnstate == GameManager.TurnState.Menu)
                {
                    ButtonActivate(true);
                    but.GetComponentInChildren<Text>().text = "Attack";
                }
                if (GameManager.manager.turnstate == GameManager.TurnState.Attacks)
                {
					ButtonActivate (true);
					if(GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo0)
					{
						but.GetComponentInChildren<Text>().text = GameManager.manager.activeDuo [0].moveSet [0].name;
					}
					else if(GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo1)
					{
						but.GetComponentInChildren<Text>().text = GameManager.manager.activeDuo [1].moveSet [0].name;
					}	
                }

                return;
            case 2:
                if (GameManager.manager.turnstate == GameManager.TurnState.Menu)
                {
                    ButtonActivate(true);
                    but.GetComponentInChildren<Text>().text = "Swap";
                }
                if (GameManager.manager.turnstate == GameManager.TurnState.Attacks)
                {
					ButtonActivate (true);
					if(GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo0)
					{
						but.GetComponentInChildren<Text>().text = GameManager.manager.activeDuo [0].moveSet [1].name;
					}
					else if(GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo1)
					{
						but.GetComponentInChildren<Text>().text = GameManager.manager.activeDuo [1].moveSet [1].name;
					}	
                }
                return;
            case 3:
                if (GameManager.manager.turnstate == GameManager.TurnState.Menu)
                {
                    ButtonActivate(true);
                    but.GetComponentInChildren<Text>().text = "Stats";
                }
                if (GameManager.manager.turnstate == GameManager.TurnState.Attacks)
                {
					ButtonActivate (true);
					if(GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo0)
					{
						but.GetComponentInChildren<Text>().text = GameManager.manager.activeDuo [0].moveSet [2].name;
					}
					else if(GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo1)
					{
						but.GetComponentInChildren<Text>().text = GameManager.manager.activeDuo [1].moveSet [2].name;
					}	
                }

                return;
			case 4:
				if (GameManager.manager.turnstate == GameManager.TurnState.Menu) {
					ButtonActivate (true);
					but.GetComponentInChildren<Text> ().text = "Run";
				}
				if (GameManager.manager.turnstate == GameManager.TurnState.Attacks) {
					ButtonActivate (true);
					if (GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo0) {
						but.GetComponentInChildren<Text> ().text = GameManager.manager.activeDuo [0].moveSet [3].name;
					} else if (GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo1) {
						but.GetComponentInChildren<Text> ().text = GameManager.manager.activeDuo [1].moveSet [3].name;
					}
				}
		        return;
			case 5:
				if (GameManager.manager.turnstate == GameManager.TurnState.Menu) {
					ButtonActivate (false);
				}
			        if (GameManager.manager.turnstate == GameManager.TurnState.Attacks || GameManager.manager.turnstate == GameManager.TurnState.CharacterSwap || GameManager.manager.turnstate == GameManager.TurnState.Stats)
		        {
		            ButtonActivate(true);
		        }
		        return;
		    default:
		        return;
        }
    }

    void TaskOnClick()
	{
		ButtonClick ();
		EventSystem.current.SetSelectedGameObject (null);
    }

    void UpdateActivePlayer()
    {
        if (GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo0)
        {
            GameManager.manager.activePlayer = 0;
        }
        if (GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo1)
        {
            GameManager.manager.activePlayer = 1;
        }
    }

	void ButtonClick()
	{
		switch (GameManager.manager.turnstate) {
		case GameManager.TurnState.Menu:
			if (button == 1)
				GameManager.manager.turnstate = GameManager.TurnState.Attacks;
			if (button == 2)
				GameManager.manager.turnstate = GameManager.TurnState.CharacterSwap;
			if (button == 3)
				GameManager.manager.turnstate = GameManager.TurnState.Stats;
			if (button == 4)
				Application.Quit ();
			return;
		case GameManager.TurnState.Attacks:
			if (button == 5) {
				GameManager.manager.turnstate = GameManager.TurnState.Menu;
			}
			else {
                    // something feels wrong; reread later
                UpdateActivePlayer();
				Combat.combat.currentMove = GameManager.manager.activeDuo [GameManager.manager.activePlayer].moveSet [button-1];
                    
				Combat.combat.AddMoves (button);
				if (!(Combat.combat.currentMove.targetCount == 2 && Combat.combat.currentMove.isAttack == false) && (Combat.combat.currentMove.targetCount != 0 && Combat.combat.currentMove.targetCount != 3)) {
					GameManager.manager.turnstate = GameManager.TurnState.Target;
				}
                else {
					switch (GameManager.manager.curTurn) {
					case GameManager.CurrentTurn.ActiveDuo0:
						GameManager.manager.TurnEnd ();
						break;
					case GameManager.CurrentTurn.ActiveDuo1:
						GameManager.manager.TurnEnd ();
						break;
					default:
						break;
					}
				}
			}
			Debug.Log ("CLICK");

			return;
		case GameManager.TurnState.CharacterSwap:
			if (button == 5) {
				GameManager.manager.turnstate = GameManager.TurnState.Menu;
			}
			return;
		case GameManager.TurnState.Stats:
			if (button == 5) {
				GameManager.manager.turnstate = GameManager.TurnState.Menu;
			}
			return;
		case GameManager.TurnState.Target:
			if (button == 5)
				GameManager.manager.turnstate = GameManager.TurnState.Attacks;
			return;
		default:
			return;
		}
	}


    void ButtonActivate(bool active)
    {
		if (button != 5) {
			but.gameObject.GetComponentInChildren<Text> ().enabled = active;
		}
        but.gameObject.GetComponent<Image>().enabled = active;
        but.gameObject.GetComponent<Button>().enabled = active;
    }
}

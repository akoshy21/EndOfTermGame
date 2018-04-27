using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        switch (button)
        {
            case 1:
                if (GameManager.manager.turnstate == GameManager.TurnState.Menu)
                {
                    but.GetComponentInChildren<Text>().text = "Attack";
                }
                if (GameManager.manager.turnstate == GameManager.TurnState.Attacks)
                {
                    but.GetComponentInChildren<Text>().text = "Attack 1";
                }
                return;
            case 2:
                if (GameManager.manager.turnstate == GameManager.TurnState.Menu)
                {
                    but.GetComponentInChildren<Text>().text = "Swap";
                }
                if (GameManager.manager.turnstate == GameManager.TurnState.Attacks)
                {
                    but.GetComponentInChildren<Text>().text = "Attack 2";
                }
                return;
            case 3:
                if (GameManager.manager.turnstate == GameManager.TurnState.Menu)
                {
                    but.GetComponentInChildren<Text>().text = "Stats";
                }
                if (GameManager.manager.turnstate == GameManager.TurnState.Attacks)
                {
                    but.GetComponentInChildren<Text>().text = "Attack 3";
                }
                return;
            case 4:
                if (GameManager.manager.turnstate == GameManager.TurnState.Menu)
                {
                    but.GetComponentInChildren<Text>().text = "Run";
                }
                if (GameManager.manager.turnstate == GameManager.TurnState.Attacks)
                {
                    but.GetComponentInChildren<Text>().text = "Attack 4";
                }
                return;
            case 5:
                if (GameManager.manager.turnstate == GameManager.TurnState.Menu)
                {
                    ButtonActivate(false);
                }
                if (GameManager.manager.turnstate == GameManager.TurnState.Attacks)
                {
                    ButtonActivate(true);
                    but.GetComponentInChildren<Text>().text = "Back";
                }
                return;
            default:
                return;
        }
    }

    void TaskOnClick()
    {
        if (GameManager.manager.turnstate == GameManager.TurnState.Menu)
        {
            if (button == 1)
            GameManager.manager.turnstate = GameManager.TurnState.Attacks;
            if(button == 2)
            GameManager.manager.turnstate = GameManager.TurnState.CharacterSwap;
            if(button == 3)
            GameManager.manager.turnstate = GameManager.TurnState.Stats;
        }
        if (GameManager.manager.turnstate == GameManager.TurnState.Attacks)
        {
            if (button == 5)
                GameManager.manager.turnstate = GameManager.TurnState.Menu;
        }
    }

    void ButtonActivate(bool active)
    {
        but.gameObject.GetComponentInChildren<Text>().enabled = active;
        but.gameObject.GetComponent<Image>().enabled = active;
        but.gameObject.GetComponent<Button>().enabled = active;
    }
}

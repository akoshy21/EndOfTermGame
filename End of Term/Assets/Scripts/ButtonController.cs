using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public int button;
    public Button but;

	void Start () {

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
                return;
            case 2:
                if (GameManager.manager.turnstate == GameManager.TurnState.Menu)
                {
                    but.GetComponentInChildren<Text>().text = "Characters";
                }
                return;
            case 3:
                if (GameManager.manager.turnstate == GameManager.TurnState.Menu)
                {
                    but.GetComponentInChildren<Text>().text = "Attack";
                }
                return;
            case 4:
                if (GameManager.manager.turnstate == GameManager.TurnState.Menu)
                {
                    but.GetComponentInChildren<Text>().text = "Attack";
                }
                return;
            default:
                return;
        }
    }
}

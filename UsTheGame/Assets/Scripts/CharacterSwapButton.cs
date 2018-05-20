using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwapButton : MonoBehaviour
{

    public int bNum;
    public Button but;

    // Use this for initialization
    void Start()
    {
        but = this.GetComponent<Button>();
        but.onClick.AddListener(SwapCharacter);

    }
    // Update is called once per frame
    void Update()
	{

	}

    void SwapCharacter()
    {
        GameManager.manager.end = true;
		for(int i = 0; i < 4; i++)
		{
			if (GameManager.manager.activeDuo[GameManager.manager.activePlayer].characterName == GameManager.manager.team[i].characterName) {
				GameManager.manager.team[i] = GameManager.manager.activeDuo[GameManager.manager.activePlayer];
			}
		}

     switch (bNum)
        {
            case 1:
			GameManager.manager.activeDuo[GameManager.manager.activePlayer] = GameManager.manager.team[0];
                break;
            case 2:
			GameManager.manager.activeDuo[GameManager.manager.activePlayer] = GameManager.manager.team[1];
                break;
            case 3:
			GameManager.manager.activeDuo[GameManager.manager.activePlayer] = GameManager.manager.team[2];
                break;
            case 4:
			GameManager.manager.activeDuo[GameManager.manager.activePlayer] = GameManager.manager.team[3];
                break;
            default:
                break;
        }

		Combat.combat.selectedMove [GameManager.manager.activePlayer] = new Move ("Swap", null, 0, false, 0, 0, false, GameManager.manager.activeDuo [GameManager.manager.activePlayer], 0);

        //Cycle to Next Turn After Swapping
        if (!GameManager.manager.activeDuo[GameManager.manager.activePlayer].dead)
            GameManager.manager.TurnEnd();
    }
}
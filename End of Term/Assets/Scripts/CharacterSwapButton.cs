using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwapButton : MonoBehaviour
{

    public int bNum;
    public Button but;

    public GameObject swapper;

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

     switch (bNum)
        {
            case 1:
                GameManager.manager.activeDuo[swapper.GetComponent<CharacterSwitch>().charToSwap] = GameManager.manager.team[0];
                break;
            case 2:
                GameManager.manager.activeDuo[swapper.GetComponent<CharacterSwitch>().charToSwap] = GameManager.manager.team[1];
                break;
            case 3:
                GameManager.manager.activeDuo[swapper.GetComponent<CharacterSwitch>().charToSwap] = GameManager.manager.team[2];
                break;
            case 4:
                GameManager.manager.activeDuo[swapper.GetComponent<CharacterSwitch>().charToSwap] = GameManager.manager.team[3];
                break;
            default:
                break;
        }

        //Cycle to Next Turn After Swapping
        GameManager.manager.turnstate = GameManager.TurnState.Menu;
    }
}
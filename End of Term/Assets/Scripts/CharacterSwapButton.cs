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
    //Cycle to Next Turn After Swapping
    GameManager.manager.turnstate = GameManager.TurnState.Menu;

    if (GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo0)
        GameManager.manager.curTurn = GameManager.CurrentTurn.ActiveDuo1;

    if (GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo1)
        GameManager.manager.curTurn = GameManager.CurrentTurn.Enemy0;


    switch (bNum)
    {
        case 1:
            GameManager.manager.activeDuo[swapper.GetComponent<CharacterSwitch>().charToSwap] = GameManager.manager.team[0];
            return;
        case 2:
            GameManager.manager.activeDuo[swapper.GetComponent<CharacterSwitch>().charToSwap] = GameManager.manager.team[1];
            return;
        case 3:
            GameManager.manager.activeDuo[swapper.GetComponent<CharacterSwitch>().charToSwap] = GameManager.manager.team[2];
            return;
        case 4:
            GameManager.manager.activeDuo[swapper.GetComponent<CharacterSwitch>().charToSwap] = GameManager.manager.team[3];
            return;
        default:
            return;
    }
}
}
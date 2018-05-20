using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public static EnemyAI enemyai;

    public bool gordon;
    public bool burgess;

    int currentEnemy;
	// Use this for initialization
	void Start () {
        if (enemyai == null)
        {
            enemyai = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
		//Debug.Log (gordon);
		//Debug.Log (burgess);
        Gordon();
        Burgess();

        if (GameManager.manager.curTurn == GameManager.CurrentTurn.Enemy0)
                currentEnemy = 0;
        if (GameManager.manager.curTurn == GameManager.CurrentTurn.Enemy1)
                currentEnemy = 1;
        if (GameManager.manager.curTurn == GameManager.CurrentTurn.Enemy2)
                currentEnemy = 2;     
    }
    void Gordon()
    {
        if (gordon && !(GameManager.manager.enemies[currentEnemy].currentHealth <= 0))
        {

            if (GameManager.manager.enemies[currentEnemy].currentHealth <= GameManager.manager.enemies[currentEnemy].maxHealth / 10)
            {
                //if Gordon's health drops below 10 percent, he self destructs and deals massive damage
                Combat.combat.selectedMove[currentEnemy + 2] = GameManager.manager.enemies[currentEnemy].moveSet[3];
                Combat.combat.selectedMove[currentEnemy + 2].target[0] = GameManager.manager.activeDuo[0];
                Combat.combat.selectedMove[currentEnemy + 2].target[0] = GameManager.manager.activeDuo[1];
            }
            else if (GameManager.manager.enemies[1].currentHealth <= (GameManager.manager.enemies[1].maxHealth / 2) && GameManager.manager.enemies[currentEnemy].currentMP >= 4)
            {
                //if Burgess is half health or lower, gordon will heal him.
                Combat.combat.selectedMove[currentEnemy + 2] = GameManager.manager.enemies[currentEnemy].moveSet[1];
                Combat.combat.selectedMove[currentEnemy + 2].target[0] = GameManager.manager.enemies[1];
            }
            else if (GameManager.manager.enemies[currentEnemy].currentHealth <= (GameManager.manager.enemies[currentEnemy].maxHealth / 2) && GameManager.manager.enemies[currentEnemy].currentMP >= 4)
            {
                //if Gordon is half health or lower, gordon will heal himself.
                Combat.combat.selectedMove[currentEnemy + 2] = GameManager.manager.enemies[currentEnemy].moveSet[1];
                Combat.combat.selectedMove[currentEnemy + 2].target[0] = GameManager.manager.enemies[currentEnemy];
            }
            else if (GameManager.manager.enemies[1].currentMP <= (GameManager.manager.enemies[1].maxMP / 2) && GameManager.manager.enemies[currentEnemy].currentMP >= 4)
            {
                //if Burgess is half MP or lower, gordon will grant him more magic
                Combat.combat.selectedMove[currentEnemy + 2] = GameManager.manager.enemies[currentEnemy].moveSet[2];
                Combat.combat.selectedMove[currentEnemy + 2].target[0] = GameManager.manager.enemies[1];
            }
            else
            {
                //If Burgess' needs are satiated and Gordon is not in danger, he will attack indiscriminately 
                Combat.combat.selectedMove[currentEnemy + 2] = GameManager.manager.enemies[currentEnemy].moveSet[0];
                //Debug.Log (Combat.combat.selectedMove[currentEnemy + 2].name);
                Combat.combat.selectedMove[currentEnemy + 2].target[0] = GameManager.manager.activeDuo[Random.Range(0, 2)];
            }
			GameManager.manager.TurnEnd("EAI, 64");
		}else if (gordon)
            GameManager.manager.TurnEnd("EAI, 64");
    }
    void Burgess()
    {
        if (burgess && !(GameManager.manager.enemies[currentEnemy].currentHealth <= 0))
        {
			Combat.combat.selectedMove[currentEnemy + 2] = GameManager.manager.enemies[currentEnemy].moveSet[0];
            Combat.combat.selectedMove[currentEnemy + 2].target[0] = GameManager.manager.activeDuo[Random.Range(0, 2)];
            GameManager.manager.TurnEnd("EAI, 72");
        }
        else if (burgess)
            GameManager.manager.TurnEnd("EAI, 64");
    }
}

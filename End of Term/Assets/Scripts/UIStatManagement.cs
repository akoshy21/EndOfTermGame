using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatManagement : MonoBehaviour {

	public Image p0healthFill;
	public Text p0htext;
	public Image p0manaFill;
	public Text p0mtext;

	public Image p1healthFill;
	public Text p1htext;
	public Image p1manaFill;
	public Text p1mtext;

	public Image e0healthFill;
	public Image e0manaFill;

	public Image e1healthFill;
	public Image e1manaFill;

	public Image e2healthFill;
	public Image e2manaFill;

	void Update()
	{
		UpdateFills ();
		//
	
		if (Input.GetKeyDown (KeyCode.Space)) {
			for (int i = 0; i < 3; i++) {
				Debug.Log(GameManager.manager.enemies [i].currentHealth);
			}

		}
	}

	void UpdateFills()
	{
		p0healthFill.fillAmount = ((float)GameManager.manager.activeDuo [0].currentHealth) / ((float)GameManager.manager.activeDuo [0].maxHealth);
		p0htext.text = GameManager.manager.activeDuo [0].currentHealth + " / " + GameManager.manager.activeDuo [0].maxHealth;
		p0manaFill.fillAmount = ((float)GameManager.manager.activeDuo [0].currentMP) / ((float)GameManager.manager.activeDuo [0].maxMP);
		p0mtext.text = GameManager.manager.activeDuo [0].currentMP + " / " + GameManager.manager.activeDuo [0].maxMP;

		p1healthFill.fillAmount = ((float)GameManager.manager.activeDuo [1].currentHealth) / ((float)GameManager.manager.activeDuo [1].maxHealth);
		p1htext.text = GameManager.manager.activeDuo [1].currentHealth + " / " + GameManager.manager.activeDuo [1].maxHealth;
		p1manaFill.fillAmount = ((float)GameManager.manager.activeDuo [1].currentMP) / ((float)GameManager.manager.activeDuo [1].maxMP);
		p1mtext.text = GameManager.manager.activeDuo [1].currentMP + " / " + GameManager.manager.activeDuo [1].maxMP;

		e0healthFill.fillAmount = ((float)GameManager.manager.enemies [0].currentHealth) / ((float)GameManager.manager.enemies [0].maxHealth);
		e0manaFill.fillAmount = ((float)GameManager.manager.enemies [0].currentMP) / ((float)GameManager.manager.enemies [0].maxMP);

		e1healthFill.fillAmount = ((float)GameManager.manager.enemies [1].currentHealth) / ((float)GameManager.manager.enemies [1].maxHealth);
		e1manaFill.fillAmount = ((float)GameManager.manager.enemies [1].currentMP) / ((float)GameManager.manager.enemies [1].maxMP);

		e2healthFill.fillAmount = ((float)GameManager.manager.enemies [2].currentHealth) / ((float)GameManager.manager.enemies [2].maxHealth);
		e2manaFill.fillAmount = ((float)GameManager.manager.enemies [2].currentMP) / ((float)GameManager.manager.enemies [2].maxMP);

	}
}
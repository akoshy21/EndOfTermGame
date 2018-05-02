using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour {

	public Modifiers[] effectIndex;
	public static Effects index;

	// Use this for initialization
	void Awake () {
		if (index == null) {
			index = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InitializeIndex()
	{
		effectIndex = new Modifiers[20];

		effectIndex [0] = new Modifiers (false, false, 0, 0, 0, 0, "NOTHING");
		effectIndex [1] = new Modifiers (false, false, 0, 0, 0, 0, "heal");
		effectIndex [2] = new Modifiers (false, false, 0, 1, 1, 0, "remove all effects");
		effectIndex [3] = new Modifiers (false, false, 0, 0.2f, 0, 3, "ups damage");
		effectIndex [4] = new Modifiers (false, true, 7, 0, 0, 5, "small shield");
		effectIndex [5] = new Modifiers (false, false, 0, 0, 0, 0, "intervene");
		effectIndex [6] = new Modifiers (false, false, 0, 0.2f, 0.2f, 3, "self inspire, ups speed n damage");
		effectIndex [7] = new Modifiers (false, false, 0, 0, -0.2f, 2, "deaf");



	}

	public void CheckEffects(int ind, Character tar)
	{
		switch (ind) {
		case 2:
			for(int i = 0; i < 4; i++)
			{
				tar.mods[i] = effectIndex[0];
			}
			return;
		case 3:
			for(int i = 0; i < 4; i++)
			{
				if(tar.mods[i] == effectIndex[0])
				{
					tar.mods[i] = effectIndex[3];
					break;
				}
			}
			return;
		case 4:
			for(int i = 0; i < 4; i++)
			{
				Debug.Log ("SHIELDED, shield at " + effectIndex[4].shield);
				if(tar.mods[i] == effectIndex[0])
				{
					tar.mods[i] = effectIndex[4];
					tar.shield = effectIndex[4].shield;
					tar.shieldMax = tar.shield;
					tar.shielded = true;

					for (int j = 0; j < 2; j++) {
						if (tar.RID == GameManager.manager.activeDuo [j].RID) {
							GameManager.manager.activeDuo [j] = tar;
						}
					}

					break;
				}
			}
			return;
		case 5:
			Combat.combat.intervene = true;
			Combat.combat.intervener = tar;
			return;
		case 6:
			for(int i = 0; i < 4; i++)
			{
				if(tar.mods[i] == effectIndex[0])
				{
					tar.mods[i] = effectIndex[6];
					break;
				}
			}
			return;
		case 7:
			for(int i = 0; i < 4; i++)
			{
				if(tar.mods[i] == effectIndex[0])
				{
					tar.mods[i] = effectIndex[7];
					break;
				}
			}
			return;
		default:
			return;
		}
	}

	public void Intervene(Character t)
	{
		int an;
		
		if (t.RID == GameManager.manager.activeDuo [0].RID) {
			an = GameManager.manager.activeDuo [1].RID;
		} else {
			an = GameManager.manager.activeDuo [0].RID;
		}

		for (int i = 0; i < Combat.combat.selectedMove.Length; i++) {
			if (Combat.combat.selectedMove [i].targetCount == 3) {
				for (int j = 0; j < 3; j++) {
					Debug.Log (j);
					if (Combat.combat.selectedMove [i].target [j].RID == an) {
						Combat.combat.selectedMove [i].target [j] = t;
					}
				}
			}
			if (Combat.combat.selectedMove [i].targetCount == 2) {
				for (int j = 0; j < 2; j++) {
					Debug.Log (j);
					if (Combat.combat.selectedMove [i].target [j].RID == an) {
						Combat.combat.selectedMove [i].target [j] = t;
					}
				}
			}
			if (Combat.combat.selectedMove [i].targetCount == 1) {
				for (int j = 0; j < 1; j++) {
					Debug.Log (j);
					if (Combat.combat.selectedMove [i].target [j].RID == an) {
						Combat.combat.selectedMove [i].target [j] = t;
					}
				}
			}
		}
		//Combat.combat.intervene = false;
	}
}
